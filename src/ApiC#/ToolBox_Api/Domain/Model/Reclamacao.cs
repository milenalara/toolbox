using System.Globalization;

namespace ToolBox_Api.Domain.Model
{
    public class Reclamacao
    {
        public int? idReclamacao { get; set; } 
        public int? idEmprestimo { get; set; }
        public string? Condicao { get; set; }
        public string? Descricao { get; set; }
    }
}
