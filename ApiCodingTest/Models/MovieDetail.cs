﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCodingTest.Models
{
    public class MovieDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string ProviderId { get; set; }
        
        public string Provider { get; set; }
        
        public DateTime LastUpdated { get; set; }
        
        public string Title { get; set; }
        
        public string Year { get; set; }
        
        public string Rated { get; set; }
        
        public string Released { get; set; }
        
        public string Runtime { get; set; }
        
        public string Genre { get; set; }
        
        public string Director { get; set; }
        
        public string Writer { get; set; }
        
        public string Actors { get; set; }
        
        public string Plot { get; set; }
        
        public string Language { get; set; }
        
        public string Country { get; set; }
        
        public string Poster { get; set; }
        
        public string MetaScore { get; set; }
        
        public string Rating { get; set; }
        
        public string Votes { get; set; }
        
        public string Type { get; set; }
        
        public Movie Movie { get; set; }
    }
}