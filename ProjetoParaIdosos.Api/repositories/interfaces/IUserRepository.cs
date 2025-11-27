using ProjetoBackEnd.Api.Models;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
    }
}
