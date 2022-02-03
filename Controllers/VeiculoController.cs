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

      }
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Veiculo veiculo)
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
  }
}

