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
                        (
                            Convert.ToInt32(reader["fP.IdFolhaPag"]),
                            Convert.ToInt32(reader["fP.IdEmpresa"]),
                            Convert.ToDateTime(reader["fP.DataFechamento"]),
                            Convert.ToDateTime(reader["fP.DataPagamento"])
                        );
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

                        folha.SetFuncionarioEmFolha(funcionario);
                        folhas.Add(folha);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occured: " + ex.Message);
                }
                finally { _connectionManager.CloseConnection(); }
            }

            return folhas;
        }        
    }
}
