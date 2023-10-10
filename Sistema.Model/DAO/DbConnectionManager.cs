using System;
using System.Data.SqlClient;

namespace Sistema.Model.DAO
{
    public class DbConnectionManager
    {
        private SqlConnection connection;
        private string connectionString = "Data Source=mvcsystemrh.database.windows.net;Initial Catalog=MvcSystemRh;Persist Security Info=True;User ID=pim;Password=Ads2023@@";
        public DbConnectionManager()
        {
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
                Console.WriteLine("Falha na conexão (Model): " + ex.Message);
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
                Console.WriteLine("Conexão falhou (Model): " + ex.Message);
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