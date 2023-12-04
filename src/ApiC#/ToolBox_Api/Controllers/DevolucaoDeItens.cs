using Microsoft.AspNetCore.Mvc;
using ToolBox_Api.Data;
using ToolBox_Api.Domain;
using ToolBox_Api.Domain.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToolBox_Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DevolucaoDeItens : ControllerBase
  {
    private readonly IDevolucaoItens _devolucaoItens;
    public DevolucaoDeItens()
    {
      _devolucaoItens = new DevolucaoItens();
    }

    // GET: api/<ValuesController>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      try
      {
        List<ProdutoDevolucao> produto = _devolucaoItens.GetDevolucao(id);
        return Ok(produto);
      }
      catch (Exception ex)
      {
        return Ok(ex.Message);
      }
    }

    // GET api/<ValuesController>/5
    [HttpGet()]
    public IActionResult Get()
    {
      try
      {
        return Ok(true);
      }
      catch (Exception ex)
      {
        return Ok(ex.Message);
      }
    }

    // POST api/<ValuesController>
    [HttpPost]
    public IActionResult Post([FromBody] ProdutoDevolucao value)
    {
      try
      {
        bool produto = _devolucaoItens.InsertDevolucao(value);
        return Ok(true);
      }
      catch (Exception ex)
      {
        return Ok(ex.Message);
      }
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] string value)
    {
      try
      {
        
        return Ok(true);
      }
      catch (Exception ex)
      {
        return Ok(ex.Message);
      }
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      try
      {
        
        return Ok(true);
      }
      catch (Exception ex)
      {
        return Ok(ex.Message);
      }
    }
  }
}
