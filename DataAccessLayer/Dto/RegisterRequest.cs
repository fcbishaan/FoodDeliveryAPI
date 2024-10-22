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
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
