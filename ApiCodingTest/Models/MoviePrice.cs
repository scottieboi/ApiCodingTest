using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCodingTest.Models
{
    public class MoviePrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string ProviderId { get; set; }
        
        public string Provider { get; set; }
        
        public DateTime LastUpdated { get; set; }
        
        public string Price { get; set; }
    }
}