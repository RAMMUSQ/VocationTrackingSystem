using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers;

[ApiController]
[Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly ILogger<AuthController> _logger;
            private readonly ApplicationDbContext _context;
            private readonly IConfiguration _config;

            public AuthController(ILogger<AuthController> logger, IConfiguration config, ApplicationDbContext context)
            {
                _logger = logger;
                _config = config;
                _context = context;
            }
[Authorize]
            [HttpPost("Giriş-yap")]
            public async Task<IActionResult> SignIn([FromBody] Auth auth)
            {
                // Kullanıcı adı ve şifre ile veritabanında kullanıcıyı bul
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == auth.UserName && u.Password == auth.Password);
                
                if (user == null)
                {
                    return Unauthorized("Kullanıcı adı veya şifre yanlış.");
                }

                var tokenString = GenerateJwtToken(user.UserName);
                return Ok(new { token = tokenString });
            }

            private string GenerateJwtToken(string userName)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }





        


