using Microsoft.AspNetCore.Mvc;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Vashishth_Backened._24.Models;

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
        [ProducesResponseType (200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                 return BadRequest(new { message = "Invalid input data.", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

            try
            {
                 Console.WriteLine($"Incoming role: {request.Role}");
                if(string.IsNullOrEmpty(request.Role)||(request.Role!=Role.Administrator && request.Role != Role.User))
                {
                    request.Role = Role.User;
                }
                bool isAdmin = request.Role == Role.Administrator;
                var token = await _authService.Register(request, isAdmin);
                return Ok(new { token });
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Email is already in use"))
            {
                return Conflict(new { message = "Email is already in use." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during registration.", details = ex.Message });
            }
        }

        [HttpPost("login")]
        [ProducesResponseType (200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid input data." });

            try
            {  var token = await _authService.Login(request);
                 if (token == null)
            return NotFound(new { message = "User not found." });
        return Ok(new { token });
            }
           
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("logout")]
        [Authorize(Policy = "AnyAuthenticatedUser")]
        [ProducesResponseType(typeof(StorageToken), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> Logout()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "Please log in to the system first." });

            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(userEmail))
                return BadRequest(new { message = "User email not found in token." });

            try
            {
               var isSuccess = await _authService.logoutUser(userEmail);
        if (!isSuccess)
            return NotFound(new { message = "User not found." });
        return Ok(new { message = "Logged out successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while logging out.", details = ex.Message });
            }
        }

        [HttpGet("profile")]
        [Authorize]
        [ProducesResponseType (200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> GetUserProfile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out Guid userGuid))
                return BadRequest(new { message = "Invalid user ID." });

            try
            {
                var profile = await _authService.GetUserProfile(userGuid);
        if (profile == null)
            return NotFound(new { message = "User profile not found." });
        return Ok(profile);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("profile")]
        [Authorize]
        [ProducesResponseType (200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> EditProfile([FromBody] UserEdit userEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid input data." });

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "Please log in to the system first." });

            try
            {
                var result = await _authService.editUser(userEdit);
                  if (result == null)
            return NotFound(new { message = "User not found." });
                 return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = "Invalid operation: " + ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An internal server error occurred.", details = ex.Message });
            }
        }
        [HttpDelete("reset-users")]
        public async Task <IActionResult> ResetUsers()
        {
            await _authService.DeleteAllUserAsync();
            return Ok (new {message = "All users have been deleted"});
        }
    }
}
