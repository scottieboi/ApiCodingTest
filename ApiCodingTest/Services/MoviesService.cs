using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiCodingTest.Constants;
using ApiCodingTest.Dtos;
using ApiCodingTest.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApiCodingTest.Services
{
    public interface IMoviesService
    {
        Task<List<MovieInfo>> FetchMovies();
    }

    public class MoviesService : IMoviesService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly MoviesContext _moviesContext;

        public MoviesService(IHttpClientFactory clientFactory, MoviesContext moviesContext)
        {
            _clientFactory = clientFactory;
            _moviesContext = moviesContext;
        }

        public async Task<List<MovieInfo>> FetchMovies()
        {
            var client = _clientFactory.CreateClient("movies");
            var response = await client.GetAsync($"{nameof(Provider.cinemaworld)}/movies");

            if (!response.IsSuccessStatusCode)
            {
                // do fallback, from DB eventually
                return new List<MovieInfo>();
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MovieListApiResponse>(responseString);

            await UpdateDb(result, nameof(Provider.cinemaworld));

            return result.Movies.Select(item => new MovieInfo
            {
                Title = item.Title,
                Year = item.Year
            }).ToList();
        }

        private async Task UpdateDb(MovieListApiResponse response, string provider)
        {
            var status = await _moviesContext.MovieListStatuses.FindAsync(provider);
            if (status == null)
            {
                status = new MovieListStatus
                {
                    Provider = provider
                };
                _moviesContext.Add(status);
            }

            status.LastUpdated = DateTime.UtcNow;

            foreach (var movie in response.Movies)
            {
                var detail = await _moviesContext.MovieDetails.SingleOrDefaultAsync(x =>
                    x.Provider == nameof(Provider.cinemaworld) &&
                    x.ProviderId == movie.Id);

                // no need to save if it already exists in db
                if (detail != null)
                {
                    continue;
                }

                // find movie from other provider
                var existingMovie = await _moviesContext.Movies.SingleOrDefaultAsync(x =>
                    x.Title == movie.Title && x.Year == movie.Year);

                _moviesContext.MovieDetails.Add(new MovieDetail
                {
                    Provider = nameof(Provider.cinemaworld),
                    ProviderId = movie.Id,
                    LastUpdated = DateTime.UtcNow,
                    Movie = existingMovie ?? new Movie
                    {
                        Title = movie.Title,
                        Year = movie.Year
                    }
                });
            }

            await _moviesContext.SaveChangesAsync();
        }
    }
}