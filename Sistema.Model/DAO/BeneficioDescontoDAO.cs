using Internal;
using System.Data;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using Sistema.Model.Entidades;

namespace Sistema.Model.DAO
{
    public class BeneficioDescontoDAO
    {
        private DbConnectionManager connectionManager;

        public BeneficioDescontoDAO()
        {
            connectionManager = new DbConnectionManager();
        }

        public List<BeneficioDesconto> GetAllBeneficiosDescontos()
        {
            List<BeneficioDesconto> beneficiosDescontos = new List<BeneficioDesconto>();

            using (SqlConnection connection = connectionManager.GetConnection())
            {
                string query = "SELECT IdBeneficioDesconto, Descricao, Desconto, Valor FROM BeneficioDesconto";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connectionManager.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        BeneficioDesconto beneficioDesconto = new BeneficioDesconto
                        {
                            IdBeneficioDesconto = Convert.ToInt32(reader["IdBeneficioDesconto"]),
                            Descricao = reader["Descricao"].ToString(),
                            Desconto = Convert.ToBoolean(reader["Desconto"]),
                            Valor = Convert.ToDouble(reader["Valor"])
                        };

                        beneficiosDescontos.Add(beneficioDesconto);
                    }

                    reader.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }

                finally
                {
                    connectionManager.CloseConnection();
                }
            }

            return beneficiosDescontos;
        }
    }
}

