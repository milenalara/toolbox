using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using ToolBox_Api.Dao;
using ToolBox_Api.Domain;
using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Data
{
    internal class CadastroReclamacao : IReclamacao
    {
        IDbsConexao _dbs = DbsFactory.Create();

        public int DeleteReclamacao(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reclamacao> GetReclamacao(int id)
        {
            string sql = $"SELECT\n\tid AS idReclamacao,\n\tid_emprestimo AS idEmprestimo,\n\tdescricao,\n\tcondicao\nFROM toolbox.reclamacao; WHERE id_emprestimo = {id};";
            List<Reclamacao> teste = _dbs.Query<Reclamacao>(sql);
            return teste;

        }

        public List<Reclamacao> GetReclamacoes()
        {
            string sql = $"SELECT\n\tid AS idReclamacao,\n\tid_emprestimo AS idEmprestimo,\n\tdescricao,\n\tcondicao\nFROM toolbox.reclamacao;";
            List<Reclamacao> teste = _dbs.Query<Reclamacao>(sql);
            return teste;

        }

        public bool InsertReclamacao(Reclamacao reclamacao)
        {

            string sql = $"INSERT INTO toolbox.reclamacao (id_emprestimo, descricao, condicao) VALUES ({reclamacao.idEmprestimo}, '{reclamacao.Descricao}', '{reclamacao.Condicao}');";
            var teste = _dbs.Execute<int>(sql);
            if (teste == 0)
                return true;
            else
                return false;
        }
    }
}
