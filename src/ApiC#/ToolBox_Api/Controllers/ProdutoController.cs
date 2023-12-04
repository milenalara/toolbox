using Microsoft.AspNetCore.Mvc;
using ToolBox_Api.Data;
using ToolBox_Api.Domain;
using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Controllers
{
    [Route("api/cadastroproduto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ICadastroProduto _cadastroProduto;
       public ProdutoController()
       {
            _cadastroProduto = new CadastroProduto();
       }

        [HttpGet()]
        public IActionResult GetProdutos()
        {
            try
            {
                List<Produto> produtos = _cadastroProduto.GetProdutos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProduto(long id)
        {
            try
            {
                List<Produto> produto = _cadastroProduto.GetProdutos();
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertProduto([FromBody]Produto produto)
        {
            try
            {
                bool inserir = _cadastroProduto.InsertProduto(produto);
                return Ok(inserir);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
