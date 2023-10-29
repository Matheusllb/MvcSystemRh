using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using Sistema.Model.Entidades.Enum;
using Sistema.Model.Interfaces.IDAO;

public class FuncionarioDAO : DAO<Funcionario>, IFuncionarioDAO
{
    public FuncionarioDAO() : base("Funcionario")
    {
        secondTable = "Pessoa";
    }



    public override List<Funcionario> FilterData(string searchTerm)
    {
        try
        {
            List<Funcionario> filteredData = new List<Funcionario>();

            string query = @"SELECT P.* FROM " + SecondTable + @" AS P INNER JOIN " + TableName + @" AS F ON P.Id = F.IdPessoa
                             WHERE (F.Cargo = @searchTerm OR F.Email = @searchTerm OR F.DataAdmissao LIKE @searchTerm)
                             OR (P.Nome = @searchTerm OR P.Cpf = @searchTerm OR P.DataNascimento LIKE @searchTerm OR P.EstadoCivil LIKE @searchTerm OR P.Endereco LIKE @searchTerm)";
            searchTerm = $"%{searchTerm}%";

            using (SqlCommand command = new SqlCommand(query, ConnectionManager.GetConnection()))
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

            return filteredData;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public override Funcionario MapData(SqlDataReader reader)
    {
        try
        {

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
                    return null;
                }
                else
                {
                    return new Funcionario
                    {
                        IdFuncionario = Convert.ToInt32(reader["Id"]),
                        Id = Convert.ToInt32(reader["IdPessoa"]),
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
                        Ativo = Convert.ToBoolean(reader["Ativo"])
                    };
                }
            }
            return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
