using BECase.Business.Interfaces;
using BECase.Common.BaseController;
using BECase.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BECase.API.Controllers.api.v1
{
    [Route("/api/v1/customer")]
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
