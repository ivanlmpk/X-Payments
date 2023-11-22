using Microsoft.EntityFrameworkCore;
using XPaymentsProject.Domain.Entities;

namespace XPaymentsProject.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento do Produto
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);

            // Mapeamento do Usuario
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
        }
    }
}
