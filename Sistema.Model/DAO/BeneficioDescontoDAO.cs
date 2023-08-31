using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sistema.Model.Entidades;

namespace Sistema.Model.DAO
{
    public class BeneficioDescontoDAO
    {
        private DbConnectionManager _connectionManager;

        public BeneficioDescontoDAO()
        {
            _connectionManager = new DbConnectionManager();
        }

        public List<BeneficioDesconto> GetAllBeneficiosDescontos()
        {
            List<BeneficioDesconto> beneficiosDescontos = new List<BeneficioDesconto>();

            using (SqlConnection connection = _connectionManager.GetConnection())
            {
                string query = "SELECT IdBeneficioDesconto, Descricao, Desconto, Valor FROM BeneficioDesconto";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    _connectionManager.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        BeneficioDesconto beneficioDesconto = new BeneficioDesconto
                        {
                            _idBeneficioDesconto = Convert.ToInt32(reader["IdBeneficioDesconto"]),
                            _descricao = reader["Descricao"].ToString(),
                            _desconto = Convert.ToBoolean(reader["Desconto"]),
                            _valor = Convert.ToDouble(reader["Valor"])
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
                    _connectionManager.CloseConnection();
                }
            }

            return beneficiosDescontos;
        }
    }
}

