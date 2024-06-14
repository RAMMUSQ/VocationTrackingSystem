using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _userService.RegisterAsync(model);
            if (result)
            {
                return Ok(new { Message = "User registered successfully" });
            }
            return BadRequest(new { Message = "User registration failed" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userService.ValidateUserAsync(model.Username, model.Password);

            if (user == null)
                return Unauthorized(new { Message = "Invalid credentials" });

            var token = _tokenService.GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}