using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sopro.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        

        [Display(Name = "Release Date")]
        

        public DateTime? ReleaseDate { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<Person> People { get; set; }
         
    }
}