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
    }
}
