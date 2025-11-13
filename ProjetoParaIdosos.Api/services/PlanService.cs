using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using ProjetoBackEnd.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _repo;
        public PlanService(IPlanRepository repo) => _repo = repo;

        public Task<IEnumerable<Plan>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Plan?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public async Task<Plan> CreateAsync(Plan plan)
        {
            await _repo.AddAsync(plan);
            return plan;
        }

        public Task UpdateAsync(Plan plan) => _repo.UpdateAsync(plan);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
