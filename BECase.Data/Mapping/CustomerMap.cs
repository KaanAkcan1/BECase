using BECase.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BECase.Data.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);

            builder.HasMany(c => c.Invoices)
                   .WithOne(i => i.Customer)
                   .HasForeignKey(i => i.CustomerId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
