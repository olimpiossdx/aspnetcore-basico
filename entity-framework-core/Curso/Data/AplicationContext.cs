using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Data
{
  public class AplicationContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb;Inital Catalog=CursoEFCore;Integrated Security=true");
      base.OnConfiguring(optionsBuilder);
    }
  }
}