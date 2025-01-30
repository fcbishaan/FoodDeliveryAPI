using Vashishth_Backened._24.Models;
using Vashishth_Backened._24.Dto;
using System.Threading.Tasks;

namespace Vashishth_Backened._24.Services
{
    public interface IAuthService
    {
       
        Task<string> Register(RegisterRequest rыegisterRequest, bool IsAdmin);

        Task<bool> UserExists(string email);

        Task<string> Login (LoginRequest loginRequest);

        Task<UserProfileResponse> GetUserProfile (Guid userId);

        Task <Response> editUser (UserEdit userEdit);
        Task<bool> logoutToken(string token);
        Task DeleteAllUserAsync ();
    }
}
