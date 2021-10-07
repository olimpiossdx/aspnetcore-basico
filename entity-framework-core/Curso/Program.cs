using System;

namespace CursoEFCore
{
  class Program
  {
    static void Main(string[] args)
    {
      //Não recomendado em produção, apenas para desenvolvimento.
      //using var db = new Data.AplicationContext();
      //db.Database.Migrate();

      Console.WriteLine("Aplicação inicitada");
    }
  }
}
