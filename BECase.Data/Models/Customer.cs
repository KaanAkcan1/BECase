using BECase.Common.Entities.Common;

namespace BECase.Data.Models
{
    public class Customer : BaseEntity
    {
        public string TaxNumber { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public Guid? UserId { get; set; }
        public List<Invoice>? Invoices { get; set; }
    }
}
