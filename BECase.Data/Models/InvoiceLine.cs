using BECase.Common.Entities.Common;

namespace BECase.Data.Models
{
    public class InvoiceLine : BaseEntity
    {
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public Guid? UserId { get; set; }
        public Guid? InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

    }
}
