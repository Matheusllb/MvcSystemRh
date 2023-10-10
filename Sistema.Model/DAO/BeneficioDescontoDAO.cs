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

    public override object[] GetHeaders()
    {
        string[] headers = { "IdBeneficioDesconto", "Descricao", "Desconto", "Valor", "DescontoTotal", "BeneficioTotal" };
        return headers;
    }

    public override void SetData(List<BeneficioDesconto> data)
    {
        Data = data;
    }

    protected override BeneficioDesconto MapData(SqlDataReader reader)
    {
        BeneficioDesconto bd = new BeneficioDesconto
        {
            Id = (int)reader["IdBeneficioDesconto"],
        };

        bd.SetDescricaoBeneficioDesconto(reader["Descricao"].ToString());
        bd.SetDescontoBeneficioDesconto((bool)reader["Desconto"]);
        bd.SetValorBeneficioDesconto((decimal)reader["Valor"]);

        return bd;
    }
}
