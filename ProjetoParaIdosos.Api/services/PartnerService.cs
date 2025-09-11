using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using ProjetoBackEnd.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _repo;
        public PartnerService(IPartnerRepository repo) => _repo = repo;

        public Task<Partner?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<IEnumerable<Partner>> GetAllAsync() => _repo.GetAllAsync();
        public async Task<Partner> CreateAsync(Partner partner)
        {
            await _repo.AddAsync(partner);
            return partner;
        }
        public Task UpdateAsync(Partner partner) => _repo.UpdateAsync(partner);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
