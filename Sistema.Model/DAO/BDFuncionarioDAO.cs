using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;

public class BDFuncionarioDAO : DAO<BDFuncionario>
{
    public BDFuncionarioDAO(DbConnectionManager connectionManager) : base(connectionManager, "BDFuncionario")
    {
        Data = LoadDataFromDatabase(connectionManager, "BDFuncionario");
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

    public override object[] GetHeaders()
    {
        string[] headers = { "IdBDFuncionario", "IdFuncionario", "IdBeneficioDesconto" };
        return headers;
    }

    public override void SetData(List<BDFuncionario> data)
    {
        Data = data;
    }

    protected override BDFuncionario MapData(SqlDataReader reader)
    {
        BDFuncionario bdFuncionario = new BDFuncionario
        {
            Id = (int)reader["IdBDFuncionario"],
        };

        bdFuncionario.SetIdBDFuncionario((int)reader["IdFuncionario"]);
        bdFuncionario.SetIdBDBeneficioDesconto((int)reader["IdBeneficioDesconto"]);


        return bdFuncionario;
    }
}
