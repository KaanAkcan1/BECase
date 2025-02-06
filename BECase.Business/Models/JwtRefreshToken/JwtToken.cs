namespace BECase.Business.Models.JwtRefreshToken
{
    public class JwtToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long ExpiresIn { get; set; }
    }
}
