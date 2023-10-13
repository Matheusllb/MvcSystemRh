using System;
using System.Data.SqlClient;

namespace Sistema.Model.DAO
{
    public class DbConnectionManager
    {
        private SqlConnection _connection;
        private string _connectionString = "Data Source=mvcsystemrh.database.windows.net;Initial Catalog=MvcSystemRh;Persist Security Info=True;User ID=pim;Password=Ads2023@@";
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