using Dapper;
using System.Data;
using ToolBox_Api.Domain.Model;

namespace ToolBox_Api.Dao
{
    internal class DbsConexao : IDbsConexao
    {
        private readonly IDbConnection _connection;
        public DbsConexao(IDbConnection connection)
        {
            _connection = connection;
        }
        public T Execute<T>(string sql, object? parameters)
        {
            return _connection.QueryFirstOrDefault<T>(sql, parameters);
        }

        public List<T> Query<T>(string sql, object? parameters)
        {
            return (List<T>)_connection.Query<T>(sql, parameters);
        }
        public T query<T>(string sql, object? parameters)
        {
          return (T)_connection.Query<T>(sql, parameters);
        }

        public void Execute(string sql, object? parameters)
            {
                _connection.Execute(sql, parameters);
            }
        }
}
