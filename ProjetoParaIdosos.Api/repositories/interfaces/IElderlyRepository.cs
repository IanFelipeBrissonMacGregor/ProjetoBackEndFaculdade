using ProjetoBackEnd.Api.Models;

namespace ProjetoBackEnd.Api.Repositories.Interfaces
{
    public interface IElderlyRepository
    {
        Task<Elderly?> GetByIdAsync(int id);
        Task<IEnumerable<Elderly>> GetAllAsync();
        Task AddAsync(Elderly elderly);
        Task UpdateAsync(Elderly elderly);
        Task DeleteAsync(int id);
    }
}
