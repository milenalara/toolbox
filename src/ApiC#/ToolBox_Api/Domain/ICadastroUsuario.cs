using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Domain
{
    public interface ICadastroUsuario
    {
        public int DeleteUsuario(int id);
        public List<Usuario> GetUsuario();
        public List<Usuario> GetUsuario(int id);
        public int InsertUsuario(Usuario usuario);
        public int UpdateUsuario(int id, Usuario usuario);
        public List<int> GetLoginUsuario(string email, string senha);

  }
}
