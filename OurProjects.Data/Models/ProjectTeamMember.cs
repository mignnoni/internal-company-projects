
namespace OurProjects.Data.Models
{
    public class ProjectTeamMember
    {
        public Guid Id { get; set; }
        public Guid IdProject { get; set; }
        public Guid IdTeamMember { get; set; }
        public virtual Project Project { get; set; }
        public virtual User TeamMember { get; set; }
    }
}
