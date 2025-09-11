using ProjetoBackEnd.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Repositories.Interfaces
{
    public interface IVisitRepository
    {
        Task<Visit?> GetByIdAsync(int id);
        Task<IEnumerable<Visit>> GetAllAsync();
        Task AddAsync(Visit visit);
        Task UpdateAsync(Visit visit);
        Task DeleteAsync(int id);
    }
}
