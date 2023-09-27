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
    public class BeneficioDescontoDAO : AbstractDAO<BeneficioDesconto>
    {
        private DbConnectionManager _connectionManager;

        public BeneficioDescontoDAO()
        {
            _connectionManager = new DbConnectionManager();
        }

        public bool InserirBeneficioDesconto(BeneficioDesconto novoBeneficioDesconto)
        {
            using (SqlConnection connection = _connectionManager.GetConnection())
            {
                string query = "INSERT INTO BeneficioDesconto (Descricao, Desconto, Valor) VALUES (@Descricao, @Desconto, @Valor);";
                SqlCommand command = new SqlCommand(query, connection);

                // Adicione os parâmetros necessários com os valores do novoBeneficioDesconto
                command.Parameters.AddWithValue("@Descricao", novoBeneficioDesconto.GetDescricaoBeneficioDesconto());
                command.Parameters.AddWithValue("@Desconto", novoBeneficioDesconto.GetDescontoBeneficioDesconto());
                command.Parameters.AddWithValue("@Valor", novoBeneficioDesconto.GetValorBeneficioDesconto());

                try
                {
                    _connectionManager.OpenConnection();
                    int rowsAffected = command.ExecuteNonQuery();

                    // Se uma linha foi afetada, a inserção foi bem-sucedida
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return false; // Inserção falhou
                }
                finally
                {
                    _connectionManager.CloseConnection();
                }
            }
        }

        public List<BeneficioDesconto> GetAllBeneficiosDescontos()
        {
            List<BeneficioDesconto> beneficiosDescontos = new List<BeneficioDesconto>();

            using (SqlConnection connection = _connectionManager.GetConnection())
            {
                string query = "SELECT IdBeneficioDesconto, Descricao, Desconto, Ativo, Valor FROM BeneficioDesconto";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    _connectionManager.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        BeneficioDesconto beneficioDesconto = new BeneficioDesconto
                            (
                            Convert.ToInt32(reader["IdBeneficioDesconto"]),
                            reader["Descricao"].ToString(),
                            Convert.ToBoolean(reader["Desconto"]),
                            Convert.ToBoolean(reader["Ativo"]),
                            Convert.ToDecimal(reader["Valor"])
                            );

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

        public List<BeneficioDesconto> GetBeneficiosDescontosPorNomeEAtivo(string nome, bool ativo)
        {
            List<BeneficioDesconto> beneficiosDescontos = new List<BeneficioDesconto>();

            using (SqlConnection connection = _connectionManager.GetConnection())
            {
                string query = "SELECT IdBeneficioDesconto, Descricao, Desconto, Ativo, Valor, FROM BeneficioDesconto WHERE LOWER(Descricao) LIKE @Nome AND Ativo = @Ativo;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", "%" + nome.ToLower() + "%");
                command.Parameters.AddWithValue("@Ativo", ativo);

                try
                {
                    _connectionManager.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        BeneficioDesconto beneficioDesconto = new BeneficioDesconto
                        (
                            Convert.ToInt32(reader["IdBeneficioDesconto"]),
                            reader["Descricao"].ToString(),
                            Convert.ToBoolean(reader["Desconto"]),
                            Convert.ToBoolean(reader["Ativo"]),
                            Convert.ToDecimal(reader["Valor"])
                        );

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
        public List<BeneficioDesconto> GetBeneficiosDescontosInativos()
        {
            List<BeneficioDesconto> beneficiosDescontos = new List<BeneficioDesconto>();

            using (SqlConnection connection = _connectionManager.GetConnection())
            {
                string query = "SELECT IdBeneficioDesconto, Descricao, Desconto, Ativo, Valor FROM BeneficioDesconto WHERE Ativo = 0;";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    _connectionManager.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        BeneficioDesconto beneficioDesconto = new BeneficioDesconto
                        (
                            Convert.ToInt32(reader["IdBeneficioDesconto"]),
                            reader["Descricao"].ToString(),
                            Convert.ToBoolean(reader["Desconto"]),
                            Convert.ToBoolean(reader["Ativo"]),
                            Convert.ToDecimal(reader["Valor"])
                        );

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
        public bool InativarBeneficioDesconto(int idBeneficioDesconto)
        {
            using (SqlConnection connection = _connectionManager.GetConnection())
            {
                string query = "UPDATE BeneficioDesconto SET Ativo = 0 WHERE IdBeneficioDesconto = @IdBeneficioDesconto;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdBeneficioDesconto", idBeneficioDesconto);

                try
                {
                    _connectionManager.OpenConnection();
                    int rowsAffected = command.ExecuteNonQuery();

                    // Se pelo menos uma linha foi afetada, a inativação foi bem-sucedida
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return false; // Inativação falhou
                }
                finally
                {
                    _connectionManager.CloseConnection();
                }
            }
        }
    }
}