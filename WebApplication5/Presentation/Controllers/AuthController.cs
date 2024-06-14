using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Services;
using WebApplication5.Interfaces;
using Core.Entities;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(IUserService userService, ITokenService tokenService, ITokenRepository tokenRepository)
        {
            _userService = userService;
            _tokenService = tokenService;
            _tokenRepository = tokenRepository;
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

            // Token'ı veritabanına kaydet
            var tokenModel = new Token
            {
                Value = token,
                UserId = user.Id, // User sınıfınızda Id property'si olduğundan emin olun
                Expiration = DateTime.UtcNow.AddHours(5) // Örneğin, 1 saat geçerli
            };

            await _tokenRepository.CreateTokenAsync(tokenModel);

            return Ok(new { Token = token });
        }
    }
}