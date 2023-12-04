using NPOI.SS.Formula.Functions;
using System.Globalization;

namespace ToolBox_Api.Domain.Model
{
  public class Itens
  {
    public int id {  get; set; }
    public string? nome { get; set; }
    public string? Condicao { get; set; } 
    public string? marca { get; set; }
    public string? Descricao { get; set; }
    public double? Preco { get; set; }
    public string? path { get; set; }
    public int? id_categoria { get; set; }
    public string? nome_categoria { get; set; }
    public int id_usuario { get; set; }
    }
}
 