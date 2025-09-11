using ProjetoBackEnd.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Services.Interfaces
{
    public interface IPartnerService
    {
        Task<Partner?> GetByIdAsync(int id);
        Task<IEnumerable<Partner>> GetAllAsync();
        Task<Partner> CreateAsync(Partner partner);
        Task UpdateAsync(Partner partner);
        Task DeleteAsync(int id);
    }
}
