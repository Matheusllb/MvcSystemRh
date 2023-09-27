using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Sistema.Model.DAO
{
    public class DbConnectionManager
    {
        private SqlConnection connection;
        private string connectionString = @"Server=DESKTOP-ROV30U;Database=MvcSystemRh;Integrated Security=True;"; //Trocar para suas informações

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
            catch(Exception ex) 
            { 
                Console.WriteLine("Connection Failed: " + ex.Message);
                return connection;
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
            }catch (Exception ex)
            {
                Console.WriteLine("Connection Failed: " + ex.Message);
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