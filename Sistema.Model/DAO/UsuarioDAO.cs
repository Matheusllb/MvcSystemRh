using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using Sistema.Model.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
                        {
                            _idPessoa = Convert.ToInt32(reader["u.IdPessoa"]),
                            _endereco = reader["p.Endereco"].ToString(),
                            _nome = reader["p.Nome"].ToString(),
                            _cpf = reader["p.Cpf"].ToString(),
                            _dataNascimento = Convert.ToDateTime(reader["p.DataNascimento"]),
                            _estadoCivil = reader["p.EstadoCivil"].ToString(),
                            _idUsuario = Convert.ToInt32(reader["u.IdUsuario"]),
                            _ativo = Convert.ToBoolean(reader["u.Ativo"]),
                            _login = reader["u.Login"].ToString(),
                            _senha = reader["u.Senha"].ToString(),
                        };

                        usuarios.Add(usuario);
                    }

                    reader.Close();
                }

                catch (Exeption ex)
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
    }
}