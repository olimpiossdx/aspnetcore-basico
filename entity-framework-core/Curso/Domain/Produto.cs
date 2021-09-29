using CursoEFCore.ValueObjects;

namespace CursoEFCore.Domain
{
  public class Produto
  {
    public int Id { get; set; }
    public string CodigoBarras { get; set; }
    public string Descricao { get; set; }
    public TipoProduto TipoProdduto { get; set; }
    public bool Ativo { get; set; }
  }
}