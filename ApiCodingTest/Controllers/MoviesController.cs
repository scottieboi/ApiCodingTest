using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCodingTest.Dtos;
using ApiCodingTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCodingTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        
        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<MovieInfo>> GetMovies()
        {
            return await _moviesService.FetchMovies();
        }
    }
}