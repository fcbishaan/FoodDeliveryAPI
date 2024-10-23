using System.ComponentModel.DataAnnotations;
using Vashishth_Backened._24.Models;
namespace Vashishth_Backened._24.Dto;
public class UserEdit
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
}
