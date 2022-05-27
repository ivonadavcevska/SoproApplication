using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sopro.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

    }
}