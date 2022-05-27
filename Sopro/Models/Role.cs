using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sopro.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}