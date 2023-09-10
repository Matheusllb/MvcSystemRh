using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sistema.Model.Entidades;
using Sistema.Model.Interfaces.IDAO;

namespace Sistema.Model.DAO
{
    public class BDFuncionarioDAO : IObservable
    {
        public void NotifyObservers()
        {
            throw new NotImplementedException();
        }

        public void RegisterObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void RemoveObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        private DbConnectionManager _connectionManager;
        private List<IObserver> _observers = new List<IObserver> ();

        public BDFuncionarioDAO()
        {
            _connectionManager = new DbConnectionManager();
        }

        public List<BDFuncionario> GetAllBDFuncionario()
        {
            List<BDFuncionario> bDFuncionarios = new List<BDFuncionario>();

            using (SqlConnection connection = _connectionManager.GetConnection())
            {
                string query = "SELECT IdBDFuncionario, IdFuncionario, IdBeneficioDesconto FROM BDFuncionario";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    _connectionManager.OpenConnection();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        BDFuncionario bDFuncionario = new BDFuncionario
                        (
                            Convert.ToInt32(reader["IdBDFuncionario "]),
                            Convert.ToInt32(reader["IdFuncionario "]),
                            Convert.ToInt32(reader["IdBeneficioDesconto"])
                        );

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
                    NotifyObservers();
                }

                return bDFuncionarios;
            }

        }
    }
}