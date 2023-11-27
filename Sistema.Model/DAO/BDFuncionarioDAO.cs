using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

public class BDFuncionarioDAO : DAO<BDFuncionario>, IBDFuncionario
{
    public BDFuncionarioDAO() : base("BDFuncionario")
    {
    }

    public override List<BDFuncionario> FilterData(string searchTerm)
    {
        List<BDFuncionario> filteredData = new List<BDFuncionario>();

        using (SqlConnection connection = ConnectionManager.GetConnection())
        {
            string query = $"SELECT * FROM BDFuncionario WHERE IdFuncionario = @searchTerm OR IdBeneficioDesconto = @searchTerm";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@searchTerm", searchTerm);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BDFuncionario bdFuncionario = MapData(reader);
                        filteredData.Add(bdFuncionario);
                    }
                }
            }
        }

        return filteredData;
    }

    public List<BeneficioDesconto> BuscaBeneficiosDescontos(int id)
    {
        List<BeneficioDesconto> lista = new List<BeneficioDesconto>();

        using (SqlConnection connection = ConnectionManager.GetConnection())
        {
            string query = "SELECT bd.* FROM BeneficioDesconto bd JOIN BDFuncionario bdf ON bd.Id = bdf.IdBeneficioDesconto JOIN Funcionario f ON f.Id = bdf.IdFuncionario WHERE f.Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                ConnectionManager.OpenConnection();

                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BDFuncionario bDF = MapData(reader);

                        if (bDF != null)
                        {
                            return bDF.BeneficioDesconto;
                        }
                    }
                }
            }
        }
        return lista;
    }

    public override BDFuncionario MapData(SqlDataReader reader)
    {
        try
        {
            if (reader["Id"] != DBNull.Value && reader["IdFuncionario"] != DBNull.Value && reader["IdBeneficioDesconto"] != DBNull.Value)
            {
                BDFuncionario bDFuncionario = new BDFuncionario
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    IdF = Convert.ToInt32((int)reader["IdFuncionario"]),
                    IdBD = Convert.ToInt32((int)reader["IdBeneficioDesconto"])
                };

                if (reader["Id"] != DBNull.Value &&
                    reader["Descricao"] != DBNull.Value &&
                    reader["Desconto"] != DBNull.Value &&
                    reader["Valor"] != DBNull.Value &&
                    reader["Ativo"] != DBNull.Value)
                {
                    if (!(bool)reader["Ativo"])
                    {
                        return null;
                    }
                    else
                    {
                        do
                        {
                            BeneficioDesconto bD = new BeneficioDesconto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Descricao = reader["Descricao"].ToString(),
                                Desconto = Convert.ToBoolean(reader["Desconto"]),
                                Valor = Convert.ToDecimal(reader["Valor"]),
                                Ativo = Convert.ToBoolean(reader["Ativo"]),
                            };

                            bDFuncionario.BeneficioDesconto.Add(bD);

                        } while (reader.Read());
                        return bDFuncionario;
                    }
                }
                else
                {
                    return null;
                }
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
