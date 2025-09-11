using ProjetoBackEnd.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Services.Interfaces
{
    public interface IDependentService
    {
        Task<Dependent?> GetByIdAsync(int id);
        Task<IEnumerable<Dependent>> GetAllAsync();
        Task<Dependent> CreateAsync(Dependent dependent);
        Task UpdateAsync(Dependent dependent);
        Task DeleteAsync(int id);
    }
}
