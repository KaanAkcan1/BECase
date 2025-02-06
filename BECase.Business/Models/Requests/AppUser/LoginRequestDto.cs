using System.ComponentModel.DataAnnotations;

namespace BECase.Business.Models.Requests.AppUser
{
    public class LoginRequestDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
