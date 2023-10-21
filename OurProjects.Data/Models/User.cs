using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OurProjects.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Idle { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public Guid IdCompany { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Project> ProjectsLeader { get; set; }
        public virtual ICollection<ProjectTeamMember> ProjectTeamMembers { get; set; }
    }
}
