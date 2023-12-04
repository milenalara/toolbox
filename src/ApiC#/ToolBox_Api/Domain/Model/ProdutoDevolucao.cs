namespace ToolBox_Api.Domain.Model
{
  public class ProdutoDevolucao
  {
        public int id { get; set; } 
        public string? nome { get; set; }
        public string? data_inicio { get; set; }
        public string? data_fim { get; set; }
        public string? status { get; set; }
    }
  public class ProdutosEmprestimo : ProdutoDevolucao
  {
    public int id_locador { get; set; }
    public int id_locatario { get; set; }
    public int id_produto { get; set; }
    public string? avaliacao { get; set; }
    public string? comentario { get; set; }
  }
}
