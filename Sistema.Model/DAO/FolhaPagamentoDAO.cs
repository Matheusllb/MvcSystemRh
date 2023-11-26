using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using Sistema.Model.Entidades.Enum;
using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

public class FolhaPagamentoDAO : DAO<FolhaPagamento>, IFolhaPagamentoDAO
{
    public FolhaPagamentoDAO() : base("FolhaPagamento")
    {
        SecondTable = "Funcionario";
        ThirdTable = "Pessoa";
        FourthTable = "BDFuncionario";
        FifthTable = "BeneficioDesconto";
    }

    public List<FolhaPagamento> ProcuraFolhaPorDataFechamento(DateTime fechamento)
    {
        List<FolhaPagamento> folhasEncontradas = new List<FolhaPagamento>();

        using (SqlConnection connection = ConnectionManager.GetConnection())
        {
            string query = "SELECT * FROM FolhaPagamento WHERE DataFechamento = @DataFechamento;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DataFechamento", fechamento);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FolhaPagamento folhaPagamento = MapData(reader);
                        folhasEncontradas.Add(folhaPagamento);
                    }
                }
            }
        }

        return folhasEncontradas;
    }

    public List<FolhaPagamento> ProcuraFolhaPorDataPagamento(DateTime pagamento)
    {
        List<FolhaPagamento> folhasEncontradas = new List<FolhaPagamento>();

        using (SqlConnection connection = ConnectionManager.GetConnection())
        {
            string query = "SELECT * FROM FolhaPagamento WHERE DataPagamento = @DataPagamento;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DataPagamento", pagamento);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FolhaPagamento folhaPagamento = MapData(reader);
                        folhasEncontradas.Add(folhaPagamento);
                    }
                }
            }
        }

        return folhasEncontradas;
    }

    public override List<FolhaPagamento> FilterData(string searchTerm)
    {
        List<FolhaPagamento> filteredData = new List<FolhaPagamento>();

        using (SqlConnection connection = ConnectionManager.GetConnection())
        {
            string query = @"
                            SELECT
                                fP.IdFolhaPag, fP.IdEmpresa, fP.DataFechamento, fP.DataPagamento, fP.TotalVencimentos, fP.TotalDescontos, fP.TotalLiquido,
                                f.IdPessoa, f.IdFuncionario, f.Ativo, p.Endereco, p.Nome, p.Cpf, p.DataNascimento, p.EstadoCivil, f.Email, f.DataAdmissao, f.Cargo, f.SalarioBruto,
                                bF.IdFuncionario,~bF.IdBeneficioDesconto,
                                bD.Descricao, bD.Valor, bD.Desconto
                            FROM FolhaPagamento fP
                            JOIN Funcionario f ON fP.IdFuncionario = f.IdFuncionario
                            JOIN Pessoa p ON f.IdPessoa = p.IdPessoa
                            JOIN BDFuncionario bF ON f.IdFuncionario = bF.IdFuncionario
                            JOIN BeneficioDesconto bD ON bD.IdBeneficioDesconto = bF.IdBeneficioDesconto
                            WHERE LOWER(p.Nome) LIKE @searchTerm OR LOWER(bD.Descricao) LIKE @searchTerm";
            searchTerm = $"%{searchTerm}%";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                ConnectionManager.OpenConnection();

                command.Parameters.AddWithValue("@searchTerm", searchTerm);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        filteredData.Add(MapData(reader));
                    }
                }
            }
        }

        return filteredData;
    }

    public override FolhaPagamento MapData(SqlDataReader reader)
    {
        try
        {
            if (reader["Id"] != DBNull.Value &&
                reader["IdEmpresa"] != DBNull.Value &&
                reader["DataFechamento"] != DBNull.Value &&
                reader["DataPagamento"] != DBNull.Value &&
                reader["TotalVencimentos"] != DBNull.Value &&
                reader["TotalDescontos"] != DBNull.Value &&
                reader["TotalLiquido"] != DBNull.Value &&
                reader["IdFuncionario"] != DBNull.Value &&
                reader["SalarioINSS"] != DBNull.Value &&
                reader["ValorFGTS"] != DBNull.Value &&
                reader["Ativo"] != DBNull.Value)
            {
                int vId = (int)reader["Id"];
                int vIdEmpresa = (int)reader["IdEmpresa"];
                DateTime vDataFechamento = (DateTime)reader["DataFechamento"];
                DateTime vDataPagamento = (DateTime)reader["DataPagamento"];
                decimal vTotalVencimentos = (decimal)reader["TotalVencimentos"];
                decimal vTotalDescontos = (decimal)reader["TotalDescontos"];
                decimal vTotalLiquido = (decimal)reader["TotalLiquido"];

                Funcionario funcionario = null;
                if (reader["Id"] != DBNull.Value &&
                    reader["IdPessoa"] != DBNull.Value &&
                    reader["Email"] != DBNull.Value &&
                    reader["DataAdmissao"] != DBNull.Value &&
                    reader["IdEmpresa"] != DBNull.Value &&
                    reader["Cargo"] != DBNull.Value &&
                    reader["SalarioBruto"] != DBNull.Value &&
                    reader["Ativo"] != DBNull.Value &&
                    reader["Endereco"] != DBNull.Value &&
                    reader["Nome"] != DBNull.Value &&
                    reader["Cpf"] != DBNull.Value &&
                    reader["DataNascimento"] != DBNull.Value &&
                    reader["EstadoCivil"] != DBNull.Value)
                {
                    if (!(bool)reader["Ativo"])
                    {
                        funcionario = null;
                    }
                    else
                    {
                        funcionario = new Funcionario
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdPessoa = Convert.ToInt32(reader["IdPessoa"]),
                            Email = reader["Email"].ToString(),
                            DataAdmissao = Convert.ToDateTime(reader["DataAdmissao"]),
                            IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]),
                            Cargo = reader["Cargo"].ToString(),
                            SalarioBruto = Convert.ToDecimal(reader["SalarioBruto"]),
                            CPF = reader["Cpf"].ToString(),
                            Endereco = reader["Endereco"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                            EstadoCivilP = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), reader["EstadoCivil"].ToString()),
                            Ativo = Convert.ToBoolean(reader["Ativo"]),
                        };
                    }
                }
                else
                {
                    funcionario = null;
                }

                decimal vSalarioINSS = (decimal)reader["SalarioINSS"];
                decimal vValorFGTS = (decimal)reader["ValorFGTS"];
                List<string> itens = new List<string>();

                FolhaPagamento folha = new FolhaPagamento(vId, vIdEmpresa, vDataFechamento, vDataPagamento, vTotalVencimentos, vTotalDescontos, vTotalLiquido, funcionario, vSalarioINSS, vValorFGTS, itens);

                do
                {
                    if (reader["Descricao"] != DBNull.Value && reader["Valor"] != DBNull.Value && reader["Desconto"] != DBNull.Value)
                    {
                        string descricao = reader["Descricao"].ToString();
                        decimal valor = (decimal)reader["Valor"];
                        bool desconto = (bool)reader["Desconto"];

                        string tipoItem = desconto ? "(desconto)" : "(benefício)";

                        string itemFormatado = $"Descrição: \"{descricao} {tipoItem}\", Valor: {(desconto ? "-" : "+")}{valor.ToString("0.00")}";

                        folha.Itens.Add(itemFormatado);

                    }
                    else
                    {
                        return null;
                    }

                } while (reader.Read());

                return folha;

            }
            else
            {
                return null;
            }
        }
        catch (InvalidCastException ex)
        {
            throw ex;
        }
    }

}




