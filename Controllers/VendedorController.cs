using Microsoft.AspNetCore.Mvc;
using ProjetoFinalVolvo;

namespace ProjetoFinalVolvo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VendedorController : Controller
  {
    [HttpPost]
    public Vendedor? Post([FromBody] Vendedor vendedor)
    {
      using (var _context = new ConcessionariaContexto())
      {
        _context.Vendedores.Add(vendedor);
        _context.SaveChanges();

        return vendedor;
      }
    }

    [HttpGet]
    public List<Vendedor> Get()
    {
      using (var _context = new ConcessionariaContexto())
      {
        return _context.Vendedores.ToList();
      }
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      using (var _context = new ConcessionariaContexto())
      {

      }
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Vendedor vendedor)
    {
      using (var _context = new ConcessionariaContexto())
      {

      }
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      using (var _context = new ConcessionariaContexto())
      {

      }
    }

	// Calcular salario
	[HttpGet("salario/{id}")]
	public float CalcularSalario(int id)
	{
		float salarioBase = 0
		float totalComissoes = 0;
		float comissao = 0.01;
		using (var _context = new ConcessionariaContexto())
		{
			salarioBase = _context.Vendedores.Where(x=> x.vendedorId == id).salario;
			var veiculosVendidos = _context.Veiculos.Where(x=> x.vendedorId == id).ToList();
			foreach (var veiculo in veiculosVendidos) {
				totalComissoes += veiculo.valor*comissao;
			}
			return salarioBase + totalComissoes;
		}
	}
  }
}

