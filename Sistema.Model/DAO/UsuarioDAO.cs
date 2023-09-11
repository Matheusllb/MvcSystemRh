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
    public class UsuarioDAO
    {
        private DbConnectionManager _connectionManager;

        public UsuarioDAO()
        {
            _connectionManager = new DbConnectionManager();
        }

        public List<Usuario> GetAllUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = _connectionManager.GetConnection())
            {
                string query = "SELECT u.IdPessoa, p.Endereco, p.Nome, p.Cpf, p.DataNascimento, p.EstadoCivil, u.IdUsuario, u.Ativo, u.Login, u.Senha FROM Usuario u JOIN Pessoa p ON u.IdPessoa = p.IdPessoa;";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    _connectionManager.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario
                        (
                            Convert.ToInt32(reader["u.IdPessoa"]),
                            reader["p.Endereco"].ToString(),
                            reader["p.Nome"].ToString(),
                            reader["p.Cpf"].ToString(),
                            Convert.ToDateTime(reader["p.DataNascimento"]),
                            (EstadoCivil)Enum.Parse(typeof(EstadoCivil), reader["p.EstadoCivil"].ToString()),
                            Convert.ToInt32(reader["u.IdUsuario"]),
                            Convert.ToBoolean(reader["u.Ativo"]),
                            reader["u.Login"].ToString(),
                            reader["u.Senha"].ToString()
                        );

                        usuarios.Add(usuario);
                    }

                    reader.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine("An error occured: " + ex.Message);
                }
                finally
                {
                    _connectionManager.CloseConnection();
                }
            }

            return usuarios;
        }

        public bool Logar(string nomeUsuario, string senha)
        {
            if(nomeUsuario == "User" && senha == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}