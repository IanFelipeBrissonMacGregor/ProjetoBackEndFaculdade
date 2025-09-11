using ProjetoBackEnd.Api.Models;

namespace ProjetoBackEnd.Api.Services.Interfaces
{
    public interface IElderlyService
    {
        Task<Elderly?> GetByIdAsync(int id);
        Task<IEnumerable<Elderly>> GetAllAsync();
        Task<Elderly> CreateAsync(Elderly elderly);
        Task UpdateAsync(Elderly elderly);
        Task DeleteAsync(int id);
    }
}
