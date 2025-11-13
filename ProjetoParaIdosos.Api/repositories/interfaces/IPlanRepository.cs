using ProjetoBackEnd.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Repositories.Interfaces
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetAllAsync();
        Task<Plan?> GetByIdAsync(int id);
        Task AddAsync(Plan plan);
        Task UpdateAsync(Plan plan);
        Task DeleteAsync(int id);
    }
}
