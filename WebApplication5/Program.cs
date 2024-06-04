using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication5.Data;
using WebApplication5.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

IConfiguration configuration = builder.Configuration;
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conStr = builder.Configuration.GetConnectionString("MySqlConStr");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(conStr, ServerVersion.AutoDetect(conStr));
});

var app = builder.Build();

// Middleware'lerin eklenmesi
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<TokenValidationMiddleware>();

app.Use(async (context, next) =>
{
    // İstek öncesi işlemler
    Console.WriteLine($"İstek alındı: {context.Request.Path}");

    // Bir sonraki middleware'e (veya son işleme) geç
    await next();

    // Yanıt sonrası işlemler
    Console.WriteLine($"Yanıt gönderildi: {context.Response.StatusCode}");
});

app.MapControllers();

app.Run();