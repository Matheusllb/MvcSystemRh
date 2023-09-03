using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sistema.Model.Interfaces.IDAO;

namespace Sistema.Model.DAO
{
    public class BDFuncionarioDAO : IObservable
    {
        private DbConnectionManager _connectionManager;

        public BDFuncionarioDAO()
        {
            _connectionManager = new DbConnectionManager();
        }

        public List<BDFuncionario> GetAllBDFuncionario()
        {
            List<BDFuncionario> bDFuncionarios = new List<BDFuncionario>();

            using (SqlConnection connection = _connectionManager.GetConnection())
            {
                string query = "SELECT IdBDFuncionario, IdFuncionario, IdBeneficioDesconto FROM BDFuncionario;"
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    _connectionManager.OpenConnection();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        BDFuncionario bDFuncionario = new BDFuncionario
                        {
                            _idBD = Convert.ToInt32(reader["IdBDFuncionario "]),
                            _idFuncionario = Convert.ToInt32(reader["IdFuncionario "]),
                            _idBeneficioDesconto = Convert.ToInt32(reader["IdBeneficioDesconto"]),
                        };

                        bDFuncionarios.Add(bDFuncionario);
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

                return bDFuncionarios;
            }
        }
    }
}