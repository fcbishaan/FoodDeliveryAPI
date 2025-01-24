using System.Security.Principal;
namespace Vashishth_Backened._24.Models
{
public class StorageToken{
    public Guid id { get; set; }
    public string email {get; set;}
    public string token {get; set;}

    public DateTime CreatedAt { get; set; }
     public bool IsRevoked { get; set; }
}
}