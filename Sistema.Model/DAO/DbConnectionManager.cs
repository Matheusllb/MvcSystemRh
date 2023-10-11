using System;
using System.Data.SqlClient;

namespace Sistema.Model.DAO
{
    public class DbConnectionManager
    {
        private SqlConnection _connection;
        private string _connectionString = "Server=tcp:mvcsystemrh.database.windows.net,1433;Initial Catalog=MvcSystemRh;Persist Security Info=False;User ID=pim;Password=Ads2023@@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public DbConnectionManager()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public SqlConnection GetConnection()
        {
            try
            {
                return _connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha na conexão: " + ex.Message);
                return null; // Retorna null em caso de falha na conexão
            }
        }

        public void OpenConnection()
        {
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Conexão falhou: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Close();
            }
        }
    }
}