using Microsoft.EntityFrameworkCore;
using ProjetoBackEnd.Api.Data;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _ctx;
        public UserRepository(AppDbContext ctx) => _ctx = ctx;

        public Task<User?> GetByUsernameAsync(string username) =>
            _ctx.Users.FirstOrDefaultAsync(u => u.Username == username);

        public Task<User?> GetByIdAsync(int id) =>
            _ctx.Users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task AddAsync(User user)
        {
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
        }
    }
}
