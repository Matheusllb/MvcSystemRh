using System;
using System.Data.SqlClient;

namespace Sistema.Model.DAO
{
    public class DbConnectionManager
    {
        private SqlConnection _connection;
        private string _connectionString = "Data Source=pimserverads.database.windows.net;Initial Catalog=pim;Persist Security Info=True;User ID=pim;Password=Ads2023@@";
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
                throw ex;
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
                throw ex;
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