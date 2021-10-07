using CursoEFCore.Data.Configurations;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CursoEFCore.Data
{
  public class AplicationContext : DbContext
  {
    private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
      dbContextOptionsBuilder
        .UseLoggerFactory(_logger)
        .EnableSensitiveDataLogging()
        .UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial Catalog=CursoEFCore;Integrated Security=true");

      base.OnConfiguring(dbContextOptionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ClienteConfiguration());
      modelBuilder.ApplyConfiguration(new PedidoConfiguration());
      modelBuilder.ApplyConfiguration(new PedidoItemConfiguration());
      modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
      //ou utilizar
      //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicationContext).Assembly);
    }
  }
}