using BECase.Business.Interfaces;
using BECase.Common.BaseController;
using BECase.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BECase.API.Controllers.api.v1
{
    /// <summary>
    /// Controller for managing customers.
    /// </summary>
    [Route("/api/v1/customer")]
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Controller for create Customer
        /// </summary>
        /// <param name="request">The customer request.</param>
        /// <returns>A result indicating the outcome of the operation.</returns>
        [HttpPost("")]
        public async Task<IActionResult> Create(Customer request)
        {
            var serviceResult = await _customerService.CreateAsync(request);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Message);
            }

            return Ok(serviceResult);
        }

        /// <summary>
        /// Controller for get Customer
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <returns>A result indicating the outcome of the operation.</returns>
        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var serviceResult = await _customerService.GetAsync(id);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Message);
            }

            return Ok(serviceResult);
        }

        
    }
}
