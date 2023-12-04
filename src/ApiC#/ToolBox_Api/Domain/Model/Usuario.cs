namespace ToolBox_Api.Domain.Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set;}
        public string? senha { get; set; }
        public string? logradouro { get; set; }
        public int numero_endereco { get; set; }
        public string? bairro { get; set; }
        public string? cidade { get; set;}
        public string? estado { get; set;}
        public string? cep { get; set;}
        public string? numero_telefone { get; set;}
        public int DDD { get; set;}
    }
}
