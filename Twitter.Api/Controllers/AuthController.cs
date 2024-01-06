using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Business.Abstractions;
using Twitter.Business.Dtos.User;

namespace Twitter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService { get; init; }

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("/login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        { 
            return Ok(await _userService.Login(dto));
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(UserRegisterDto dto) 
        {
            return Ok(await _userService.Create(dto));
        }

    }
}
