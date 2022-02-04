using Microsoft.AspNetCore.Mvc;
using ProjetoFinalVolvo;

namespace ProjetoFinalVolvo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProprietarioController : Controller
  {
    [HttpPost]
    public Proprietario? Post([FromBody] Proprietario proprietario)
    {
      using (var _context = new ConcessionariaContexto())
      {
        _context.Proprietarios.Add(proprietario);
        _context.SaveChanges();

        return proprietario;
      }
    }

    [HttpGet]
    public List<Proprietario> Get()
    {
      using (var _context = new ConcessionariaContexto())
      {
        return _context.Proprietarios.ToList();
      }
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      using (var _context = new ConcessionariaContexto())
      {
        var proprietario = _context.Proprietarios.FirstOrDefault(s => s.proprietarioId == id);

        if (proprietario == null)
        {
          return NotFound();
        }
        return Ok(proprietario);
      }
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Proprietario proprietario)
    {
      using (var _context = new ConcessionariaContexto())
      {
        var entity = _context.Proprietarios.Find(id);
        if (entity == null)
        {
          return;
        }
        _context.Entry(entity).CurrentValues.SetValues(proprietario);
        _context.SaveChanges();
      }
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      using (var _context = new ConcessionariaContexto())
      {
        var entity = _context.Proprietarios.Find(id);
        if (entity == null)
        {
          return;
        }
        _context.Proprietarios.Remove(entity);
        _context.SaveChanges();
      }
    }
  }
}

