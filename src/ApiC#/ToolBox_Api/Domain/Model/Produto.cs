namespace ToolBox_Api.Domain.Model
{
    public class Produto
    {
        public string Id { get; set; } 
        public string? Nome { get; set; }
        public string? Condicao { get; set; }
        public string? Marca { get; set; }
        public string? Descricao { get; set; }
        public double? Preco { get; set; }
        public List<byte[]>? Imagens { get; set; }
        public long? IdCategoria { get; set; }
        public string? Categoria { get; set; }
        public string? id_usuario { get; set; }
    }
}
