using System.ComponentModel.DataAnnotations;

namespace Vashishth_Backened._24.Dto
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must include both letters and numbers.")]
        public string Password { get; set; }
    }
}
