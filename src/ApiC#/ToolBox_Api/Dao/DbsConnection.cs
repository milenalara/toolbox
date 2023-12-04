using Microsoft.AspNetCore.DataProtection;
using System.Data;
using System.Data.SqlClient;

namespace ToolBox_Api.Dao
{
    public class DbsConnection
    {
        private static readonly string _connectionString = "Data Source=mlrferreira.database.windows.net;Initial Catalog=puc-minas-tis;User ID=mlrferreira;Password=E&SV7tD2X$s^mkQBMn";
        private static IDbConnection _connection;



        public static IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }
    }
}
