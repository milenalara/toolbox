using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Domain
{
    public interface ICadastroProduto
    {
        public List<Produto> GetProdutos();
        public List<Produto> GetProduto(long id);
        public bool InsertProduto(Produto produto);
        //public int UpdateProduto(long id, Produto produto);
        //public int DeleteItens(long id);
    }
}