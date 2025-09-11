using Microsoft.EntityFrameworkCore;
using ProjetoBackEnd.Api.Models;

namespace ProjetoBackEnd.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Elderly> Elderlies { get; set; }
    }
}
