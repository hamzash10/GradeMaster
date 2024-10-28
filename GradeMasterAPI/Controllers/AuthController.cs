using GradeMasterAPI.Controllers.DB;
using GradeMasterAPI.Controllers.DB.DBModels;
using GradeMasterAPI.DTOs;
using GradeMasterAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GradeMasterAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly GradeMasterDbContext _context;

        public AuthController(GradeMasterDbContext context) => _context = context;

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] TeacherRegisterDTO registerDto)
        {
            // check if email already exist
            if (await _context.Teachers.AnyAsync(t => t.Email == registerDto.Email))
            {
                return BadRequest("Email already in use.");
            }

            //create new teacher
            var teacher = new Teacher
            {
                Email = registerDto.Email,
                Password = HashPassword(registerDto.Password), // securely saving the password in the database
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PhoneNumber = registerDto.PhoneNumber
            };

            //add teacher to db
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return Ok("Teacher regestered successfully!");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            //check for existing email
            var teacher = await _context.Teachers.SingleOrDefaultAsync(t => t.Email == loginDto.Email);

            //check if the email dosent exist or the password is invalid 
            if (teacher == null)
                return Unauthorized("Invalid email");

            if(!VerifyPassword(loginDto.Password, teacher.Password))
                return Unauthorized("Invalid password");

            return Ok("Login successful!");
        }


        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Since JWTs are stateless, there's usually nothing to do here.
            // Just return a success response.
            return Ok("Logout successful!");
        }


        // Helper methods to hash and verify passwords
        private string HashPassword(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                var salt = hmac.Key;
                return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}"; 
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.'); 
            if (parts.Length != 2) return false;

            var storedSalt = Convert.FromBase64String(parts[0]);
            var storedHashBytes = Convert.FromBase64String(parts[1]);

            using (var hmac = new HMACSHA512(storedSalt)) 
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHashBytes);
            }
        }

    }
}
