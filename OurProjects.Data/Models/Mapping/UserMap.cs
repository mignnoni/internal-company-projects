using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OurProjects.Data.Models.Mapping
{
    public sealed class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(one => one.Company)
                .WithMany(many => many.Users)
                .HasForeignKey(fk => fk.IdCompany)
                .HasConstraintName("FK_user_company")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
