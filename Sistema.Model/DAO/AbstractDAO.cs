using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model.DAO
{
    // Classe abstrata genérica AbstractDAO<T> que fornece funcionalidade para operações CRUD
    public abstract class AbstractDAO<T> where T : class // Definindo que "T" precisa ser uma classe, de modo que outro valor retornará erro
    {
        // Gerenciador de conexão de banco de dados
        protected DbConnectionManager connectionManager;

        // Construtor da classe
        public AbstractDAO()
        {
            // Inicializa o gerenciador de conexão
            connectionManager = new DbConnectionManager();
        }

        // Método para criar um registro
        public virtual bool Create(T entidade, string nomeTabela)
        {
            using (SqlConnection connection = connectionManager.GetConnection())
            {
                string columns = GetColumnNames(); // Obtém os nomes das colunas
                string parameters = GetParameterNames(); // Obtém os nomes dos parâmetros

                string query = $"INSERT INTO {nomeTabela} ({columns}) VALUES ({parameters});";
                SqlCommand command = new SqlCommand(query, connection);

                // Preenche os parâmetros com os valores do objeto 'entity' usando reflexão
                foreach (var property in typeof(T).GetProperties())
                {
                    if (property.Name != "Id") // Ignora a coluna 'Id'
                    {
                        // Obtém o nome do parâmetro (por exemplo, "@Nome")
                        string paramName = $"@{property.Name}";

                        // Obtém o valor da propriedade da entidade
                        object value = property.GetValue(entidade);

                        // Define o valor do parâmetro na consulta SQL
                        command.Parameters.AddWithValue(paramName, value ?? DBNull.Value);
                    }
                }

                try
                {
                    connectionManager.OpenConnection();
                    int rowsAffected = command.ExecuteNonQuery();

                    // Se uma linha foi afetada, a inserção foi bem-sucedida
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                    return false; // Inserção falhou
                }
                finally
                {
                    connectionManager.CloseConnection();
                    // Notifica observadores sobre a mudança nos dados

                }
            }
        }

        // Método para buscar um registro pelo ID
        public virtual T FindById(int id, string nomeTabela)
        {
            using (SqlConnection connection = connectionManager.GetConnection())
            {
                string query = $"SELECT * FROM {nomeTabela} WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connectionManager.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            T entity = Activator.CreateInstance<T>(); // Cria uma nova instância de T
                            foreach (var property in typeof(T).GetProperties())
                            {
                                if (property.Name != "Id") // Ignora a coluna 'Id', a atribuição do Id será feita pelo próprio banco
                                {
                                    // Obtém o valor da coluna correspondente do leitor e define na propriedade da entidade
                                    property.SetValue(entity, reader[property.Name] is DBNull ? null : reader[property.Name]);
                                }
                            }
                            return entity;
                        }
                        else
                        {
                            return default(T); // Retorna o valor padrão se não encontrado
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                    return default(T); // Retorna o valor padrão em caso de erro
                }
                finally
                {
                    connectionManager.CloseConnection();
                }
            }
        }

        // Método para buscar todos os registros
        public virtual List<T> FindAll<T>(string nomeTabela)
        {
            List<T> entidades = new List<T>();

            using (SqlConnection connection = connectionManager.GetConnection())
            {
                string query = $"SELECT * FROM {nomeTabela}";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connectionManager.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T entidade = Activator.CreateInstance<T>(); // Cria uma nova instância do tipo T
                            foreach (var property in typeof(T).GetProperties())
                            {
                                string propertyName = property.Name;
                                if (reader[property.Name] != DBNull.Value)
                                {
                                    object value = reader[property.Name];
                                    property.SetValue(entidade, value);
                                }
                                // Caso contrário, mantenha a propriedade como null
                            }
                            entidades.Add(entidade);
                        }
                    }
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

            return entidades;
        }


        // Método para atualizar um registro
        public virtual bool Update(T entidade, string nomeTabela)
        {
            using (SqlConnection connection = connectionManager.GetConnection())
            {
                string updateColumns = GetUpdateColumns(); // Obtém as colunas para atualização

                string query = $"UPDATE {nomeTabela} SET {updateColumns} WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", GetIdValue(entidade)); // Obtém o valor do ID

                // Preenche os parâmetros para as colunas a serem atualizadas
                foreach (var property in typeof(T).GetProperties())
                {
                    if (property.Name != "Id") // Ignora a coluna 'Id', a atribuição do Id será feita pelo próprio banco
                    {
                        // Obtém o nome do parâmetro (por exemplo, "@Nome")
                        string paramName = $"@{property.Name}";

                        // Obtém o valor da propriedade da entidade
                        object value = property.GetValue(entidade);

                        // Define o valor do parâmetro na consulta SQL
                        command.Parameters.AddWithValue(paramName, value ?? DBNull.Value);
                    }
                }

                try
                {
                    connectionManager.OpenConnection();
                    int rowsAffected = command.ExecuteNonQuery();

                    // Se uma linha foi afetada, a atualização foi bem-sucedida
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                    return false; // Atualização falhou
                }
                finally
                {
                    connectionManager.CloseConnection();
                    // Notifica observadores sobre a mudança nos dados
                }
            }
        }

        // Método para excluir um registro
        public virtual bool Delete(T entidade, string nomeTabela)
        {
            using (SqlConnection connection = connectionManager.GetConnection())
            {
                string query = $"DELETE FROM {nomeTabela} WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", GetIdValue(entidade)); // Obtém o valor do ID

                try
                {
                    connectionManager.OpenConnection();
                    int rowsAffected = command.ExecuteNonQuery();

                    // Se uma linha foi afetada, a exclusão foi bem-sucedida
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                    return false; // Exclusão falhou
                }
                finally
                {
                    connectionManager.CloseConnection();
                    // Notifica observadores sobre a mudança nos dados
                }
            }
        }


        // Métodos auxiliares para obter o valor da coluna 'Id' e nomes de colunas para atualização
        protected object GetIdValue(T entidade)
        {
            return typeof(T).GetProperty("Id").GetValue(entidade);
        }

        protected string GetUpdateColumns()
        {
            // Obtém os nomes das colunas para atualização (excluindo 'Id')
            return string.Join(", ", typeof(T).GetProperties().Where(property => property.Name != "Id").Select(property => $"{property.Name} = @{property.Name}"));
        }

        protected string GetColumnNames()
        {
            // Obtém os nomes das colunas da tabela (pode ser personalizado com base na sua estrutura de banco de dados)
            // Exemplo simples: "Nome, Idade, Email"
            return string.Join(", ", typeof(T).GetProperties().Select(property => property.Name));
        }

        protected string GetParameterNames()
        {
            // Obtém os nomes dos parâmetros na consulta SQL (por exemplo, "@Nome, @Idade, @Email")
            return string.Join(", ", typeof(T).GetProperties().Select(property => "@" + property.Name));
        }
    }

}
