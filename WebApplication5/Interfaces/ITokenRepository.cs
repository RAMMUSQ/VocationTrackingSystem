// Infrastructure/Repositories/ITokenRepository.cs

using Core.Entities;

namespace WebApplication5.Interfaces
{
    public interface ITokenRepository
    {
        Task AddAsync(Token token);
        Task<Token> CreateTokenAsync(Token token);
        Task<Token> GetTokenAsync(string tokenValue);
    }
}