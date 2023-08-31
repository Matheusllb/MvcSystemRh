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
                        {
                            _idPessoa = Convert.ToInt32(reader["f.IdPessoa"]),
                            _idFuncionario = Convert.ToInt32(reader["f.IdFuncionario"]),
                            _ativo = Convert.ToBoolean(reader["f.Ativo"]),
                            _endereco = reader["p.Endereco"].ToString(),
                            _nome = reader["p.Nome"].ToString(),
                            _cpf = reader["p.Cpf"].ToString(),
                            _dataNascimento = Convert.ToDateTime(reader["p.DataNascimento"]),
                            _estadoCivil = reader["p.EstadoCivil"].ToString(),
                            _email = reader["f.Email"].ToString(),
                            _dataAdmissao = Convert.ToDateTime(reader["f.DataAdmissao"]),
                            _idEmpresa = Convert.ToInt32(reader["f.IdEmpresa"]),
                            _cargo = reader["f.Cargo"].ToString(),
                            _salarioBruto = Convert.ToDecimal(reader["f.SalarioBruto"]),
                        };

                        funcionarios.Add(funcionario);
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

            return funcionarios;
        }
    }
}