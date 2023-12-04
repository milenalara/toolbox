using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Domain
{
    public interface ICadastroItens
    {
        public List<Itens> GetItens();
        public List<Itens> GetItens(int id);
        public bool InsertItens(Itens iten);
        public int UpdateItens(int id, Itens iten);
        public int DeleteItens(int id);
    }
}
