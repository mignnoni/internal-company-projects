using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OurProjects.Data.Models.Mapping
{
    public sealed class ProjectTeamMemberMap : IEntityTypeConfiguration<ProjectTeamMember>
    {
        public void Configure(EntityTypeBuilder<ProjectTeamMember> builder)
        {
            builder.ToTable("projectTeamMember");

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.IdProject).HasColumnName("idArea").IsRequired();
            builder.Property(x => x.IdTeamMember).HasColumnName("idTeamMember").IsRequired();

            builder
                .HasKey(x => new { x.IdProject, x.IdTeamMember });

            builder
                .HasOne(one => one.Project)
                .WithMany(many => many.ProjectTeamMembers)
                .HasForeignKey(fk => fk.IdProject)
                .HasConstraintName("FK_projectTeamMember_project")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .HasOne(one => one.TeamMember)
                .WithMany(many => many.ProjectTeamMembers)
                .HasForeignKey(fk => fk.IdTeamMember)
                .HasConstraintName("FK_projectTeamMember_user")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

        }
    }
}
