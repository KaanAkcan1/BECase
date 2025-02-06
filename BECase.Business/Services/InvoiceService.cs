using BECase.Business.Interfaces;
using BECase.Business.Models.Requests.Invoice;
using BECase.Common.Core;
using BECase.Common.Entities.Common;
using BECase.Common.Enums.Common;
using BECase.Data.Models;
using BECase.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BECase.Business.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> CreateAsync(Invoice request)
        {
            var result = new Response();

            var repositoryResult = await _unitOfWork.invoiceRepository.CreateAsync(request);

            if (repositoryResult != null && repositoryResult.Data != null && repositoryResult.Success)
                result.SetSuccess();
            else
                result.SetError(repositoryResult?.Message ?? "error");

            return result;
        }

        public async Task<Response> UpdateAsync(Invoice request)
        {
            var result = new Response();

            var repositoryResult = await _unitOfWork.invoiceRepository.CreateUpdateAsync(request);

            if (repositoryResult != null && repositoryResult.Data != null && repositoryResult.Success)
                result.SetSuccess();
            else
                result.SetError(repositoryResult?.Message ?? "error");

            return result;
        }

        public async Task<DataResponse<Invoice>> GetAsync(string id)
        {
            var result = new DataResponse<Invoice>();

            var repositoryResult = await _unitOfWork.invoiceRepository.FindAll(x => x.Id == Guid.Parse(id))
                .Include(c => c.InvoiceLines)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync();

            if (repositoryResult != null)
                result.SetRecordFounded(repositoryResult);
            else
                result.SetRecordCouldNotFound();

            return result;
        }

        public async Task<DataResponse<List<Invoice>>> GetInvoiceListAsync(GetInvoiceListRequestDto request)
        {
            var result = new DataResponse<List<Invoice>>();

            Expression<Func<Invoice, bool>> exp = x => x.StatusId == (int)EntityStatus.Active;

            if (request.StartDate != null)
            {
                exp = exp.And(x => x.InvoiceDate >= request.StartDate);
            }

            if(request.EndDate != null)
            {
                exp = exp.And(x => x.InvoiceDate <= request.EndDate);
            }

            var repositoryResult = await _unitOfWork.invoiceRepository.FindAll(exp)
                .Include(c => c.InvoiceLines)
                .Include(c => c.Customer)
                .ToListAsync();

            if (repositoryResult != null)
                result.SetRecordFounded(repositoryResult);
            else
                result.SetRecordCouldNotFound();

            return result;
        }

        public async Task<DataResponse<Invoice>> DeleteAsync(string id)
        {
            var result = new DataResponse<Invoice>();

            var repositoryResult = await _unitOfWork.invoiceRepository.DeleteAsync(Guid.Parse(id), null);

            if (repositoryResult != null && repositoryResult.Data != null && repositoryResult.Success)
                result.SetSuccess(repositoryResult.Data.FirstOrDefault());
            else
                result.SetError(repositoryResult?.Message ?? "error");

            return result;
        }
    }
}
