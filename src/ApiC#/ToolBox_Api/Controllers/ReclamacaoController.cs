using Microsoft.AspNetCore.Mvc;
using ToolBox_Api.Data;
using ToolBox_Api.Domain;
using ToolBox_Api.Domain.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToolBox_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamacaoController : ControllerBase
    {
        private readonly IReclamacao _reclamacaoItens;

        public ReclamacaoController()
        {
            _reclamacaoItens = new CadastroReclamacao();
        }

        [HttpGet]
        public IActionResult GetUsuario()
        {
            try
            {
                List<Reclamacao> usuario = _reclamacaoItens.GetReclamacoes();
                return Ok(usuario);
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
                List<Reclamacao> usuario = _reclamacaoItens.GetReclamacao(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult InserirUsuario([FromBody] Reclamacao reclamacao)
        {
            try
            {
                bool inserir = _reclamacaoItens.InsertReclamacao(reclamacao);
                return Ok(inserir);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

    }
}
