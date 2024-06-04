using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ApplicationDbContext _context;
        private IConfiguration _config;

        public LoginController(ILogger<LoginController> logger, ApplicationDbContext context,
            IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _config = configuration;
        }

        [HttpPost("KAYIT-OL")]
        public async Task Post(User user)
        {
            string json = JsonConvert.SerializeObject(user);
            var signupUser = JsonConvert.DeserializeObject<User>(json);
           
            user.CreatedDate = DateTime.Now;
            user.UpdatedDate = DateTime.Now;

            await _context.Users.AddAsync(signupUser);
            await _context.SaveChangesAsync();
        }
        
        [HttpPost("Giriş-yap")]
        public async Task<IActionResult> SignIn([FromBody] Auth auth)
        {
            // Kullanıcı adı ve şifre ile veritabanında kullanıcıyı bul
                var user = await _context.Users.FirstOrDefaultAsync(s =>
                s.UserName == auth.UserName && s.Password == auth.Password);

            if ( user == null)
            {
                return Unauthorized("Kullanıcı adı veya şifre yanlış.");
            }

            var tokenString = GenerateJwtToken(user.UserName);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadToken(tokenString) as JwtSecurityToken;

            var storedToken = new StoredTokens
            {
                Token = tokenString,
                Expiration = token.ValidTo,
                UserName = user.UserName,
                Password = user.Password,
                CreatedDate = DateTime.Now 
            };

            await _context.StoredTokens.AddAsync(storedToken);
            await _context.SaveChangesAsync();

            return Ok(new { token = tokenString });
        }

        private string GenerateJwtToken(string user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user),
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

        



       /* [HttpPost("Deneme")]
        public IActionResult Deneme()
        {
            return Ok();
        }

        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Jwt:Key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.UtcNow.AddHours(1), // Token süresi, isteğe bağlı olarak ayarlayabilirsiniz
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }*/

    }
}
