using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore.Data
{
    public class ApplicationContext : DbContext
    {
        private static readonly ILoggerFactory logger = LoggerFactory.Create(log => log.AddConsole());
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(logger)
                .EnableSensitiveDataLogging() //habilita mostrar os parametros gerados pelo entity framework
                .UseSqlServer("Server=localhost,1433;Database=developer;User Id=sa;Password=1wi46sS@;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
