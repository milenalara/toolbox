using Microsoft.AspNetCore.Mvc;
using ToolBox_Api.Data;
using ToolBox_Api.Domain.Model;
using ToolBox_Api.Domain;

namespace ToolBox_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmprestimoItensController : ControllerBase
    {
        private readonly IEmprestimoItens _emprestimoItens;
        public EmprestimoItensController()
        {
            _emprestimoItens = new EmprestimoItens();
        }

        [HttpGet]
        public IActionResult GetEmprestimos()
        {
            try
            {
                List<Emprestimo> emprestimo = _emprestimoItens.GetEmprestimos();
                return Ok(emprestimo);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("comentario/{id}")]
        public IActionResult GetComentario(int id)
        {
            try
            {
                List<Comentario> comentario = _emprestimoItens.GetComentario(id);
                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("dosponiveis/{id}")]
        public IActionResult GetProdutosDisponibilizado(int id)
        {
            try
            {
                List<Emprestimo> comentario = _emprestimoItens.GetProdutosDisponibilizado(id);
                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("alocados/{id}")]
        public IActionResult GetProdutosAlocados(int id)
        {
            try
            {
                List<Emprestimo> comentario = _emprestimoItens.GetProdutosAlocados(id);
                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public IActionResult GetEmprestimo(int id)
        {
            try
            {
                List<Emprestimo> emprestimo = _emprestimoItens.GetEmprestimo(id);
                return Ok(emprestimo);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Emprestimo value)
        {
            try
            {
                int emprestimo = _emprestimoItens.InsertEmprestimo(value);
                return Ok(emprestimo);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("avaliacao/{id}")]
        public IActionResult Put(int id, [FromBody] int avaliacao)
        {
            try
            {
                int emprestimo = _emprestimoItens.UpdateAvaliacao(id, avaliacao);
                return Ok(emprestimo);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPut("status/{id}")]
        public IActionResult UpdateStatus(int id, [FromBody] string status)
        {
            try
            {
                int emprestimo = _emprestimoItens.UpdateStatus(id, status);
                return Ok(emprestimo);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPut("datadevolucao/{id}")]
        public IActionResult UpdateDataDevolucao(int id, [FromBody] string dataFim)
        {
            try
            {
                int emprestimo = _emprestimoItens.UpdateDataDevolucao(id, dataFim);
                return Ok(emprestimo);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
