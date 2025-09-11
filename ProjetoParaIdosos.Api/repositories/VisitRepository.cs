using Microsoft.EntityFrameworkCore;
using ProjetoBackEnd.Api.Data;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly AppDbContext _ctx;
        public VisitRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<Visit?> GetByIdAsync(int id) =>
            await _ctx.Visits
                .Include(v => v.Dependent)
                    .ThenInclude(d => d.Partner)
                .FirstOrDefaultAsync(v => v.Id == id);

        public async Task<IEnumerable<Visit>> GetAllAsync() =>
            await _ctx.Visits
                .Include(v => v.Dependent)
                    .ThenInclude(d => d.Partner)
                .ToListAsync();

        public async Task AddAsync(Visit visit)
        {
            await _ctx.Visits.AddAsync(visit);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Visit visit)
        {
            _ctx.Visits.Update(visit);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var v = await GetByIdAsync(id);
            if (v != null)
            {
                _ctx.Visits.Remove(v);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
