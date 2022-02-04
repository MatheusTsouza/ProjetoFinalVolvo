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
        var vendedor = _context.Vendedores.FirstOrDefault(s => s.vendedorId == id);
        if (vendedor == null)
        {
          return NotFound();
        }
        return Ok(vendedor);
      }
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Vendedor vendedor)
    {
      using (var _context = new ConcessionariaContexto())
      {
        var entity = _context.Vendedores.Find(id);
        if (entity == null)
        {
          return;
        }
        _context.Entry(entity).CurrentValues.SetValues(vendedor);
        _context.SaveChanges();
      }
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      using (var _context = new ConcessionariaContexto())
      {
        var entity = _context.Vendedores.Find(id);
        if (entity == null)
        {
          return;
        }
        _context.Vendedores.Remove(entity);
        _context.SaveChanges();
      }
    }

    // Calcular salario
    [HttpGet("salario/{id}")]
    public double CalcularSalario(int id)
    {
      double salarioBase = 0;
      double totalComissoes = 0;
      double comissao = 0.01;
      using (var _context = new ConcessionariaContexto())
      {
        salarioBase = _context.Vendedores.Where(x => x.vendedorId == id).First<Vendedor>().salario;
        var veiculosVendidos = _context.Veiculos.Where(x => x.vendedorId == id).ToList();
        foreach (var veiculo in veiculosVendidos)
        {
          totalComissoes += veiculo.valor * comissao;
        }
        return salarioBase + totalComissoes;
      }
    }
  }
}

