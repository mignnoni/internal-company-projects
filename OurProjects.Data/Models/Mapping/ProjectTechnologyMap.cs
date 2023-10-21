using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OurProjects.Data.Models.Mapping
{
    public sealed class ProjectTechnologyMap : IEntityTypeConfiguration<ProjectTechnology>
    {
        public void Configure(EntityTypeBuilder<ProjectTechnology> builder)
        {
            builder.ToTable("projectTechnology");

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.IdProject).HasColumnName("idProject").IsRequired();
            builder.Property(x => x.IdTechnology).HasColumnName("idCompany").IsRequired();

            builder
                .HasKey(x => new { x.IdProject, x.IdTechnology });

            builder
                .HasOne(one => one.Project)
                .WithMany(many => many.ProjectTechnologies)
                .HasForeignKey(fk => fk.IdProject)
                .HasConstraintName("FK_projectTechnology_project")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .HasOne(one => one.Technology)
                .WithMany(many => many.ProjectTechnologies)
                .HasForeignKey(fk => fk.IdTechnology)
                .HasConstraintName("FK_projectTechnology_technology")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

        }
    }
}
