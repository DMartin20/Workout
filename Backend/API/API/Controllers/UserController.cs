using API.Models.Domain;
using API.Models.DTO;
using API.Repositories.Interface;
using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
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



            if (await _userRepository.AuthenticateAsync(userlogin) == null)
            {
                return NotFound(new { Message = "User not found!" });
            }
            else
            {
                
                return Ok(new
                {
                    Message = "Login Success!"
                });
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
            };

            await _userRepository.RegisterAsync(registerUser);

            
            return Ok(new
            {
                Message = "User Reegistered!"
            });
        }


    }
}
