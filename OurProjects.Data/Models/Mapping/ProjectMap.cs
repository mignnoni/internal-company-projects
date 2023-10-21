using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OurProjects.Data.Models.Mapping
{
    public sealed class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("project");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.IdArea).HasColumnName("idArea").IsRequired();
            builder.Property(x => x.IdCompany).HasColumnName("idCompany").IsRequired();
            builder.Property(x => x.IdLeader).HasColumnName("idLeader");
            builder.Property(x => x.Title).HasColumnName("title").HasMaxLength(300).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").IsRequired();
            builder.Property(x => x.Idle).HasColumnName("idle").IsRequired();
            builder.Property(x => x.StartDate).HasColumnName("startDate");
            builder.Property(x => x.EndDate).HasColumnName("endDate");
            builder.Property(x => x.Show).HasColumnName("show").IsRequired();
            builder.Property(x => x.ShowTeam).HasColumnName("showTeam").IsRequired();
            builder.Property(x => x.ShowLeader).HasColumnName("showLeader").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("createdAt").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updatedAt").IsRequired();

            builder
                .HasOne(one => one.Company)
                .WithMany(many => many.Projects)
                .HasForeignKey(fk => fk.IdCompany)
                .HasConstraintName("FK_project_company")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .HasOne(one => one.Area)
                .WithMany(many => many.Projects)
                .HasForeignKey(fk => fk.IdArea)
                .HasConstraintName("FK_project_area")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .HasOne(one => one.UserLeader)
                .WithMany(many => many.ProjectsLeader)
                .HasForeignKey(fk => fk.IdLeader)
                .HasConstraintName("FK_project_userLeader")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
