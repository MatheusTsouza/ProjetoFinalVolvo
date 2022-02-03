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
    public string endereco { get; set; }
    [MaxLength(256)]
    public string email { get; set; }

  }
}