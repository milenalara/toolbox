using ToolBox_Api.Dao;
using ToolBox_Api.Domain;
using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Data
{
  public class EmprestimoItens : IEmprestimoItens
  {
    IDbsConexao _dbs = DbsFactory.Create();

        public List<Emprestimo> GetEmprestimo(int id)
        {
            string sql = $"SELECT\r\n\te.id AS idEmprestimo,\r\n\te.id_locador AS idLocador,\r\n\te.id_locatario AS idLocatario,\r\n\te.id_produto AS idProduto,\r\n\tlocador.nome AS nomeLocador,\r\n\tprod.nome AS nomeProduto,\r\n\te.data_inicio AS dataInicio,\r\n\te.data_fim AS dataFim,\r\n\te.status,\r\n\te.avaliacao,\r\n\te.comentario\r\nFROM toolbox.emprestimo AS e\r\nJOIN toolbox.usuario AS locador ON e.id_locador = locador.id\r\nJOIN toolbox.usuario AS locatario ON e.id_locatario = locatario.id\r\nJOIN toolbox.produto AS prod ON e.id_produto = prod.id WHERE e.id = {id};";
            List<Emprestimo> teste = _dbs.Query<Emprestimo>(sql);
            return teste;
        }

        public List<Emprestimo> GetEmprestimos()
        {
            string sql = $"SELECT\r\n\te.id AS idEmprestimo,\r\n\te.id_locador AS idLocador,\r\n\te.id_locatario AS idLocatario,\r\n\te.id_produto AS idProduto,\r\n\tlocador.nome AS nomeLocador,\r\n\tprod.nome AS nomeProduto,\r\n\te.data_inicio AS dataInicio,\r\n\te.data_fim AS dataFim,\r\n\te.status,\r\n\te.avaliacao,\r\n\te.comentario\r\nFROM toolbox.emprestimo AS e\r\nJOIN toolbox.usuario AS locador ON e.id_locador = locador.id\r\nJOIN toolbox.usuario AS locatario ON e.id_locatario = locatario.id\r\nJOIN toolbox.produto AS prod ON e.id_produto = prod.id;";
            List<Emprestimo> teste = _dbs.Query<Emprestimo>(sql);
            return teste;

        }
        public List<Comentario> GetComentario(int id)
        {
          string sql = $"select f2.nome, f1.avaliacao, f1.comentario from toolbox.emprestimo AS f1\r\ninner join toolbox.usuario AS f2 on f1.id_locador = f2.id where f1.id_produto = {id}";
          List<Comentario> teste = _dbs.Query<Comentario>(sql);
          return teste;

        }

        public List<Emprestimo> GetProdutosAlocados(int id)
        {
          string sql = $"SELECT e.id AS idEmprestimo, e.id_locador AS idLocador,e.id_locatario AS idLocatario,\r\ne.id_produto AS idProduto, locador.nome AS nomeLocador, prod.nome AS nomeProduto,\r\ne.data_inicio AS dataInicio, e.data_fim AS dataFim,\r\ne.status, e.avaliacao, e.comentario \r\nFROM toolbox.emprestimo AS e \r\nJOIN toolbox.usuario AS locador ON e.id_locador = locador.id\r\nJOIN toolbox.usuario AS locatario ON e.id_locatario = locatario.id\r\nJOIN toolbox.produto AS prod ON e.id_produto = prod.id where e.id_locador = {id}";
          List<Emprestimo> teste = _dbs.Query<Emprestimo>(sql);
          return teste;

        }
        public List<Emprestimo> GetProdutosDisponibilizado (int id)
        {
          string sql = $"SELECT e.id AS idEmprestimo, e.id_locador AS idLocador,e.id_locatario AS idLocatario,\r\ne.id_produto AS idProduto, locador.nome AS nomeLocador, prod.nome AS nomeProduto,\r\ne.data_inicio AS dataInicio, e.data_fim AS dataFim,\r\ne.status, e.avaliacao, e.comentario \r\nFROM toolbox.emprestimo AS e \r\nJOIN toolbox.usuario AS locador ON e.id_locador = locador.id\r\nJOIN toolbox.usuario AS locatario ON e.id_locatario = locatario.id\r\nJOIN toolbox.produto AS prod ON e.id_produto = prod.id where e.id_locatario = {id}";
          List<Emprestimo> teste = _dbs.Query<Emprestimo>(sql);
          return teste;

        }

    public int InsertEmprestimo(Emprestimo emprestimo)
        {
            string sql = $"INSERT INTO toolbox.emprestimo (id_locador, id_locatario, id_produto, data_inicio, data_fim, status, avaliacao, comentario) " +
                $"VALUES ({emprestimo.idLocador}, {emprestimo.idLocatario}, {emprestimo.idProduto}, '{DateTime.Now}', '{emprestimo.dataFim}', 'pendente', NULL, NULL);";
            var teste = _dbs.Execute<int>(sql);
            return teste;
        }

        public int UpdateAvaliacao(int id, int avaliacao)
        {
            string sql = $"UPDATE toolbox.emprestimo SET avaliacao={avaliacao} WHERE id={id};";
            var teste = _dbs.Execute<int>(sql);
            return teste;
        }
        public int UpdateStatus(int id, string status)
        {
          string sql = $"UPDATE toolbox.emprestimo SET status={status} WHERE id={id};";
          var teste = _dbs.Execute<int>(sql);
          return teste;
        }

        public int UpdateDataDevolucao(int id, string dataFim)
        {
            string sql = $"UPDATE toolbox.emprestimo SET data_fim = '{dataFim}' WHERE id={id};";
            var teste = _dbs.Execute<int>(sql);
            return teste;
        }
    }
}
