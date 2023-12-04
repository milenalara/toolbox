using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Domain
{
  public interface IDevolucaoItens
  {
    public List<ProdutoDevolucao> GetDevolucao(int id);
    public bool InsertDevolucao(ProdutoDevolucao iten);
    public int UpdateDevolucao(int id, ProdutoDevolucao iten);
    public int DeleteDevolucao(int id);
  }
}
