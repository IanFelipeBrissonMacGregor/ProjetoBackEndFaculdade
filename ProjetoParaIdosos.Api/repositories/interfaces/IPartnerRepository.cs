using ProjetoBackEnd.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Repositories.Interfaces
{
    public interface IPartnerRepository
    {
        Task<Partner?> GetByIdAsync(int id);
        Task<IEnumerable<Partner>> GetAllAsync();
        Task AddAsync(Partner partner);
        Task UpdateAsync(Partner partner);
        Task DeleteAsync(int id);
    }
}
