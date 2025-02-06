using BECase.Data.Context;
using BECase.Data.Models;
using BECase.Data.Repositories.Abstract;

namespace BECase.Data.Repositories.Concrate
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
