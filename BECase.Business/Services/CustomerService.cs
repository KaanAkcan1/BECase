using BECase.Business.Interfaces;
using BECase.Common.Entities.Common;
using BECase.Data.Models;
using BECase.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BECase.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> CreateAsync(Customer request)
        {
            var result = new Response();

            var repositoryResult = await _unitOfWork.customerRepository.CreateAsync(request);

            if (repositoryResult != null && repositoryResult.Data != null && repositoryResult.Success)
                result.SetSuccess();
            else
                result.SetError(repositoryResult?.Message ?? "error");

            return result;
        }

        public async Task<DataResponse<Customer>> GetAsync(string id)
        {
            var result = new DataResponse<Customer>();

            var repositoryResult = await _unitOfWork.customerRepository.FindAll(x => x.Id == Guid.Parse(id))
                .Include(c => c.Invoices)
                //.ThenInclude(s => s.Items)
                .FirstOrDefaultAsync();

            if (repositoryResult != null)
                result.SetRecordFounded(repositoryResult);
            else
                result.SetRecordCouldNotFound();

            return result;
        }


    }
}
