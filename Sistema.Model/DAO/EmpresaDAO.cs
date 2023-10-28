using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sistema.Model.DAO
{
    public class EmpresaDAO : DAO<Empresa>, IEmpresaDAO
    {
        public EmpresaDAO() : base("Empresa")
        {
        }

        public override List<Empresa> FilterData(string searchTerm)
        {
            try
            {
                List<Empresa> filteredData = new List<Empresa>();

                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    string query = $"SELECT * FROM {TableName} WHERE Nome LIKE @searchTerm OR Cnpj LIKE @searchTerm OR Setor LIKE @searchTerm OR Email LIKE @searchTerm OR Telefone LIKE @searchTerm OR Endereco LIKE @searchTerm";
                    searchTerm = $"%{searchTerm}%";

                    using (SqlCommand command = new SqlCommand(query, ConnectionManager.GetConnection()))
                    {
                        ConnectionManager.OpenConnection();

                        command.Parameters.AddWithValue("@searchTerm", searchTerm);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Empresa empresa = MapData(reader);
                                filteredData.Add(empresa);
                            }
                        }
                        ConnectionManager.CloseConnection();
                    }
                    return filteredData;
                }
            }catch (Exception ex)
            {
                throw ex;
            }

        }

        public override Empresa MapData(SqlDataReader reader)
        {
            try
            {
                if (reader["IdEmpresa"] != DBNull.Value &&
                    reader["Nome"] != DBNull.Value &&
                    reader["Cnpj"] != DBNull.Value &&
                    reader["Setor"] != DBNull.Value &&
                    reader["Email"] != DBNull.Value &&
                    reader["Telefone"] != DBNull.Value &&
                    reader["Endereco"] != DBNull.Value)
                {
                    return new Empresa
                    {
                        Id = (int)reader["IdEmpresa"],
                        Nome = reader["Nome"].ToString(),
                        Cnpj = reader["Cnpj"].ToString(),
                        Setor = reader["Setor"].ToString(),
                        Email = reader["Email"].ToString(),
                        Telefone = reader["Telefone"].ToString(),
                        Endereco = reader["Endereco"].ToString()
                    };

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
}