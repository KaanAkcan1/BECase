using BECase.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BECase.Data.Mapping
{
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.HasKey(x => x.Id);

            builder.HasMany(i => i.InvoiceLines)
                   .WithOne(il => il.Invoice)
                   .HasForeignKey(il => il.InvoiceId)
                   .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
