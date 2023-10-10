using System;
using System.Data.SqlClient;

namespace Sistema.Model.DAO
{
    public class DbConnectionManager
    {
        private SqlConnection connection;
        private string connectionString = null;
        public DbConnectionManager()
        {
            connectionString = "Server=tcp:mvcsystemrh.database.windows.net,1433;Initial Catalog=MvcSystemRh;Persist Security Info=False;User ID=pim;Password=Ads2023@@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnection()
        {
            try
            {
                return connection;
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
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Conexão falhou: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}