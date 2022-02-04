using Microsoft.AspNetCore.Mvc;
using ProjetoFinalVolvo;

namespace ProjetoFinalVolvo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VeiculoController : Controller
  {
    [HttpPost]
    public Veiculo? Post([FromBody] Veiculo veiculo)
    {
      using (var _context = new ConcessionariaContexto())
      {
        _context.Veiculos.Add(veiculo);
        _context.SaveChanges();

        return veiculo;
      }
    }

    [HttpGet]
    public List<Veiculo> Get()
    {
      using (var _context = new ConcessionariaContexto())
      {
        return _context.Veiculos.ToList();
      }
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      using (var _context = new ConcessionariaContexto())
      {
        var veiculo = _context.Veiculos.FirstOrDefault(s => s.veiculoId == id);
        if (veiculo == null)
        {
          return NotFound();
        }
        return Ok(veiculo);
      }
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Veiculo veiculo)
    {
      using (var _context = new ConcessionariaContexto())
      {
        var entity = _context.Veiculos.Find(id);
        if (entity == null)
        {
          return;
        }
        _context.Entry(entity).CurrentValues.SetValues(veiculo);
        _context.SaveChanges();
      }
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      using (var _context = new ConcessionariaContexto())
      {
        var entity = _context.Veiculos.Find(id);
        if (entity == null)
        {
          return;
        }
        _context.Veiculos.Remove(entity);
        _context.SaveChanges();
      }
    }

	// Listar veiculos por quilometragem
	[HttpGet("quilometragem")]
    public List<Veiculo> ListarQuilometragem()
    {
		using (var _context = new ConcessionariaContexto())
		{
			// List<Veiculo> veiculos = blabla;
		}
		return veiculos;
    }

	// Listar veiculos pela versao
	[HttpGet("versao")]
    public List<Veiculo> ListarVersao()
    {
		using (var _context = new ConcessionariaContexto())
		{
			// List<Veiculo> veiculos = blabla;
		}
		return veiculos;
    }

  }
}

