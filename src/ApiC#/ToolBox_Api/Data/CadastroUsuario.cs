using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ToolBox_Api.Dao;
using ToolBox_Api.Domain;
using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Data
{
    public class CadastroUsuario : ICadastroUsuario
    {
        IDbsConexao _dbs = DbsFactory.Create();
        public int DeleteUsuario(int id)
        {
            string sql = $"DELETE FROM usuario WHERE id_usuario = {id} " +
                $"DELETE FROM telefones WHERE id_usuario = {id} " +
                $"DELETE FROM enreco WHERE id_usuario = {id}";
            var usuario = _dbs.Execute<int>(sql);
            return usuario;
        }

        public List<Usuario> GetUsuario()
        {
            string sql = $"SELECT\r\n\tu.id, nome,\r\n\tcpf,\r\n\temail,\r\n\tsenha, \r\n\tlogradouro, \r\n\te.numero AS numero_endereco, \r\n\tbairro, \r\n\tcidade, \r\n\testado, \r\n\tcep, \r\n\tt.numero AS numero_telefone, \r\n\tcodigo_area AS ddd\r\nFROM toolbox.usuario AS u\r\nLEFT JOIN toolbox.endereco AS e ON u.id = e.id_usuario\r\nLEFT JOIN toolbox.telefone AS t ON u.id = t.id_usuario;";
            List<Usuario> usuario = _dbs.Query<Usuario>(sql);
            return usuario;
        }

        public List<Usuario> GetUsuario(int id)
        {
            string sql = $"SELECT\r\n\tu.id, nome,\r\n\tcpf,\r\n\temail,\r\n\tsenha, \r\n\tlogradouro, \r\n\te.numero AS numero_endereco, \r\n\tbairro, \r\n\tcidade, \r\n\testado, \r\n\tcep, \r\n\tt.numero AS numero_telefone, \r\n\tcodigo_area AS ddd\r\nFROM toolbox.usuario AS u\r\nLEFT JOIN toolbox.endereco AS e ON u.id = e.id_usuario\r\nLEFT JOIN toolbox.telefone AS t ON u.id = t.id_usuario\r\nWHERE u.id = {id};";
            List<Usuario> usuario = _dbs.Query<Usuario>(sql);
            return usuario;
        }

        public int InsertUsuario(Usuario usuario)
        {
            string sql = $"DECLARE @id INT " +
               $" insert into toolbox.usuario (nome, cpf, email, senha) " +
               $"values ('{usuario.Nome}', '{usuario.Cpf}', '{usuario.Email}', '{usuario.senha}') " +
               $" SET @id = SCOPE_IDENTITY()" +
               $"insert into toolbox.telefone (id_usuario, numero,codigo_area) values (@id,'{usuario.numero_telefone}', {usuario.DDD})" +
               $"insert into toolbox.endereco (id_usuario,logradouro,numero,bairro,cidade,estado,cep) values (@id, '{usuario.logradouro}', {usuario.numero_endereco}, '{usuario.bairro}', '{usuario.cidade}', '{usuario.estado}', '{usuario.cep}')";
            var teste = _dbs.Execute<int>(sql);
            return teste;
        }

        public int UpdateUsuario(int id, Usuario usuario)
        {
            string sql = $"UPDATE toolbox.usuario SET nome = '{usuario.Nome}', cpf = '{usuario.Cpf}', email = '{usuario.Email}', senha = '{usuario.senha}' WHERE id = {id}" +
                $"UPDATE toolbox.telefone SET numero = '{usuario.numero_telefone}', codigo_area = '{usuario.DDD}' WHERE id_usuario = {id}" +
                $"UPDATE toolbox.endereco SET logradouro = '{usuario.logradouro}', numero = '{usuario.numero_endereco}', bairro = '{usuario.bairro}', cidade = '{usuario.cidade}', estado = '{usuario.estado}', cep = '{usuario.cep}' WHERE id_usuario = {id}";
            var teste = _dbs.Execute<int>(sql);
            return teste;
        }

        public List<int> GetLoginUsuario(string email, string senha)
        {
            string sql = $"select id from toolbox.usuario where email = '{email}' and senha = '{senha}'";
            List<int> id = _dbs.Query<int>(sql);
            return id;
        }
    }
}
