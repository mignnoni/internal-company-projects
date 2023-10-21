
namespace OurProjects.Data.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public Guid IdArea { get; set; }
        public Guid IdLeader { get; set; }
        public Guid IdCompany { get; set; }
        public bool Idle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Show { get; set; }
        public bool ShowTeam { get; set; }
        public bool ShowLeader { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual User UserLeader { get; set; }
        public virtual Area Area { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<ProjectTechnology> ProjectTechnologies { get; set; }
        public virtual ICollection<ProjectTeamMember> ProjectTeamMembers { get; set; }
    }
}
