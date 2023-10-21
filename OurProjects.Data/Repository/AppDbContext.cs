using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OurProjects.Data.Models;
using OurProjects.Data.Models.Mapping;

namespace OurProjects.Data.Repository
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Technology> Technology { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnology { get; set; }
        public DbSet<ProjectTeamMember> ProjectTeamMember { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new UserMap())
                .ApplyConfiguration(new CompanyMap())
                .ApplyConfiguration(new AreaMap())
                .ApplyConfiguration(new TechnologyMap())
                .ApplyConfiguration(new ProjectMap())
                .ApplyConfiguration(new ProjectTechnologyMap())
                .ApplyConfiguration(new ProjectTeamMemberMap());
        }
    }
}
