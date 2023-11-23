using API.Models.Domain;
using API.Models.DTO;
using API.Repositories.Interface;
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
                Password = request.Password,
            };



            if (await _userRepository.AuthenticateAsync(userlogin) == null)
            {
                return NotFound(new { Message = "User not found!" });
            }
            else
            {
                var response = new User
                {
                    Email = userlogin.Email,
                    Password = userlogin.Password,
                    Token = "vmitoken",
                };


                return Ok(response);
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

            var response = new RegisterUserDTO
            {
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                UserName = registerUser.UserName,
                Role = registerUser.Role,
                Email = registerUser.Email,
                Password = registerUser.Password,
            };

            return Ok(response);
        }


    }
}
