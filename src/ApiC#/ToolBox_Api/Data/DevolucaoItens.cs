using ToolBox_Api.Dao;
using ToolBox_Api.Domain;
using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Data
{
  public class DevolucaoItens : IDevolucaoItens
  {
    IDbsConexao _dbs = DbsFactory.Create();
    public int DeleteDevolucao(int id)
    {
      string sql = "";
      var usuario = _dbs.Execute<int>(sql);
      return usuario;
    }

    public List<ProdutoDevolucao> GetDevolucao(int id)
    {
      string sql = $"Select f1.id, nome, data_inicio, data_fim, status  from toolbox.emprestimo As f1 " +
        $"LEFT JOIN toolbox.produto AS f2 ON f2.id = f1.id_produto "+
        $"where f1.id_locatario={id}";
      List<ProdutoDevolucao> produto = _dbs.Query<ProdutoDevolucao>(sql);
      return produto;
    }

    public bool InsertDevolucao(ProdutoDevolucao produto)
    {
      string sql = $" INSERT INTO toolbox.emprestimo (id_locador, id_locatario, id_produto, data_inicio, data_fim, status, avaliacao, comentario) " +
               $" VALUES ()";
      bool retorno = _dbs.Execute<bool>(sql);
      return retorno;
    }

    public int UpdateDevolucao(int id, ProdutoDevolucao iten)
    {
      return 0;
    }

  }
}
