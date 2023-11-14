using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObject)
        {
            if (userObject == null)
            {
                return BadRequest();
            }
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.Email == userObject.Email && x.Password == userObject.Password
            );
            if (user == null)
            {
                return NotFound(new { Message = "User not found!" });
            }

            return Ok(new { Message = "Login success!" });
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObject)
        {
            if (userObject == null)
            {
                return BadRequest();
            }

            await _authContext.Users.AddAsync(userObject);
            await _authContext.SaveChangesAsync();

            return Ok(new { Message = "Registered!" });

        }

    }
}
