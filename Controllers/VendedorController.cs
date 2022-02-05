using Microsoft.AspNetCore.Mvc;
using ProjetoFinalVolvo;

namespace ProjetoFinalVolvo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VendedorController : Controller
  {
    [HttpPost]
    public IActionResult Post([FromBody] Vendedor vendedor)
    {
      using (var _context = new ConcessionariaContexto())
      {
        try
        {
          if (vendedor.salario < 1212.00)
          {
            throw new ConcessionariaException("O salário deve ser igual ou maior que o salario mínimo");
          }
          _context.Vendedores.Add(vendedor);
          _context.SaveChanges();

          return Ok(vendedor);
        }
        catch (ConcessionariaException e)
        {
          return Problem(e.Message, null, 400, "Erro");
        }
        catch (Exception e)
        {
          return Problem(e.Message, null, 400, "Erro");
        }
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
        try
        {
          var vendedor = _context.Vendedores.FirstOrDefault(s => s.vendedorId == id);
          if (vendedor == null)
          {
            throw new NullReferenceException("Vendedor não encontrado");
          }
          return Ok(vendedor);
        }
        catch (NullReferenceException e)
        {
          return Problem(e.Message, null, 404, "Erro");
        }
        catch (Exception e)
        {
          return Problem(e.Message, null, 500, "Erro");
        }
      }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Vendedor vendedor)
    {
      using (var _context = new ConcessionariaContexto())
      {
        try
        {
          var entity = _context.Vendedores.Find(id);
          if (entity == null)
          {
            throw new NullReferenceException("Vendedor não encontrado");
          }
          _context.Entry(entity).CurrentValues.SetValues(vendedor);
          _context.SaveChanges();
          return Ok();
        }
        catch (NullReferenceException e)
        {
          return Problem(e.Message, null, 404, "Erro");
        }
        catch (Exception e)
        {
          return Problem(e.Message, null, 500, "Erro");
        }
      }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      using (var _context = new ConcessionariaContexto())
      {
        try
        {
          var entity = _context.Vendedores.Find(id);
          if (entity == null)
          {
            throw new NullReferenceException("Vendedor não encontrado");
          }
          _context.Vendedores.Remove(entity);
          _context.SaveChanges();
          return Ok();
        }
        catch (NullReferenceException e)
        {
          return Problem(e.Message, null, 404, "Erro");

        }
        catch (Exception e)
        {
          return Problem(e.Message, null, 500, "Erro");
        }
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

