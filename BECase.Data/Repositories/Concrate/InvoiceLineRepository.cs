using BECase.Data.Context;
using BECase.Data.Models;
using BECase.Data.Repositories.Abstract;

namespace BECase.Data.Repositories.Concrate
{
    public class InvoiceLineRepository : Repository<InvoiceLine>, IInvoiceLineRepository
    {
        public InvoiceLineRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
