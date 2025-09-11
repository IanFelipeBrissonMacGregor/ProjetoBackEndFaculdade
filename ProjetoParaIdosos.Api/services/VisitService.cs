using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using ProjetoBackEnd.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _repo;
        public VisitService(IVisitRepository repo) => _repo = repo;

        public Task<Visit?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<IEnumerable<Visit>> GetAllAsync() => _repo.GetAllAsync();
        public async Task<Visit> CreateAsync(Visit visit)
        {
            await _repo.AddAsync(visit);
            return visit;
        }
        public Task UpdateAsync(Visit visit) => _repo.UpdateAsync(visit);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
