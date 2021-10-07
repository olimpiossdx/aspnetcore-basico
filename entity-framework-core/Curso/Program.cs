using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore
{
  class Program
  {
    static void Main(string[] args)
    {
      //Não recomendado em produção, apenas para desenvolvimento.
      using var db = new Data.AplicationContext();
      //db.Database.Migrate();
      var existe = db.Database.GetPendingMigrations().Any();

      if (existe)
      {
        //Aplicar regras de negócios pendentes a serem aplicas.
      }

      Console.WriteLine("Aplicação inicitada");
    }
  }
}
