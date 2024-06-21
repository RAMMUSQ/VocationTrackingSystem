﻿using Core.Entities;
using System.Threading.Tasks;

namespace WebApplication5.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
        Task<bool> ValidateTokenAsync(string tokenValue);
        Task SaveTokenAsync(Token token);
    }
}