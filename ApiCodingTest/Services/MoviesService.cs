using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiCodingTest.Dtos;
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

        public MoviesService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        
        public async Task<List<MovieInfo>> FetchMovies()
        {
            var client = _clientFactory.CreateClient("movies");
            var response = await client.GetAsync("cinemaworld/movies");

            if (!response.IsSuccessStatusCode)
            {
                // do fallback, from DB eventually
                return new List<MovieInfo>();
            }
               
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MovieListApiResponse>(responseString);

            return result.Movies.Select(item => new MovieInfo
            {
                Title = item.Title,
                Year = item.Year
            }).ToList();
        }
    }
}