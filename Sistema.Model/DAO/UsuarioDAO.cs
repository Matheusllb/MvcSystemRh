using System.Data.SqlClient;
using Sistema.Model.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sistema.Model.Entidades.Enum;

namespace Sistema.Model.DAO
{
    public class UsuarioDAO : AbstractDAO<UsuarioDAO>
    {
        public bool Logar(string usuario, string senha)
        {
            try
            {
                using (SqlConnection connection = connectionManager.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Usuario WHERE Login = @user AND Senha = @password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user", usuario); // Atribui o valor do usuário
                        command.Parameters.AddWithValue("@password", senha); // Atribui o valor da senha

                        int count = (int)command.ExecuteScalar();

                        return count > 0; // Retorna true se houver correspondência, senão, retorna false
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection();
            }
        }
    }
}