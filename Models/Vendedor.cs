using System.ComponentModel.DataAnnotations;
namespace ProjetoFinalVolvo
{
  public class Vendedor
  {
    [Key]
    public int vendedorId { get; set; }
    [StringLength(45)]
    public string nome { get; set; }
    public float salario { get; set; }
    public Veiculo? veiculo;


    public Vendedor()
    {
      this.vendedorId = 0;
      this.nome = "";
      this.salario = 0.0f;

    }

  }

}