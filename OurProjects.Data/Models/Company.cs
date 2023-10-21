using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProjects.Data.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public bool Idle { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }
    }
}
