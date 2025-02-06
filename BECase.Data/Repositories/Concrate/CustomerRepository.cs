using BECase.Data.Context;
using BECase.Data.Models;
using BECase.Data.Repositories.Abstract;

namespace BECase.Data.Repositories.Concrate
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
