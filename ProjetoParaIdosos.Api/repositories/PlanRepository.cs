using Microsoft.EntityFrameworkCore;
using ProjetoBackEnd.Api.Data;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly AppDbContext _ctx;
        public PlanRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Plan>> GetAllAsync() =>
            await _ctx.Plans.ToListAsync();

        public async Task<Plan?> GetByIdAsync(int id) =>
            await _ctx.Plans.FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Plan plan)
        {
            await _ctx.Plans.AddAsync(plan);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Plan plan)
        {
            _ctx.Plans.Update(plan);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var p = await GetByIdAsync(id);
            if (p != null)
            {
                _ctx.Plans.Remove(p);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
