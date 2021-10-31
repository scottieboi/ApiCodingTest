using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCodingTest.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public ICollection<MovieDetail> MovieDetails { get; set; }
        
        public ICollection<MoviePrice> MoviePrices { get; set; }
    }
}