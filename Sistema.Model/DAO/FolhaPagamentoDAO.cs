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
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@searchTerm", searchTerm);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FolhaPagamento folhaPagamento = MapData(reader);
                        filteredData.Add(folhaPagamento);
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
                reader["Funcionario"] != DBNull.Value &&
                reader["SalarioINSS"] != DBNull.Value &&
                reader["ValorFGTS"] != DBNull.Value &&
                reader["Ativo"] != DBNull.Value &&
                reader["ValorIRRF"] != DBNull.Value)
            {
                int vIdF = (int)reader["Id"];
                int vIdEmpresa = (int)reader["IdEmpresa"];
                DateTime vDataFechamento = (DateTime)reader["DataFechamento"];
                DateTime vDataPagamento = (DateTime)reader["DataPagamento"];
                decimal vTotalVencimentos = (decimal)reader["TotalVencimentos"];
                decimal vTotalDescontos = (decimal)reader["TotalDescontos"];
                decimal vTotalLiquido = (decimal)reader["TotalLiquido"];

                Funcionario funcionario = new Funcionario
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

                decimal vSalarioINSS = (decimal)reader["SalarioINSS"];
                decimal vValorFGTS = (decimal)reader["ValorFGTS"];
                decimal vValorIRRF = (decimal)reader["ValorIRRF"];
                List<string> itens = new List<string>();

                FolhaPagamento folha = new FolhaPagamento
                {
                    Id = vIdF,
                    IdEmpresa = vIdEmpresa,
                    DataFechamento = vDataFechamento,
                    DataPagamento = vDataPagamento,
                    TotalVencimentos = vTotalVencimentos,
                    TotalDescontos = vTotalDescontos,
                    TotalLiquido = vTotalLiquido,
                    Funcionario = funcionario,
                    SalarioINSS = vSalarioINSS,
                    ValorFGTS = vValorFGTS,
                    ValorIRRF = vValorIRRF,
                    Itens = itens
                };

                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    string query = @"
                    SELECT bd.Descricao, bd.Valor, bd.Desconto
                    FROM BDFuncionario bdf
                    JOIN BeneficioDesconto bd ON bdf.Id = bd.Id
                    WHERE bdf.Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", folha.Id);

                        using (SqlDataReader itemReader = command.ExecuteReader())
                        {
                            while (itemReader.Read())
                            {
                                string descricao = itemReader["Descricao"].ToString();
                                decimal valor = (decimal)itemReader["Valor"];
                                bool desconto = (bool)itemReader["Desconto"];

                                // Adiciona "(desconto)" ou "(benefício)" com base no valor "desconto"
                                string tipoItem = desconto ? "(desconto)" : "(benefício)";

                                // Cria a representação completa do item
                                string itemFormatado = $"Descrição: \"{descricao} {tipoItem}\", Valor: {(desconto ? "-" : "+")}{valor.ToString("0.00")}";

                                // Adiciona o item formatado à lista de itens
                                folha.Itens.Add(itemFormatado);
                            }
                        }
                    }
                }

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
