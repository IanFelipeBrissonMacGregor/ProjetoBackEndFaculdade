using Microsoft.EntityFrameworkCore;
using ProjetoBackEnd.Api.Data;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly AppDbContext _ctx;
        public PartnerRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<Partner?> GetByIdAsync(int id) =>
            await _ctx.Partners.Include(p => p.Dependents).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Partner>> GetAllAsync() =>
            await _ctx.Partners.Include(p => p.Dependents).ToListAsync();

        public async Task AddAsync(Partner partner)
        {
            await _ctx.Partners.AddAsync(partner);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Partner partner)
        {
            _ctx.Partners.Update(partner);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var p = await GetByIdAsync(id);
            if (p != null)
            {
                _ctx.Partners.Remove(p);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
