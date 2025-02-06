using BECase.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BECase.Data.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");

            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.Customer)
              .WithOne()
              .HasForeignKey<Customer>(c => c.UserId)
              .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.Invoices)
                   .WithOne()
                   .HasForeignKey(i => i.UserId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
