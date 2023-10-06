using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using Sistema.Model.Entidades.Enum;
using Sistema.Model.Interfaces.IDAO;

public class FuncionarioDAO : DAO<Funcionario>, IFuncionarioDAO
{
    public FuncionarioDAO(DbConnectionManager connectionManager) : base(connectionManager, "Funcionario")
    {
        Data = LoadDataFromDatabase(connectionManager, "Funcionario");
    }

    public List<Funcionario> ProcuraFuncionarioPorNome(string nome)
    {
        List<Funcionario> funcionariosEncontrados = new List<Funcionario>();

        using (SqlConnection connection = ConnectionManager.GetConnection())
        {
            string query = "SELECT * FROM Funcionario WHERE Nome LIKE @Nome;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nome", "%" + nome + "%");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Funcionario funcionario = MapData(reader);
                        funcionariosEncontrados.Add(funcionario);
                    }
                }
            }
        }

        return funcionariosEncontrados;
    }

    public List<Funcionario> ProcuraFuncionarioPorCargo(string cargo)
    {
        List<Funcionario> funcionariosEncontrados = new List<Funcionario>();

        using (SqlConnection connection = ConnectionManager.GetConnection())
        {
            string query = "SELECT * FROM Funcionario WHERE Cargo = @Cargo;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Cargo", cargo);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Funcionario funcionario = MapData(reader);
                        funcionariosEncontrados.Add(funcionario);
                    }
                }
            }
        }

        return funcionariosEncontrados;
    }

    public override List<Funcionario> FilterData(string searchTerm)
    {
        List<Funcionario> filteredData = new List<Funcionario>();

        using (SqlConnection connection = ConnectionManager.GetConnection())
        {
            string query = $"SELECT * FROM Funcionario WHERE IdFuncionario = @searchTerm OR Email = @searchTerm";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@searchTerm", searchTerm);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Funcionario funcionario = MapData(reader);
                        filteredData.Add(funcionario);
                    }
                }
            }
        }

        return filteredData;
    }

    public override object[] GetHeaders()
    {
        string[] headers = { "IdFuncionario", "IdPessoa", "Email", "DataAdmissao", "IdEmpresa", "Cargo", "SalarioBruto" };
        return headers;
    }

    public override void SetData(List<Funcionario> data)
    {
        Data = data;
    }

    protected override Funcionario MapData(SqlDataReader reader)
    {
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

        return funcionario;
    }
}
