using Microsoft.AspNetCore.Mvc;
using ToolBox_Api.Data;
using ToolBox_Api.Domain;
using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Controllers
{
    [Route("api/cadastroitens")]
    [ApiController]
    public class ItensController : ControllerBase
    {
        private readonly ICadastroItens _cadastroItens;

         public ItensController()
        {
            _cadastroItens = new CadastroItens();
        }
        /// <summary>
        /// Requisição do tipo Get dos itens cadastrados 
        /// </summary>
        /// <returns>Objeto do tipo Clientes</returns>
        [HttpGet()]
        public IActionResult GetItens()
          {
            try
            {
                List<Itens> cliente = _cadastroItens.GetItens();
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Requisição do tipo Get dos itens cadastrados filtrando pelo id
        /// </summary>
        /// <param name="id">identificação dos Clientes</param>
        /// <returns>lista de objetos do tipo Clientes</returns>
        [HttpGet("{id}")]
        public IActionResult GetItens(int id)
        {
            try
            {
                List<Itens> cliente = _cadastroItens.GetItens(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Inseri um cliente no banco de dados
        /// </summary>
        /// <param name="cliente">Objeto com as propriedades do cliente</param>
        /// <returns>um boleano indicando sucesso ou falha</returns>
        [HttpPost]
        public IActionResult InsertItens([FromBody] Itens iten)
        {
            try
            {
                bool iserir = _cadastroItens.InsertItens(iten);
                return Ok(iserir);
            }
             catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera um cliente no banco de dados
        /// </summary>
        /// <param name="id">Identificação do cliente</param>
        /// <param name="cliente">Informações do Cliente</param>
        /// <returns> 0 para verdadeiro e 1 para falso</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateItens(int id, [FromBody] Itens iten)
        {
            try
            {
                int alterar = _cadastroItens.UpdateItens(id, iten);
                return Ok(alterar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Realiza a deleção de um cliente no banco de dados
        /// </summary>
        /// <param name="id">Identificação do cliente</param>
        /// <returns>0 para verdadeiro e 1 para falso</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteItens(int id)
        {
            try
            {
                int Deletar = _cadastroItens.DeleteItens(id);
                return Ok(Deletar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
