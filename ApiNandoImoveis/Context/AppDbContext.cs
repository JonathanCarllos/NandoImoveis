using ApiNandoImoveis.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiNandoImoveis.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Imovel> Imovels { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
