using BECase.Common.Entities.Common;
using BECase.Data.Models;

namespace BECase.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<Response> CreateAsync(Customer request);

        Task<DataResponse<Customer>> GetAsync(string id);
    }
}
