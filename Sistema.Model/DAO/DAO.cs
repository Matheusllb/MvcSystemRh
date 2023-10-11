using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public abstract class DAO<T> : IDAO<T> where T : IEntidade
{
    protected DbConnectionManager ConnectionManager;
    protected string TableName;
    protected List<T> Data = new List<T>();

    public DAO(string tableName)
    {
        ConnectionManager = new DbConnectionManager();
        TableName = tableName;
    }

    public List<T> GetAll()
    {
        List<T> result = new List<T>();
        try
        {
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                string query = $"SELECT * FROM {TableName}";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T item = MapData(reader);
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }catch (SqlException sqlEx)
        {
            Console.WriteLine("Erro de banco: " + sqlEx.Message);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " +  ex.Message);
            return result;
        }
    }

    public T GetById(int id)
    {
        try
        {
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                string query = $"SELECT * FROM {TableName} WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapData(reader);
                        }
                    }
                }
            }
            return default;
        }catch(SqlException sqlEx)
        {
            Console.WriteLine("Erro de banco: " + sqlEx.Message);
            return default;
        }catch(Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
            return default;
        }
    }

    public bool Insert(T item)
    {
        try
        {
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                // Obtém os nomes das colunas da tabela, excluindo a coluna 'Id'
                var columnNames = typeof(T).GetProperties()
                    .Where(prop => prop.Name != "Id")
                    .Select(prop => prop.Name)
                    .ToArray();

                // Monta a lista de parâmetros da consulta SQL
                var parameters = columnNames.Select(colName => $"@{colName}").ToArray();

                // Monta a consulta SQL de inserção dinâmica
                string query = $"INSERT INTO {TableName} ({string.Join(", ", columnNames)}) " +
                               $"VALUES ({string.Join(", ", parameters)})";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Configura os parâmetros da consulta SQL com os valores do objeto 'item'
                    foreach (var propInfo in typeof(T).GetProperties())
                    {
                        if (propInfo.Name != "Id")
                        {
                            var paramValue = propInfo.GetValue(item);
                            command.Parameters.AddWithValue($"@{propInfo.Name}", paramValue ?? DBNull.Value);
                        }
                    }

                    command.ExecuteNonQuery();
                }
            }
            return true;
        }catch(SqlException sqlEx)
        {
            Console.WriteLine("Erro de banco: " + sqlEx.Message);
            return false;
        }catch(Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
            return false;
        }
    }

    public bool Update(T item)
    {
        try
        {
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                // Obtém os nomes das colunas da tabela, excluindo a coluna 'Id'
                var columnNames = typeof(T).GetProperties()
                    .Where(prop => prop.Name != "Id")
                    .Select(prop => prop.Name)
                    .ToArray();

                // Monta a lista de parâmetros da consulta SQL para atualização
                var parameters = columnNames.Select(colName => $"{colName} = @{colName}").ToArray();

                // Monta a consulta SQL de atualização dinâmica
                string query = $"UPDATE {TableName} SET {string.Join(", ", parameters)} WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Configura os parâmetros da consulta SQL com os valores atualizados do objeto 'item'
                    foreach (var propInfo in typeof(T).GetProperties())
                    {
                        var paramValue = propInfo.GetValue(item);
                        command.Parameters.AddWithValue($"@{propInfo.Name}", paramValue ?? DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }
            }
            return true;
        }catch (SqlException sqlEx)
        {
            Console.WriteLine("Erro de banco: " + sqlEx.Message);
            return false;
        }catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                string query = $"DELETE FROM {TableName} WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }catch(SqlException sqlEx)
        {
            Console.WriteLine("Erro de banco: " + sqlEx.Message);
            return false;
        }catch(Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
            return false;
        }
    }

    public abstract List<T> FilterData(string searchTerm);

    public abstract object[] GetHeaders();

    public abstract void SetData(List<T> data);
    protected abstract T MapData(SqlDataReader reader);
}
