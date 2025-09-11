using Microsoft.EntityFrameworkCore;
using ProjetoBackEnd.Api.Models;

namespace ProjetoBackEnd.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Partner> Partners { get; set; } = null!;
        public DbSet<Dependent> Dependents { get; set; } = null!;
        public DbSet<Visit> Visits { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Partner -> Dependent (1:N)
            modelBuilder.Entity<Partner>()
                .HasMany(p => p.Dependents)
                .WithOne(d => d.Partner)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Dependent -> Visit (1:N)
            modelBuilder.Entity<Dependent>()
                .HasMany(d => d.Visits)
                .WithOne(v => v.Dependent)
                .HasForeignKey(v => v.DependentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
