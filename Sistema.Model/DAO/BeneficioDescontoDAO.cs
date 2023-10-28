using System;
using System.Collections;
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

        string query = $"SELECT * FROM {TableName} WHERE Descricao LIKE @searchTerm";
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


    public override BeneficioDesconto MapData(SqlDataReader reader)
    {
        try
        {
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
                    return new BeneficioDesconto
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Descricao = reader["Descricao"].ToString(),
                        Desconto = Convert.ToBoolean(reader["Desconto"]),
                        Valor = Convert.ToDecimal(reader["Valor"]),
                        Ativo = Convert.ToBoolean(reader["Ativo"]),
                    };
                }
            }

            return null;
        }
        catch (InvalidCastException ex)
        {

            throw ex;

        }
    }
}
