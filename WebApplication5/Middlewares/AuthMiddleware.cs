using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Services;

namespace WebApplication5.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthMiddleware> _logger;
        private readonly ITokenService _tokenService;

        public AuthMiddleware(RequestDelegate next, ILogger<AuthMiddleware> logger, ITokenService tokenService)
        {
            _next = next;
            _logger = logger;
            _tokenService = tokenService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value.ToLower();

            // Belirli yollar için kimlik doğrulama atlanır
            if (path == "/api/auth/register" || path == "/api/auth/login")
            {
                _logger.LogInformation("Skipping authentication for specific paths.");
                await _next(context);
                return;
            }

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                _logger.LogInformation("Token found in the request.");

                var isValidToken = await _tokenService.ValidateTokenAsync(token);

                if (isValidToken)
                {
                    _logger.LogInformation("Token is valid.");
                    await _next(context);
                    return;
                }
                else
                {
                    _logger.LogWarning("Invalid token.");
                }
            }
            else
            {
                _logger.LogWarning("Token is missing.");
            }

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized - bozuk yer burası");
        }
    }
}