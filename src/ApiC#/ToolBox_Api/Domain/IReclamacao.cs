using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Domain
{
    public interface IReclamacao
    {
        public List<Reclamacao> GetReclamacoes();
        public List<Reclamacao> GetReclamacao(int id);
        public bool InsertReclamacao(Reclamacao reclamacao);
    }
}