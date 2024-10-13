using System.ComponentModel.DataAnnotations;

namespace Vashishth_Backened._24.Models
{
    public class User{
        public Guid Id{get; set;}
        [Required]
        public string fullName{get; set;}
        public DateTime birthDate{get; set;}
        public string gender{get; set;}
        public string address {get; set;}
      //  public email email {get; set;}
        //public tel phoneNumber {get; set;}
    }

}