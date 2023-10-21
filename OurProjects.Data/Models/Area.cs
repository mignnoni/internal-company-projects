
namespace OurProjects.Data.Models
{
    public class Area
    {
        public Guid Id { get; set; }
        public Guid IdCompany { get; set; }
        public bool Idle { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
