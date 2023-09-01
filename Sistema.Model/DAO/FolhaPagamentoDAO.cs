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
    public class FolhaPagamentoDAO
    {
        private DbConnectionManager _connectionManager;

        public FolhaPagamentoDAO()
        {
            _connectionManager = new DbConnectionManager();
        }

        public List<FolhaPagamento> GetAllFolhas()
        {
            List<FolhaPagamento> folhas = new List<FolhaPagamento>();

            using (SqlConnection connection = _connectionManager.GetConnection())
            {
                string query = "SELECT fP.IdFolhaPag, fP.IdEmpresa, fP.DataFechamento, fP.DataPagamento, fP.TotalVencimentos, fP.TotalDescontos, fP.TotalLiquido, f.IdPessoa, f.IdFuncionario, f.Ativo, p.Endereco, p.Nome, p.Cpf, p.DataNascimento, p.EstadoCivil, f.Email, f.DataAdmissao, f.Cargo, f.SalarioBruto, bF.IdFuncionario, bF.IdBeneficioDesconto, bD.Descricao FROM FolhaPagamento fP JOIN Funcionario f ON fP.IdFuncionario = f.IdFuncionario JOIN Pessoa p ON f.IdPessoa = p.IdPessoa JOIN BDFuncionario bF ON f.IdFuncionario = bF.IdFuncionario JOIN BeneficioDesconto bD ON bD.IdBeneficioDesconto = bF.IdBeneficioDesconto";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    _connectionManager.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        FolhaPagamento folha = new FolhaPagamento
                        {
                            _idFolha = Convert.ToInt32(reader["fP.IdFolhaPag"]),
                            _idEmpresa = Convert.ToInt32(reader["fP.IdFolhaPag"]),
                            _dataFechamento = Convert.ToInt32(reader["fP.IdFolhaPag"]),
                            _dataPagamento = Convert.ToInt32(reader["fP.IdFolhaPag"]),
                            _funcionario = null,
                            _itens = Convert.ToString(reader["bD.Descricao"]),
                        };
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

                        folha._funcionario = funcionario;
                        folhas.Add(folha);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured: " + ex.Message);
                }
                finally { _connectionManager.CloseConnection(); }
            }

            return folhas;
        }        
    }
}
