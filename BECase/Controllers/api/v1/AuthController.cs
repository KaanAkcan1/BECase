using BECase.Business.Interfaces;
using BECase.Business.Models.Requests.AppUser;
using BECase.Common.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BECase.API.Controllers.api.v1
{
    [Route("/api/v1/auth")]
    public class AuthController : BaseApiController
    {
        private readonly IAppUserService _appUserService;

        public AuthController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        /// <summary>
        /// A controller used to login.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var loginResult = await _appUserService.LoginAsync(request);

            if (!loginResult.Success)
            {
                return Unauthorized(loginResult.Message);
            }

            return Ok(loginResult);
        }

        /// <summary>
        /// A controller used to validate token 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("validate")]
        public async Task<IActionResult> ValidateToken(ValidateTokenRequestDto request)
        {
            var serviceResult = await _appUserService.ValidateTokenAsync(request.AccessToken, request.RefreshToken);

            if (!serviceResult.Success)
            {
                return Unauthorized(serviceResult.Message);
            }

            return Ok(serviceResult);
        }
    }
}
