namespace BECase.Business.Models.Requests.AppUser
{
    public class ValidateTokenRequestDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
