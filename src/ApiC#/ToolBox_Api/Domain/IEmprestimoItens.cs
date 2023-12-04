using ToolBox_Api.Domain.Model;


namespace ToolBox_Api.Domain
{
  public interface IEmprestimoItens
  {
        public List<Emprestimo> GetEmprestimos();
        public List<Comentario> GetComentario(int id);
        public List<Emprestimo> GetProdutosAlocados(int id);
        public List<Emprestimo> GetProdutosDisponibilizado(int id);
        public List<Emprestimo> GetEmprestimo(int id);
        public int InsertEmprestimo(Emprestimo emprestimo);
        public int UpdateAvaliacao(int id, int avaliacao);
        public int UpdateStatus(int id, string status);
        public int UpdateDataDevolucao(int id, string dataFim);
    }
}
