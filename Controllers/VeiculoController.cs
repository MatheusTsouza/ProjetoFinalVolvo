using Microsoft.AspNetCore.Mvc;
using ProjetoFinalVolvo;

namespace ProjetoFinalVolvo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VeiculoController : Controller
  {
    [HttpPost]
    public IActionResult Post([FromBody] Veiculo veiculo)
    {

      try
      {
        using (var _context = new ConcessionariaContexto())
        {
          _context.Veiculos.Add(veiculo);
          _context.SaveChanges();

          return Ok(veiculo);
        }
      }
      catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
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
        try
        {
          var veiculo = _context.Veiculos.FirstOrDefault(s => s.veiculoId == id);
          if (veiculo == null)
          {
            throw new ConcessionariaException("Veiculo nao existe!");
          }
          return Ok(veiculo);
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

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Veiculo veiculo)
    {
      using (var _context = new ConcessionariaContexto())
      {
        try
        {
          var entity = _context.Veiculos.Find(id);
          if (entity == null)
          {
            throw new NullReferenceException("Veiculo nao encontrado");
          }
          _context.Entry(entity).CurrentValues.SetValues(veiculo);
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
          var entity = _context.Veiculos.Find(id);
          if (entity == null)
          {
            throw new NullReferenceException("Veiculo nao encontrado");
          }
          _context.Veiculos.Remove(entity);
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

    // Listar veiculos por quilometragem
    [HttpGet("quilometragem")]
    public IActionResult ListarQuilometragem()
    {
      try
      {
        using (var _context = new ConcessionariaContexto())
        {
          // List<Veiculo> veiculos = blabla;
          var veiculos = _context.Veiculos
          .OrderBy(x => x.quilometragem)
          .ToList();
          return Ok(veiculos);
        }
      }
      catch (Exception e)
      {
        Utils.addLog(e.Message);
        return Problem(e.Message, null, 500, "Erro");
      }
    }

    // Listar veiculos pela versao
    [HttpGet("versao")]
    public IActionResult ListarVersao()
    {
      try
      {
        using (var _context = new ConcessionariaContexto())
        {
          var veiculos = _context.Veiculos
          .OrderBy(x => x.versaoSistema)
          .ToList();
          return Ok(veiculos);
        }
      }
      catch (Exception e)
      {
        Utils.addLog(e.Message);
        return Problem(e.Message, null, 500, "Erro");
      }
    }

    [HttpGet("Preve Preco{id}")]
    public IActionResult prevePrecoCarro(int id)
    {
      using (var _context = new ConcessionariaContexto())
      {
        try
        {

          var veiculo = _context.Veiculos.FirstOrDefault(s => s.veiculoId == id);
          if (veiculo == null)
          {
            throw new NullReferenceException("Veiculo nao existe!");
          }

          string quilometragem = Convert.ToString(veiculo.quilometragem);
          string ano = Convert.ToString(veiculo.ano);
          string valor = Convert.ToString(veiculo.valor);


          string dadosConcat = string.Concat(quilometragem, ";", ano, ";", valor);

          pythonToDotnet servidor = new pythonToDotnet();
          servidor.selecionaServidor(50000, "127.0.0.1");
          string dados = servidor.enviaDados(dadosConcat);

          return Ok(dados);

        }
        catch (NullReferenceException e)
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

  }
}

