using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Saitynai.Classes;
using Saitynai.DTO;
using Saitynai.Helpers;
using Saitynai.Models;

namespace Saitynai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        private DataContext _dataContext;

        public AuthController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _dataContext = context;
        }

        [HttpPost("register")]
        public async Task<ObjectResult> Register(UserDto request)
        {
            var user1 = _dataContext.Users.Find(request.Username);
            if (user1 != null)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Username already exists");
            }
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            
            User user = new User()
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt, 
                Categories = new List<Category>(),
                Role = Role.User
            };

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return StatusCode((int)HttpStatusCode.Created, "");
        }

        [HttpPost("login")]
        public async Task<ObjectResult> Login(UserDto request)
        {
            var user = _dataContext.Users.Find(request.Username);

            if (user == null)
            {
                return BadRequest("User does not exists");
            }

            if (user.Username != request.Username)
            {
                // TODO test 
                return StatusCode((int)HttpStatusCode.Forbidden, "User not found.");
            }
            
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                // TODO test 
                return StatusCode((int)HttpStatusCode.Forbidden, "Wrong password");
            }
            
            string token = CreateToken(user);
            
            return Ok(token);
        }
        
        [HttpGet("token"), Authorize]
        public async Task<IActionResult> Token()
        {
            var user = GetCurrentUser();

            if (user == null)
            {
                return BadRequest("User does not exists");
            }

            // TODO maybe use token to create new token
            
            string token = CreateToken(user);
            
            return Ok(token);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            // Or here payload
            List<Claim> claims = new List<Claim>()
            {
                new Claim("username", user.Username),
                new Claim("role", user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            // TODO add here jwt payload
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(5), // expires in 5 minutes
                signingCredentials: creds
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private User GetCurrentUser()
        {
            if(_dataContext == null)
            {
                throw new Exception("_dataContext is null");
            }

            if (User == null)
            {
                throw new Exception("User does not found");
            }

            return _dataContext.Users.Find(User);
        }
    }
}