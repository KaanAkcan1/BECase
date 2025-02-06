using BECase.Business.Models.JwtRefreshToken;
using BECase.Business.Models.Requests.AppUser;
using BECase.Common.Entities.Common;

namespace BECase.Business.Interfaces
{
    public interface IAppUserService
    {
        Task<DataResponse<JwtToken>> LoginAsync(LoginRequestDto request);
        Task<DataResponse<JwtToken>> ValidateTokenAsync(string accessToken, string refreshToken);
    }
}
