using Microsoft.AspNetCore.Mvc;
using ProjetoFinalVolvo;

namespace ProjetoFinalVolvo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProprietarioController : Controller
  {
    [HttpPost]
    public IActionResult Post([FromBody] Proprietario proprietario)
    {
      using (var _context = new ConcessionariaContexto())
      {
        try
        {

          if (proprietario.cpfCnpj.Length != 14 && proprietario.cpfCnpj.Length != 11)
          {
            throw new ConcessionariaException("Cpf deve ter 11 numeros e o Cnpj 14 numeros");
          }
          _context.Proprietarios.Add(proprietario);
          _context.SaveChanges();

          return Ok(proprietario);
        }
        catch (ConcessionariaException e)
        {
          return BadRequest(e.Message);
        }
        catch (Exception e)
        {
          return BadRequest(e.StackTrace);
        }
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
        try
        {
          var proprietario = _context.Proprietarios.FirstOrDefault(s => s.proprietarioId == id);

          if (proprietario == null)
          {
            throw new NullReferenceException("Proprietario  não existe");
          }
          return Ok(proprietario);
        }
        catch (NullReferenceException e)
        {
          return NotFound(e.Message);
        }
        catch (Exception e)
        {
          return BadRequest(e.StackTrace);
        }
      }

    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Proprietario proprietario)
    {
      using (var _context = new ConcessionariaContexto())
      {
        try
        {
          var entity = _context.Proprietarios.Find(id);
          if (entity == null)
          {
            throw new NullReferenceException("Proprietario não encontrado");
          }
          _context.Entry(entity).CurrentValues.SetValues(proprietario);
          _context.SaveChanges();
          return Ok("Proprietario editado");
        }
        catch (NullReferenceException e)
        {
          return NotFound(e.Message);
        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
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
          var entity = _context.Proprietarios.Find(id);
          if (entity == null)
          {
            throw new NullReferenceException("Proprietario não encontrado");
          }
          _context.Proprietarios.Remove(entity);
          _context.SaveChanges();
          return Ok("Proprietario deletado");
        }
        catch (NullReferenceException e)
        {
          return NotFound(e.Message);
        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        }
      }
    }
  }
}

