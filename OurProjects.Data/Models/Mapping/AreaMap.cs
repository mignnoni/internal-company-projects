using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OurProjects.Data.Models.Mapping
{
    public sealed class AreaMap : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("area");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.IdCompany).HasColumnName("idCompany").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("createdAt").IsRequired();
            builder.Property(x => x.Idle).HasColumnName("idle").IsRequired();
            builder.Property(x => x.Title).HasColumnName("title").HasMaxLength(150).IsRequired();

            builder
                .HasOne(one => one.Company)
                .WithMany(many => many.Areas)
                .HasForeignKey(fk => fk.IdCompany)
                .HasConstraintName("FK_area_company")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
