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
                            _id = Convert.ToInt32(reader["f.IdPessoa"]),
                            _idFuncionario = Convert.ToInt32(reader["f.IdFuncionario"]),
                            _ativo = reader["Cnpj"].ToString(),
                            _endereco = reader["Setor"].ToString(),
                            _nome = reader["Email"].ToString(),
                            _cpf = reader["Telefone"].ToString(),
                            _dataNascimento = reader["Endereco"].ToString(),
                            _estadoCivil = reader["Endereco"].ToString(),
                            _email = reader["Endereco"].ToString(),
                            _dataAdmissao = reader["Endereco"].ToString(),
                            _idEmpresa = reader["Endereco"].ToString(),
                            _cargo = reader["Endereco"].ToString(),
                            _salarioBruto = reader["Endereco"].ToString(),

                        };

                        empresas.Add(empresa);
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

            return empresas;
        }
        }
    }
}