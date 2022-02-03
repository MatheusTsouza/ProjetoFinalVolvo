using Microsoft.EntityFrameworkCore;
namespace ProjetoFinalVolvo
{
  public class ConcessionariaContexto : DbContext
  {
    public DbSet<Veiculo> Veiculos { get; set; } = null!;
    public DbSet<Vendedor> Vendedores { get; set; } = null!;
    public DbSet<Proprietario> Proprietarios { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
		string abc = @".\;Database=Concessionaria;Trusted_Connection=True";
		optionsBuilder.UseSqlServer(@"Server=" + abc);
    }
  }
}