namespace ToolBox_Api.Dao
{
    public static class DbsFactory
    {
        public static IDbsConexao Create()
        {
            return new DbsConexao(DbsConnection.Connection);
        }
    }
}
