using ToolBox_Api.Dao;
using ToolBox_Api.Domain;
using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Data
{
    internal class CadastroProduto : ICadastroProduto
    {
        IDbsConexao _dbs = DbsFactory.Create();

        public List<Produto> GetProdutos()
        {
            string sql = $"SELECT p.id,\r\n\tp.nome,\r\n\tp.condicao,\r\n\tp.marca,\r\n\tp.descricao,\r\n\tp.preco, p.id_usuario, \r\n\tc.nome_categoria AS \"categoria\"\r\n FROM toolbox.produto AS p\r\nJOIN toolbox.categorias_de_produtos AS cp ON cp.id_produto = p.id\r\nJOIN toolbox.categoria AS c ON cp.id_categoria = c.id;";
            List<Produto> produtos = _dbs.Query<Produto>(sql);
            return produtos;
        }
        public List<Produto> GetProduto(long id)
        {
            string sql = $"SELECT p.id,\r\n\tp.nome,\r\n\tp.condicao,\r\n\tp.marca,\r\n\tp.descricao,\r\n\tp.preco,\r\n\tc.nome_categoria AS \"categoria\"\r\n p.id_usuario FROM toolbox.produto AS p\r\nJOIN toolbox.categorias_de_produtos AS cp ON cp.id_produto = p.id\r\nJOIN toolbox.categoria AS c ON cp.id_categoria = c.id\r\nWHERE p.id = {id};";
            List<Produto> produto = _dbs.Query<Produto>(sql);
            return produto;
        }
        public bool InsertProduto(Produto produto)
        {
            string sql = "INSERT INTO toolbox.produto (nome, condicao, marca, descricao, preco)\r\nVALUES (\r\n\t\"{produto.Nome}\",\r\n\t\"{produto.Condicao}\",\r\n\t\"{produto.Marca}\",\r\n\t\"{produto.Descricao}\",\r\n\t{produto.Preco}\r\n)\r\n\r\nSET @UserId = SCOPE_IDENTITY()\r\n\r\nINSERT INTO toolbox.categorias_de_produtos (id_produto, id_categoria)\r\nVALUES (@UserId, {produto.idCategoria})";
            var teste = _dbs.Execute<int>(sql);
            if (teste == 0)
                return true;
            else
                return false;
        }
        //public int UpdateProduto(long id, Produto produto);
        //public int DeleteItens(long id);
    }
}
