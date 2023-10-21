
namespace OurProjects.Data.Models
{
    public class ProjectTechnology
    {
        public Guid Id { get; set; }
        public Guid IdProject { get; set; }
        public Guid IdTechnology { get; set; }
        public virtual Project Project { get; set; }
        public virtual Technology Technology { get; set; }
    }
}
