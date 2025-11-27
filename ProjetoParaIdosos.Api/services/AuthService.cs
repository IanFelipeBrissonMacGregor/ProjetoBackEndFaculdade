using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using ProjetoBackEnd.Api.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthService(IUserRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public async Task<User> RegisterAsync(string username, string password)
        {
            var existing = await _repo.GetByUsernameAsync(username);
            if (existing != null)
                throw new InvalidOperationException("Usuário já existe");

            var user = new User { Username = username };
            user.PasswordHash = _hasher.HashPassword(user, password);

            await _repo.AddAsync(user);
            return user;
        }

        public async Task<string?> LoginAsync(string username, string password)
        {
            var user = await _repo.GetByUsernameAsync(username);
            if (user == null) return null;

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Failed) return null;

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var keyString = _config["Jwt:Key"];
            if (string.IsNullOrWhiteSpace(keyString))
                throw new InvalidOperationException("Chave JWT não configurada.");

            var key = Encoding.UTF8.GetBytes(keyString);
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
