using System.ComponentModel.DataAnnotations;
namespace ProjetoFinalVolvo
{
  public class Veiculo
  {
    [Key]
    public int veiculoId { get; set; }
    [MaxLength(17)]
    public string numeroChassi { get; set; }
    [MaxLength(45)]
    public string modelo { get; set; }
    public short ano { get; set; }
    [MaxLength(45)]
    public string cor { get; set; }
    public float valor { get; set; }
    public int quilometragem { get; set; }
    public string acessorios { get; set; }
    [MaxLength(45)]
    public string versaoSistema { get; set; }
    public float motor { get; set; }
    [MaxLength(45)]
    public string marca { get; set; }
    public int? proprietarioId { get; set; }
    public Proprietario? Proprietario { get; set; }

    public int? vendedorId { get; set; }
    public Vendedor? Vendedor { get; set; }


    public Veiculo()
    {
      this.veiculoId = 0;
      this.numeroChassi = "";
      this.modelo = "";
      this.ano = 0;
      this.cor = "";
      this.valor = 0.0f;
      this.quilometragem = 0;
      this.acessorios = "";
      this.versaoSistema = "";
      this.motor = 0.0f;
      this.marca = "";
      this.proprietarioId = 0;
      this.vendedorId = 0;
    }

  }
}