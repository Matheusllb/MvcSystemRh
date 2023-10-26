using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Sistema.Model.DAO;
using Sistema.Model.Entidades;

public class BeneficioDescontoDAO : DAO<BeneficioDesconto>
{
    public BeneficioDescontoDAO() : base("BeneficioDesconto")
    {
    }

    public override List<BeneficioDesconto> FilterData(string searchTerm)
    {
        List<BeneficioDesconto> filteredData = new List<BeneficioDesconto>();

        using (SqlConnection connection = ConnectionManager.GetConnection())
        {
            connection.Open();

            string query = "SELECT * FROM BeneficioDesconto WHERE Descricao LIKE @searchTerm";
            searchTerm = $"%{searchTerm}%";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@searchTerm", searchTerm);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BeneficioDesconto bd = MapData(reader);
                        filteredData.Add(bd);
                    }
                }
            }
        }

        return filteredData;
    }

    public override BeneficioDesconto MapData(SqlDataReader reader)
    {
        try
        {
            if (reader["Id"] != DBNull.Value && reader["Descricao"] != DBNull.Value && reader["Desconto"] != DBNull.Value && reader["Valor"] != DBNull.Value && reader["Ativo"] != DBNull.Value)
            {
                return new BeneficioDesconto
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Descricao = reader["Descricao"].ToString(),
                    Desconto = Convert.ToBoolean(reader["Desconto"]),
                    Valor = Convert.ToDecimal(reader["Valor"]),
                    Ativo = Convert.ToBoolean(reader["Ativo"]),
                };
            }

            return null;
        }
        catch (InvalidCastException ex)
        {
            
            throw new Exception(ex.Message);
     
        }
    }
}
