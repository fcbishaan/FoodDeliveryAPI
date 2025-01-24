using Vashishth_Backened._24.Dto;

namespace Vashishth_Backened._24.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }  
    }
}
