using Microsoft.AspNetCore.Identity;

namespace OurProjects.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid IdCompany { get; set; }
    }
}
