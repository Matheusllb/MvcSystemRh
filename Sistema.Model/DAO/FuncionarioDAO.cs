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
    public class FuncionarioDAO
    {
        private DbConnectionManager _connectionManager;

        public FuncionarioDAO()
        {
            _connectionManager = new DbConnectionManager();
        }

        public List<Funcionario> GetAllFuncionarios()
        {
            List<Funcionario> funcionarios = new List<Funcionario> ();

            using (SqlConnection connection = _connectionManager.GetConnection())
            {
                string query = "SELECT f.IdPessoa, f.IdFuncionario, f.Ativo, p.Endereco, p.Nome, p.Cpf, p.DataNascimento, p.EstadoCivil, f.Email, f.DataAdmissao, f.IdEmpresa, f.Cargo, f.SalarioBruto FROM Funcionario f JOIN Pessoa p ON f.IdPessoa = p.IdPessoa;";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    _connectionManager.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Funcionario funcionario = new Funcionario
                        (
                            Convert.ToInt32(reader["f.IdPessoa"]),
                            Convert.ToInt32(reader["f.IdFuncionario"]),
                            Convert.ToBoolean(reader["f.Ativo"]),
                            reader["p.Endereco"].ToString(),
                            reader["p.Nome"].ToString(),
                            reader["p.Cpf"].ToString(),
                            Convert.ToDateTime(reader["p.DataNascimento"]),
                            (EstadoCivil)Enum.Parse(typeof(EstadoCivil), reader["p.EstadoCivil"].ToString()),
                            reader["f.Email"].ToString(),
                            Convert.ToDateTime(reader["f.DataAdmissao"]),
                            Convert.ToInt32(reader["f.IdEmpresa"]),
                            reader["f.Cargo"].ToString(),
                            Convert.ToDecimal(reader["f.SalarioBruto"])
                        );

                        funcionarios.Add(funcionario);
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

            return funcionarios;
        }
    }
}