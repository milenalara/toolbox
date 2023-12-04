namespace ToolBox_Api.Dao
{
    public interface IDbsConexao
    {
        T Execute<T>(string sql, object parameters = null);
        List<T> Query<T>(string sql, object parameters = null);
        T query<T>(string sql, object parameters = null);
        void Execute(string sql, object parameters = null);
    }
}
