using Microsoft.EntityFrameworkCore;
using ProjetoBackEnd.Api.Data;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Repositories
{
    public class DependentRepository : IDependentRepository
    {
        private readonly AppDbContext _ctx;
        public DependentRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<Dependent?> GetByIdAsync(int id) =>
            await _ctx.Dependents
                .Include(d => d.Partner)
                .Include(d => d.Visits)
                .FirstOrDefaultAsync(d => d.Id == id);

        public async Task<IEnumerable<Dependent>> GetAllAsync() =>
            await _ctx.Dependents
                .Include(d => d.Partner)
                .Include(d => d.Visits)
                .ToListAsync();

        public async Task AddAsync(Dependent dependent)
        {
            await _ctx.Dependents.AddAsync(dependent);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Dependent dependent)
        {
            _ctx.Dependents.Update(dependent);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var d = await GetByIdAsync(id);
            if (d != null)
            {
                _ctx.Dependents.Remove(d);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
