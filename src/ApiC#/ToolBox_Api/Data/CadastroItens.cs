using NPOI.SS.Formula.Functions;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using ToolBox_Api.Dao;
using ToolBox_Api.Domain;
using ToolBox_Api.Domain.Model;
using static NPOI.HSSF.Util.HSSFColor;

namespace ToolBox_Api.Data
{
    internal class CadastroItens : ICadastroItens
    {
        IDbsConexao _dbs = DbsFactory.Create();
        public int DeleteItens(int id)
        {
            string sql = $"DELETE FROM toolbox.produto WHERE id = {id} " +
                $"DELETE FROM toolbox.categorias_de_produtos WHERE id_produto = {id} " +
                $"DELETE FROM toolbox.imagem_produto WHERE id_produto = {id}";
            var teste = _dbs.Execute<int>(sql);
            return teste;

        }

        public List<Itens> GetItens()
        {
            string sql = $"SELECT f1.id, f1.nome, f1.condicao, f1.marca, f1.descricao, f1.preco, f3.path, f2.id_categoria, f4.nome_categoria, f1.id_usuario " +
                $"FROM toolbox.produto AS f1 " +
                $"LEFT JOIN toolbox.imagem_produto AS f3 ON f1.id = f3.id_produto " +
                $"LEFT JOIN toolbox.categorias_de_produtos AS f2 ON f1.id = f2.id_produto " +
                $"LEFT JOIN toolbox.categoria AS f4 ON f2.id_categoria = f4.id";
            List<Itens> teste = _dbs.Query<Itens>(sql);
            return teste;
        }

        public List<Itens> GetItens(int id)
        {
            string sql = $"SELECT f1.id, f1.nome, f1.condicao, f1.marca, f1.descricao, f1.preco, f1.id_usuario, f3.path, f2.id_categoria, f4.nome_categoria "+
          "FROM toolbox.produto AS f1 LEFT JOIN toolbox.imagem_produto AS f3 ON f1.id = f3.id_produto "+
          "LEFT JOIN toolbox.categorias_de_produtos AS f2 ON f1.id = f2.id_produto "+
          "LEFT JOIN toolbox.categoria AS f4 ON f2.id_categoria = f4.id "+
           $"WHERE f1.id = { id}";
            List<Itens> teste = _dbs.Query<Itens>(sql);
            return teste;

        }

        public bool InsertItens(Itens iten)
        {
            List<string> imagens = iten.path.Split(')').ToList();
            string sql = $"DECLARE @id INT " +
              $" INSERT INTO toolbox.produto (nome, condicao, marca, descricao, preco, id_usuario) " +
              $" VALUES ('{iten.nome}', '{iten.Condicao}', '{iten.marca}', " +
              $"'{iten.Descricao}', '{iten.Preco}', '{iten.id_usuario}' ) SET @id = SCOPE_IDENTITY(); " +
              $"insert into toolbox.categorias_de_produtos (id_produto, id_categoria) values (@id, {iten.id_categoria});" +
              $"insert into toolbox.imagem_produto (id_produto, path) values (@id, '{iten.path}');";
            
            var teste = _dbs.Execute<int>(sql);
            if (teste == 0)
                return true;
            else
                return false;


        }

        public int UpdateItens(int id, Itens iten)
        {
            string sql = $"UPDATE toolbox.produto SET nome = '{iten.nome}', condicao = '{iten.Condicao}', descricao = '{iten.Descricao}', preco = '{iten.Preco}' WHERE id = {id} " +
                $"UPDATE toolbox.categorias_de_produtos SET id_categoria = '{iten.id_categoria}' WHERE id_produto = {id} " +
                $"UPDATE toolbox.imagem_produto SET path = '{iten.path}' WHERE id_produto = {id} ";
            var teste = _dbs.Execute<int>(sql);
            return teste;
        }
    }
}
