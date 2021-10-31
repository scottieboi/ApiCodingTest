using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCodingTest.Models
{
    public class MovieListStatus
    {
        [Key]
        public string Provider { get; set; }
        
        public DateTime LastUpdated { get; set; }
    }
}