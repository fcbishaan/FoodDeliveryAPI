using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Vashishth_Backened._24.Dto
{
    public class RegisterRequest
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*\d).+$", ErrorMessage = "Password must contain at least one digit.")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Address must be at least 10 characters long.")]
        public string Address { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}$", ErrorMessage = "Phone number must be in the format +7 (xxx) xxx-xx-xx.")]
        public string PhoneNumber { get; set; }

        public string Role { get; set; }  
    }
}