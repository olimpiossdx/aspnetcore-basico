using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Data
{
  public class AplicationContext : DbContext
  {
    public DbSet<Pedido> Pedido { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb;Inital Catalog=CursoEFCore;Integrated Security=true");
      base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Cliente>(p =>
      {
        p.ToTable("Clientes");
        p.HasKey(p => p.Id);
        p.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
        p.Property(p => p.Telefone).HasColumnType("CHAR(11)");
        p.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired();
        p.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
        p.Property(p => p.Cidade).HasMaxLength(60).IsRequired();

        p.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone");
      });

      modelBuilder.Entity<Produto>(p =>
      {
        p.ToTable("Produtos");
        p.HasKey(p => p.Id);
        p.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
        p.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
        p.Property(p => p.Valor).IsRequired();
        p.Property(p => p.TipoProdduto).HasConversion<string>();
      });

      modelBuilder.Entity<Pedido>(p =>
      {
        p.ToTable("Pedidos");
        p.HasKey(p => p.Id);
        p.Property(p => p.InciadoEm).HasDefaultValue("GETDATE()").ValueGeneratedOnAdd();
        p.Property(p => p.Status).HasConversion<string>();
        p.Property(p => p.TipoFrete).HasConversion<int>();
        p.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

        p.HasMany(p => p.Itens)
         .WithOne(p => p.Pedido)
         .OnDelete(DeleteBehavior.Cascade);
      });

      modelBuilder.Entity<PedidoItem>(p =>
      {
        p.ToTable("PedidoItens");
        p.HasKey(p => p.Id);
        p.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();
        p.Property(p => p.Valor).IsRequired();
        p.Property(p => p.Desconto).IsRequired();
      });

      base.OnModelCreating(modelBuilder);
    }
  }
}