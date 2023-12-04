namespace ToolBox_Api.Domain.Model
{
    public class Emprestimo
    {
        public int idEmprestimo { get; set; }
        public int? idLocador { get; set; }
        public int? idLocatario { get; set; }
        public int? idProduto { get; set; }
        public string? nomeLocador { get; set; }
        public string? nomeProduto { get; set; }
        public string? dataInicio { get; set; }
        public string? dataFim { get; set; }
        public string? status { get; set; }
        public int? avaliacao { get; set;}
        public string? comentario { get; set; }
    }
    public class Comentario
    {
      public string nome { get; set; }
      public string comentario { get; set; }
      public int avaliacao { get; set; }
    }
}
