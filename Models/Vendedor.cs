using System.ComponentModel.DataAnnotations;
namespace ProjetoFinalVolvo
{
  public class Vendedor
  {
    public int vendedorId { get; set; }
    public string nome { get; set; }
    public float salario { get; set; }
    public Veiculo? veiculo;
  }
}