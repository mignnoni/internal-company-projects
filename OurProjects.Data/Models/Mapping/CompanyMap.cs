using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OurProjects.Data.Models.Mapping
{
    public sealed class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("company");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("createdAt").IsRequired();
            builder.Property(x => x.Idle).HasColumnName("idle").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(200).IsRequired();
        }
    }
}
