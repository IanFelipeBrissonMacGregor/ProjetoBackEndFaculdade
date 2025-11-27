using Microsoft.EntityFrameworkCore; 
using ProjetoBackEnd.Api.Data;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using ProjetoBackEnd.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly AppDbContext _context; 

        public PartnerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Partner>> GetAllAsync()
        {
            return await _context.Partners
                .Include(p => p.Dependents)
                    .ThenInclude(d => d.Visits)
                .ToListAsync();
        }

        public async Task<Partner?> GetByIdAsync(int id)
        {
            return await _context.Partners
                .Include(p => p.Dependents)
                    .ThenInclude(d => d.Visits)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Partner> CreateAsync(Partner partner)
        {
            _context.Partners.Add(partner);
            await _context.SaveChangesAsync();
            return partner;
        }

        public async Task UpdateAsync(Partner partner)
        {
            _context.Partners.Update(partner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var partner = await _context.Partners.FindAsync(id);
            if (partner != null)
            {
                _context.Partners.Remove(partner);
                await _context.SaveChangesAsync();
            }
        }
    }
}
