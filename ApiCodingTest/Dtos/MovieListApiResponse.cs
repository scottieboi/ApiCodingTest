using System.Collections.Generic;

namespace ApiCodingTest.Dtos
{
    public class MovieListApiResponse
    {
        public List<MovieListApiResponseItem> Movies { get; set; }
    }

    public class MovieListApiResponseItem
    {
        public string Title { get; set; }
        public string Year { get; set; } 
        public string Id { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}