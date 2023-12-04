using Microsoft.AspNetCore.Mvc;
using ToolBox_Api.Data;
using ToolBox_Api.Domain;
using ToolBox_Api.Domain.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToolBox_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroUsuarioController : ControllerBase
    {
        private readonly ICadastroUsuario _cadastroUsuario;

        public CadastroUsuarioController()
        {
            _cadastroUsuario = new CadastroUsuario();
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetUsuario()
        {
            try
            {
                List<Usuario> usuario = _cadastroUsuario.GetUsuario();
                return Ok(usuario);
            }
            catch(Exception ex) 
            {
                return Ok(ex.Message);
            }
            
        }

        [HttpGet("{email}/{senha}")]
        public IActionResult GetLoginUsuario(string email, string senha)
         {
          try
          {
            List<int> retorno = _cadastroUsuario.GetLoginUsuario(email, senha);
            return Ok(retorno);
          }
          catch (Exception ex)
          {
            return Ok(ex.Message);
          }

        }

    // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                List<Usuario> usuario = _cadastroUsuario.GetUsuario(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult InserirUsuario([FromBody] Usuario usuario)
        {
            try
            {
                int inserir = _cadastroUsuario.InsertUsuario(usuario);
                return Ok(inserir);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult AlterarUsuario(int id, [FromBody] Usuario usuario)
        {
            try
            {
                int alterar = _cadastroUsuario.UpdateUsuario(id, usuario);
                return Ok(alterar);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                int deletar = _cadastroUsuario.DeleteUsuario(id);
                return Ok(deletar);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
