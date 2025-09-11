using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using ProjetoBackEnd.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Services
{
    public class DependentService : IDependentService
    {
        private readonly IDependentRepository _repo;
        public DependentService(IDependentRepository repo)
        {
            _repo = repo;
        }

        public Task<Dependent?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<IEnumerable<Dependent>> GetAllAsync() => _repo.GetAllAsync();
        public async Task<Dependent> CreateAsync(Dependent dependent)
        {
            await _repo.AddAsync(dependent);
            return dependent;
        }
        public Task UpdateAsync(Dependent dependent) => _repo.UpdateAsync(dependent);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
