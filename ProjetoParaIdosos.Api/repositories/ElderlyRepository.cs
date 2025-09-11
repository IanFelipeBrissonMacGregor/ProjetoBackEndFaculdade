using Microsoft.EntityFrameworkCore;
using ProjetoBackEnd.Api.Data;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;

namespace ProjetoBackEnd.Api.Repositories
{
    public class ElderlyRepository : IElderlyRepository
    {
        private readonly AppDbContext _ctx;
        public ElderlyRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<Elderly?> GetByIdAsync(int id) => await _ctx.Elderlies.FindAsync(id);

        public async Task<IEnumerable<Elderly>> GetAllAsync() => await _ctx.Elderlies.ToListAsync();

        public async Task AddAsync(Elderly elderly)
        {
            await _ctx.Elderlies.AddAsync(elderly);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Elderly elderly)
        {
            _ctx.Elderlies.Update(elderly);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await GetByIdAsync(id);
            if (e is null) return;
            _ctx.Elderlies.Remove(e);
            await _ctx.SaveChangesAsync();
        }
    }
}
