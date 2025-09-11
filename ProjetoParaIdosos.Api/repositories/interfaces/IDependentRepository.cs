using ProjetoBackEnd.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Repositories.Interfaces
{
    public interface IDependentRepository
    {
        Task<Dependent?> GetByIdAsync(int id);
        Task<IEnumerable<Dependent>> GetAllAsync();
        Task AddAsync(Dependent dependent);
        Task UpdateAsync(Dependent dependent);
        Task DeleteAsync(int id);
    }
}
