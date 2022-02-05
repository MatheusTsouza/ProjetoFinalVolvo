using Microsoft.AspNetCore.Mvc;
using ProjetoFinalVolvo;
using System;
using System.ComponentModel.DataAnnotations;

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
          if (new EmailAddressAttribute().IsValid(proprietario.email) == false)
          {
            throw new ConcessionariaException("Email com o formato inválido");
          }

          if (proprietario.enderecoNumero > 9999)
          {
            throw new ConcessionariaException("Numero da casa não pode ser superior a 9999");
          }

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
          Utils.addLog(e.Message);
          return Problem(e.Message, null, 400, "Erro");
        }
        catch (Exception e)
        {
          Utils.addLog(e.Message);
          return Problem(e.Message, null, 500, "Erro");
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
            throw new NullReferenceException("Proprietario nao existe");
          }
          return Ok(proprietario);
        }
        catch (NullReferenceException e)
        {
          Utils.addLog(e.Message);
          return Problem(e.Message, null, 404, "Erro");
        }
        catch (Exception e)
        {
          Utils.addLog(e.Message);
          return Problem(e.Message, null, 500, "Erro");
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
            throw new NullReferenceException("Proprietario nao encontrado");
          }
          _context.Entry(entity).CurrentValues.SetValues(proprietario);
          _context.SaveChanges();
          return Ok();
        }
        catch (NullReferenceException e)
        {
          Utils.addLog(e.Message);
          return Problem(e.Message, null, 404, "Erro");
        }
        catch (Exception e)
        {
          Utils.addLog(e.Message);
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
          var entity = _context.Proprietarios.Find(id);
          if (entity == null)
          {
            throw new NullReferenceException("Proprietario nao encontrado");
          }
          _context.Proprietarios.Remove(entity);
          _context.SaveChanges();
          return Ok();
        }
        catch (NullReferenceException e)
        {
          Utils.addLog(e.Message);
          return Problem(e.Message, null, 404, "Erro");

        }
        catch (Exception e)
        {
          Utils.addLog(e.Message);
          return Problem(e.Message, null, 500, "Erro");
        }
      }
    }
  }
}

