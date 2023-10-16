using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
        try
        {
            Type tipo = typeof(T);

            string query = $"SELECT * FROM {TableName}";

            List<T> result = new List<T>();

            using (SqlCommand command = new SqlCommand(query, ConnectionManager.GetConnection()))
            {
                ConnectionManager.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T item = (T)Activator.CreateInstance(tipo);

                        foreach (PropertyInfo property in tipo.GetProperties())
                        {
                            if (property.Name != "Id")
                            {
                                property.SetValue(item, reader[property.Name]);
                            }
                        }

                        result.Add(item);
                    }
                }

                ConnectionManager.CloseConnection();
            }

            return result;
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine("Erro de banco: " + sqlEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
            return null;
        }
    }

    public T GetById(int id)
    {
        try
        {
            Type tipo = typeof(T);

            string query = $"SELECT * FROM {TableName} WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, ConnectionManager.GetConnection()))
            {
                command.Parameters.AddWithValue("@Id", id);

                ConnectionManager.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        T item = (T)Activator.CreateInstance(tipo);

                        foreach (PropertyInfo property in tipo.GetProperties())
                        {
                            if (property.Name != "Id")
                            {
                                property.SetValue(item, reader[property.Name]);
                            }
                        }

                        ConnectionManager.CloseConnection();

                        return item;
                    }
                }

                ConnectionManager.CloseConnection();
            }

            return default(T);
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine("Erro de banco: " + sqlEx.Message);
            return default(T);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
            return default(T);
        }
    }

    public bool Insert(T item)
    {
        try
        {
            Type tipo = typeof(T);

            PropertyInfo[] propriedades = tipo.GetProperties().Where(p => p.Name != "Id").ToArray();

            string colunas = string.Join(", ", propriedades.Select(p => p.Name));
            string parametros = string.Join(", ", propriedades.Select((p, i) => $"@p{i}"));

            string query = $"INSERT INTO {TableName} ({colunas}) VALUES ({parametros})";

            using (SqlCommand command = new SqlCommand(query, ConnectionManager.GetConnection()))
            {
                for (int i = 0; i < propriedades.Length; i++)
                {
                    command.Parameters.AddWithValue($"@p{i}", propriedades[i].GetValue(item));
                }

                ConnectionManager.OpenConnection();
                int count = command.ExecuteNonQuery();
                ConnectionManager.CloseConnection();

                return count > 0;
            }
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine("Erro de banco: " + sqlEx.Message);
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
            return false;
        }
    }


    public bool Update(T item)
    {
        try
        {
            Type tipo = typeof(T);

            int id = (int)tipo.GetProperty("Id").GetValue(item);

            if (id <= 0)
            {
                Console.WriteLine("ID inválido.");
                return false;
            }

            PropertyInfo[] propriedades = tipo.GetProperties().Where(p => p.Name != "Id").ToArray();

            string setClause = string.Join(", ", propriedades.Select((p, i) => $"{p.Name} = @p{i}"));

            string query = $"UPDATE {TableName} SET {setClause} WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, ConnectionManager.GetConnection()))
            {
                command.Parameters.AddWithValue("@Id", id);

                for (int i = 0; i < propriedades.Length; i++)
                {
                    command.Parameters.AddWithValue($"@p{i}", propriedades[i].GetValue(item));
                }

                ConnectionManager.OpenConnection();

                int count = command.ExecuteNonQuery();

                ConnectionManager.CloseConnection();

                return count > 0;
            }
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine("Erro de banco: " + sqlEx.Message);
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            Type tipo = typeof(T);

            if (id <= 0)
            {
                Console.WriteLine("ID inválido.");
                return false;
            }

            string query = $"DELETE FROM {TableName} WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, ConnectionManager.GetConnection()))
            {
                command.Parameters.AddWithValue("@Id", id);

                ConnectionManager.OpenConnection();

                int count = command.ExecuteNonQuery();

                ConnectionManager.CloseConnection();

                return count > 0;
            }
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine("Erro de banco: " + sqlEx.Message);
            return false;
        }
        catch (Exception ex)
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
