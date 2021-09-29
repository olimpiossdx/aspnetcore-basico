using System;
using CursoEFCore.ValuesObjects;

namespace CursoEFCore.Domain
{
  public class Pedido
  {
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public DateTime InciadoEm { get; set; }
    public DateTime FinalizadoEm { get; set; }
    public TipoFrete TipoFrete { get; set; }
  }
}