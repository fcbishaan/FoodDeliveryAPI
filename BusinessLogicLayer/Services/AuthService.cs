using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vashishth_Backened._24.Data;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Models;
using Microsoft.EntityFrameworkCore;
namespace Vashishth_Backened._24.Services
{
    public class AuthService : IAuthService
    {
        private readonly FoodDeliveryContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(FoodDeliveryContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Register method (returns JWT token)
        public async Task<string> Register(RegisterRequest request)
        {
            if (await UserExists(request.Email))  // Check if email already exists
                throw new Exception("Email is already in use.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);  // Hash password

            var user = new User
            {
                FullName = request.FullName,
                PasswordHash = passwordHash,
                Email = request.Email,
                Address = request.Address,
                BirthDate = request.BirthDate,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber
            };

            _context.Users.Add(user);  // Add user to database
            await _context.SaveChangesAsync();

            return GenerateJwtToken(user);  // Generate and return JWT token
        }
        public async Task<bool> UserExists(string email)
        {
            // Query the database to check if a user with the given email exists
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                Audience = _configuration["Jwt:Audience"],
                Issuer = _configuration["Jwt:Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> Login(LoginRequest loginRequest)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=> u.Email == loginRequest.Email);
            if(user == null)
            {
                throw new Exception("Invalid Email or Password.");
            }
            if(!BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash))
            {
                throw new Exception ("Invalid Email or password.");
            }
            return GenerateJwtToken(user);
        }
        public async Task <UserProfileResponse> GetUserProfile (int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if(user == null)
            {
                throw new Exception("user not found.");
            }
            return new UserProfileResponse
            {
                
                FullName = user.FullName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                Gender = user.Gender,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
            };
        }
    }
}