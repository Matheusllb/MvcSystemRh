using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using Sistema.Model.Entidades.Enum;
using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

public class FolhaPagamentoDAO : DAO<FolhaPagamento>
{
    public FolhaPagamentoDAO(DbConnectionManager connectionManager) : base(connectionManager, "FolhaPagamento")
    {
        data = LoadDataFromDatabase(connectionManager, "FolhaPagamento");
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

    public override object[] GetHeaders()
    {
        string[] headers = { "Id", "IdEmpresa", "DataFechamento", "DataPagamento", "TotalVencimentos", "TotalDescontos", "TotalLiquido", "Funcionario", "SalarioINSS", "ValorFGTS", "ValorIRRF", "Itens" };
        return headers;
    }

    public override void SetData(List<FolhaPagamento> data)
    {
        this.data = data;
    }

    protected override FolhaPagamento MapData(SqlDataReader reader)
    {
        FolhaPagamento folhaPagamento = new FolhaPagamento
        {
            Id = (int)reader["Id"],
        };
        folhaPagamento.SetIdEmpresaEmFolha((int)reader["IdEmpresa"]);
        folhaPagamento.SetDataFechamentoEmFolha((DateTime)reader["DataFechamento"]);
        folhaPagamento.SetDataPagamentoEmFolha((DateTime)reader["DataPagamento"]);
        folhaPagamento.SetTotalVencimentosEmFolha((decimal)reader["TotalVencimentos"]);
        folhaPagamento.SetTotalDescontosEmFolha((decimal)reader["TotalDescontos"]);
        folhaPagamento.SetTotalLiquidoEmFolha((decimal)reader["TotalLiquido"]);
        //Mapeamento de funcionario
        Funcionario funcionario = new Funcionario
        {
            Id = (int)reader["IdPessoa"],
        };
        funcionario.SetIdFuncionario((int)reader["IdFuncionario"]);
        funcionario.SetAtivo((bool)reader["Ativo"]);
        funcionario.SetNomePessoa((string)reader["Nome"]);
        funcionario.SetCpfPessoa((string)reader["Cpf"]);
        funcionario.SetDataNascimentoPessoa((DateTime)reader["DataNascimento"]);
        funcionario.SetEstadoCivilPessoa((EstadoCivil)Enum.Parse(typeof(EstadoCivil), reader["EstadoCivil"].ToString()));
        funcionario.SetEmailFuncionario((string)reader["Email"]);
        funcionario.SetDataAdmissaoFuncionario((DateTime)reader["DataAdmissao"]);
        funcionario.SetIdEmpresaFuncionario((int)reader["IdEmpresa"]);
        funcionario.SetCargoFuncionario((string)reader["Cargo"]);
        funcionario.SetSalarioBrutoFuncionario((decimal)reader["SalarioBruto"]);
        //Continuando a mapear folha
        folhaPagamento.SetFuncionarioEmFolha(funcionario);
        folhaPagamento.SetSalarioINSSEmFolha((decimal)reader["SalarioINSS"]);
        folhaPagamento.SetFValorFGTSEmFolha((decimal)reader["ValorFGTS"]);
        folhaPagamento.SetValorIRRFEmFolha((decimal)reader["ValorIRRF"]);
        //Itens de folha
        List<string> listaItens = new List<string>();

        using (SqlConnection connection = ConnectionManager.GetConnection())
        {
            string query = @"
            SELECT bd.Descricao, bd.Valor, bd.Desconto
            FROM BDFuncionario bdf
            JOIN BeneficioDesconto bd ON bdf.IdBeneficioDesconto = bd.IdBeneficioDesconto
            WHERE bdf.IdFolhaPag = @IdFolhaPag";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdFolhaPag", folhaPagamento.Id);

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
                        listaItens.Add(itemFormatado);
                    }
                }
            }
        }

        folhaPagamento.SetItensEmFolha(listaItens);

        return folhaPagamento;
    }

}
