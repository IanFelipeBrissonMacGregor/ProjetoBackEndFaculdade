using ProjetoBackEnd.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Services.Interfaces
{
    public interface IVisitService
    {
        Task<Visit?> GetByIdAsync(int id);
        Task<IEnumerable<Visit>> GetAllAsync();
        Task<Visit> CreateAsync(Visit visit);
        Task UpdateAsync(Visit visit);
        Task DeleteAsync(int id);
    }
}
