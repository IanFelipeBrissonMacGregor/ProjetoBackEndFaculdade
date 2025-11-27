using ProjetoBackEnd.Api.Models;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(string username, string password);
        Task<string?> LoginAsync(string username, string password);
    }
}
