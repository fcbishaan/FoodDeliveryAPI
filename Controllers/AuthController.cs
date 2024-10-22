using Microsoft.AspNetCore.Mvc;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Vashishth_Backened._24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
               
                var token = await _authService.Register(request);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Email is already in use.")
                {
                    return BadRequest(new { message = "Email is already in use." });
                }

                
                return StatusCode(500, new { message = "An error occurred during registration." });
            }
        }
          [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var token = await _authService.Login(request);
                return Ok(new { token });
            }
            catch (Exception ex) 
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            return Ok( new {message = "Logged out Successfully."});
        }
        [HttpGet("profile")]
        [Authorize]
        //[AllowAnonymous]
        public async Task<IActionResult> GetUserProfile()
        {
             var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
             //Console.WriteLine($"----------------------{userIdClaim}");
             if (userIdClaim == null) //|| !Guid.TryParse(userIdClaim, out Guid userId))
             {
              return BadRequest(new { message = "Invalid user ID." });
             }

              try
             {
               var profile = await _authService.GetUserProfile(int.Parse(userIdClaim));
               return Ok(profile);
             }
              catch (Exception ex)
             {
               return BadRequest(new { message = ex.Message });
             }
         }
    }
}
