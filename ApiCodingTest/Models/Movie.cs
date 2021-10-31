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
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Year { get; set; }
        
        public ICollection<MovieDetail> MovieDetails { get; set; }
    }
}