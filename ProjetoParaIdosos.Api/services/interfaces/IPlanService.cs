using ProjetoBackEnd.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Services.Interfaces
{
    public interface IPlanService
    {
        Task<IEnumerable<Plan>> GetAllAsync();
        Task<Plan?> GetByIdAsync(int id);
        Task<Plan> CreateAsync(Plan plan);
        Task UpdateAsync(Plan plan);
        Task DeleteAsync(int id);
    }
}
