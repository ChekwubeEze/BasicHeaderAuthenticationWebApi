using Basic.Auth.Core.Interfaces.UserInterfaces;
using Basic.Auth.Core.ModelsDto;
using Basic.Auth.Models;
using BasicAtWebApiAuthentication.Applications;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BasicAtWebApiAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto request)
        {
            var validate = new NullReferenceAbstractValidator<CreateUserDto>();
            var success = await validate.ValidateAsync(request);
            if (!success.IsValid)
            {
                return BadRequest("Invalid");
            }
             await _userInterface.Register(request);
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLoginDto loginDto)
        {
            var validate = new NullReferenceAbstractValidator<UserLoginDto>();
            var success = await validate.ValidateAsync(loginDto);
            if (!success.IsValid)
            {
                return BadRequest("Invalid");
            }
            var message = _userInterface.LogIn(loginDto);
            return Ok(message);
        }
    }
}
