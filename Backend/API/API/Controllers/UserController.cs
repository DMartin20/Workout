using API.Models.Domain;
using API.Models.DTO;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserDTO request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            //dto to domain
            var userlogin = new User
            {
                Email = request.Email,
                Password = request.Password
            };

            var user = await _userRepository.AuthenticateAsync(userlogin);

            if (user == null)
            {
                return NotFound(new { Message = "User not found!" });
            }
            else
            {
                var response = new LoginDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = CreateJWT(user),
                    Role = user.Role,
                };

                return Ok(response);
            }

        }
        [Authorize]
        [HttpGet("getUserData/{userId}")]
        public async Task<IActionResult> GetUserData(int userId)
        {
            try
            {
                var user = await _userRepository.GetUserData(userId);
                var response = new UserResponseDTO
                {
                    Id = userId,
                    UserName = user.UserName,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    Email = user.Email,
                    Token = user.Token,
                    Role = user.Role,
                    Created = user.Created
                };
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal Server Error: {ex.Message}!");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO request)
        {
            var registerUser = new User
            {
                Email = request.Email,
                Password = request.Password,
                LastName = request.LastName,
                FirstName = request.FirstName,
                UserName = request.UserName,
                Role = "User",
                Created = DateTime.UtcNow
            };

            await _userRepository.RegisterAsync(registerUser);


            return Ok(new
            {
                Message = "User Registered!"
            });
        }

        private string CreateJWT(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("secretkey12345678");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
