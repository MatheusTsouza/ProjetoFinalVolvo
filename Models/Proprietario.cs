using System.ComponentModel.DataAnnotations;
namespace ProjetoFinalVolvo
{
  public class Proprietario
  {
    [Key]
    public int proprietarioId { get; set; }
    [MinLength(3)]
    [MaxLength(50)]
    public string nome { get; set; } = null!;
    [MinLength(11)]
    [MaxLength(14)]
    public string cpfCnpj { get; set; }
    [StringLength(60)]
    public string enderecoCidade { get; set; }
    [StringLength(100)]
    public string enderecoRua { get; set; }
    public int enderecoNumero { get; set; }
    [MaxLength(256)]
    public string email { get; set; }
    public Veiculo? veiculo;

    public Proprietario()
    {
      this.proprietarioId = 0;
      this.nome = "";
      this.cpfCnpj = "";
      this.enderecoCidade = "";
      this.enderecoRua = "";
      this.enderecoNumero = 0;
      this.email = "";

    }
  }
}