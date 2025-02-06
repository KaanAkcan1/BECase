using BECase.Common.Entities.Common;

namespace BECase.Data.Models
{
    public class Invoice : BaseEntity
    {        
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double TotalAmount { get; set; }
        public Customer? Customer { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? UserId { get; set; }
        public List<InvoiceLine>? InvoiceLines { get; set; }
    }
}
