using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using ProjetoBackEnd.Api.Services.Interfaces;

namespace ProjetoBackEnd.Api.Services
{
    public class ElderlyService : IElderlyService
    {
        private readonly IElderlyRepository _repo;
        public ElderlyService(IElderlyRepository repo) => _repo = repo;

        public Task<Elderly?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<IEnumerable<Elderly>> GetAllAsync() => _repo.GetAllAsync();

        public async Task<Elderly> CreateAsync(Elderly elderly)
        {
            await _repo.AddAsync(elderly);
            return elderly;
        }

        public Task UpdateAsync(Elderly elderly) => _repo.UpdateAsync(elderly);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
