using BECase.Business.Interfaces;
using BECase.Business.Models.Requests.Invoice;
using BECase.Common.BaseController;
using BECase.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BECase.API.Controllers.api.v1
{
    /// <summary>
    /// Controller for managing invoices.
    /// </summary>
    [Route("/api/v1/invoice")]
    public class InvoiceController : BaseApiController
    {
        private readonly IInvoiceService _invoiceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceController"/> class.
        /// </summary>
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        /// <summary>
        /// Controller for create Invoice
        /// </summary>
        /// <param name="request">The invoice request.</param>
        /// <returns>A result indicating the outcome of the operation.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Invoice request)
        {
            var serviceResult = await _invoiceService.CreateAsync(request);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Message);
            }

            return Ok(serviceResult);
        }

        /// <summary>
        /// Controller for update Invoice
        /// </summary>
        /// <param name="request">The invoice request.</param>
        /// <returns>A result indicating the outcome of the operation.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Invoice request)
        {
            var serviceResult = await _invoiceService.UpdateAsync(request);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Message);
            }

            return Ok(serviceResult);
        }

        /// <summary>
        /// Controller for get Invoice
        /// </summary>
        /// <param name="id">The invoice id.</param>
        /// <returns>A result indicating the outcome of the operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string id)
        {
            var serviceResult = await _invoiceService.GetAsync(id);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Message);
            }

            return Ok(serviceResult);
        }

        /// <summary>
        /// Controller for delete Invoice
        /// </summary>
        /// <param name="id">The invoice id.</param>
        /// <returns>A result indicating the outcome of the operation.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] string id)
        {
            var serviceResult = await _invoiceService.DeleteAsync(id);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Message);
            }

            return Ok(serviceResult);
        }

        /// <summary>
        /// Controller for get Invoice list
        /// </summary>
        /// <param name="request">The invoice request.</param>
        /// <returns>A result indicating the outcome of the operation.</returns>
        [HttpPost("get-invoice-list")]
        public async Task<IActionResult> GetInvoiceListAsync(GetInvoiceListRequestDto request)
        {
            var serviceResult = await _invoiceService.GetInvoiceListAsync(request);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Message);
            }

            return Ok(serviceResult);
        }
    }
}
