using System;
using System.Linq;
using CursoEFCore.Domain;
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

      Console.WriteLine("Aplicação iniciada");
      InserirDadosEmMassa();
    }

    private static void InserirDadosEmMassa()
    {
      var produto = new Produto
      {
        Descricao = "Produto teste",
        CodigoBarras = "12234567891358",
        Valor = 10m,
        TipoProduto = ValueObjects.TipoProduto.MercadoriaParaRevenda,
        Ativo = true
      };

      var clientes = new[] {

        new Cliente{
          Nome = "Jujénovis",
          CEP = "9899999",
          Cidade = "jujéCidade",
          Estado = "JJ",
          Telefone = "1855555555"
        },

        new Cliente{
          Nome = "Jujéliaria",
          CEP = "7777777",
          Cidade = "jujéCidade",
          Estado = "JJ",
          Telefone = "7777777776"
        },
      };

      using var db = new Data.AplicationContext();

      //db.AddRange(produto, cliente);
      //db.Clientes.AddRange(clientes);
      db.Set<Cliente>().AddRange(clientes);

      var registros = db.SaveChanges();

      Console.WriteLine($"Total registros(s) :{registros}");

    }

    private static void InserirDados()
    {
      var produto = new Produto
      {
        Descricao = "Produto teste",
        CodigoBarras = "12234567891358",
        Valor = 10m,
        TipoProduto = ValueObjects.TipoProduto.MercadoriaParaRevenda,
        Ativo = true
      };

      using var db = new Data.AplicationContext();
      //Formas para rastrear um registro antes de inserção
      //db.Produtos.Add(produto);
      //db.Set<Produto>().Add(produto);
      //db.Entry(produto).State = EntityState.Added;
      db.Add(produto);

      var registros = db.SaveChanges();
      Console.WriteLine($"Total registros(s):{registros}");
    }
  }
}
