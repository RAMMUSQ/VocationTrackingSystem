using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

namespace WebApplication5.Middlewares
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public TokenValidationMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var token = context.Request.Headers["Authorization"].ToString().Split(" ").Last();
                var handler = new JwtSecurityTokenHandler();

                if (handler.CanReadToken(token))
                {
                    var jwtToken = handler.ReadJwtToken(token);

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                        var storedToken = await dbContext.StoredTokens
                            .FirstOrDefaultAsync(t => t.Token == token && t.Expiration > DateTime.UtcNow);

                        if (storedToken == null)
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            await context.Response.WriteAsync("Invalid or expired token.");
                            return;
                        }

                        // JWT token'dan kullanıcı adını al
                        var user = jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub)?.Value;

                        // Kullanıcı adı veritabanındaki ile eşleşmiyorsa hata döndür
                        if (storedToken.UserName != user)
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            await context.Response.WriteAsync("Token does not match the user.");
                            return;
                        }

                        // Kullanıcı adı ve token eşleşiyor
                        context.Response.StatusCode = StatusCodes.Status200OK;
                        await context.Response.WriteAsync("Giriş Başarılı");
                        return;
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Invalid token format.");
                    return;
                }
            }

            await _next(context);
        }
    }
}
