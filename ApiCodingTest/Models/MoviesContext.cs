using Microsoft.EntityFrameworkCore;

namespace ApiCodingTest.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options) {}
        
        public DbSet<Movie> Movies { get; set; }
        
        public DbSet<MovieDetail> MovieDetails { get; set; }
        
        public DbSet<MovieListStatus> MovieListStatuses { get; set; }
    }
}