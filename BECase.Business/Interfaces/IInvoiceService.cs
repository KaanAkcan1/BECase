using BECase.Business.Models.Requests.Invoice;
using BECase.Common.Entities.Common;
using BECase.Data.Models;

namespace BECase.Business.Interfaces
{
    public interface IInvoiceService
    {
        Task<Response> CreateAsync(Invoice request);

        Task<Response> UpdateAsync(Invoice request);

        Task<DataResponse<Invoice>> GetAsync(string id);

        Task<DataResponse<List<Invoice>>> GetInvoiceListAsync(GetInvoiceListRequestDto request);

        Task<DataResponse<Invoice>> DeleteAsync(string id);

    }
}
