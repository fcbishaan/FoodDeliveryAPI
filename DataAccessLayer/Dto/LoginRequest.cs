using System.ComponentModel.DataAnnotations;

namespace Vashishth_Backened._24.Dto
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        
        public string Password { get; set; }
    }
}
