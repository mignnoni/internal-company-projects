using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OurProjects.Data.Models.Mapping
{
    public sealed class TechnologyMap : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.ToTable("technology");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.IdCompany).HasColumnName("idCompany").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("createdAt").IsRequired();
            builder.Property(x => x.Idle).HasColumnName("idle").IsRequired();
            builder.Property(x => x.Title).HasColumnName("title").HasMaxLength(150).IsRequired();

            builder
                .HasOne(one => one.Company)
                .WithMany(many => many.Technologies)
                .HasForeignKey(fk => fk.IdCompany)
                .HasConstraintName("FK_technology_company")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
