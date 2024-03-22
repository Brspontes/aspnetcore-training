using DominandoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DominandoEFCore.Data
{
    public class ApplicationContextCidade : DbContext
    {
        private static readonly ILoggerFactory logger = LoggerFactory.Create(log => log.AddConsole());
        public DbSet<Cidade> Cidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(logger)
                .EnableSensitiveDataLogging() //habilita mostrar os parametros gerados pelo entity framework
                .UseSqlServer("Server=localhost,1433;Database=developer;User Id=sa;Password=1wi46sS@;pooling=true;");
        }
    }
}
