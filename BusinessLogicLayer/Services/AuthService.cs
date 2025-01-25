using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vashishth_Backened._24.Data;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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

        // Register method 
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

            string token = GenerateJwtToken(user);
            var storeToken = new StorageToken
            {
                id = Guid.NewGuid(),
                email = user.Email,
                token = token
            };

            _context.StorageTokens.Add(storeToken);
            await _context.SaveChangesAsync();
            return token;
        }
        
        public async Task <UserProfileResponse> GetUserProfile (Guid userId)
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
        public async Task<Response> editUser (UserEdit userEdit) 
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Email == userEdit.Email);
            if(user == null)
            {
                return new Response
                {
                    Status= "Failure",
                    Message = "User not found"
                };
            }
            user.FullName = userEdit.FullName;
            user.Address = userEdit.Address;
            user.BirthDate = userEdit.BirthDate;
            user.PhoneNumber = userEdit.PhoneNumber;

            await _context.SaveChangesAsync();

            return new Response
            {
                Status = "Success",
                Message = "User Updated successfully."
            };
        }
        
        public async Task<bool> logoutUser(string email)
     {
    try
    {
        var user = await _context.StorageTokens
            .FirstOrDefaultAsync(u => u.email.Equals(email, StringComparison.OrdinalIgnoreCase));

        if (user != null)
        {
             user.IsRevoked = true;
            _context.StorageTokens.Remove(user);
            await _context.SaveChangesAsync();
        }

        return true; // Return true regardless of whether the token was found or not.
    }
    catch (Exception ex)
    {
        throw new Exception("An error occurred while logging out.", ex);
    }
      }
  }

    
}