using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Assignment_3.Models
{
    public class Movies
    {
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public Rating Rating { get; set; }
        public bool Edited { get; set; }
        public string Lent { get; set; }
        [MaxLength(25, ErrorMessage ="You can only enter up to 25 characters of Notes")]
        public string Notes { get; set; }
    }
    //This is how the object type "Rating" is configured as an enumeration of the rating options
    public enum Rating
    {
        G,
        PG,
        PG13,
        R
    }
}
