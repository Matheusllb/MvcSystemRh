using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using Sistema.Model.Interfaces.IDAO;

public class UsuarioDAO : DAO<Usuario>, IUsuarioDAO
{
    public UsuarioDAO() : base("Usuario")
    {
    }

    public bool Logar(string usuario, string senha)
    {
        try
        {
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Usuario WHERE Login = @user AND Senha = @password AND Inativo = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user", usuario); // Atribui o valor do usuário
                    command.Parameters.AddWithValue("@password", senha); // Atribui o valor da senha

                    int count = (int)command.ExecuteScalar();

                    return count > 0; // Retorna true se houver correspondência e o usuário não estiver inativo, senão, retorna false
                }
            }
        }
        catch (SqlException ex)
        {
            // Você pode lançar uma exceção personalizada ou retornar um código de erro específico aqui
            // Por exemplo, lançar uma exceção personalizada com uma mensagem de erro significativa
            throw new Exception("Erro durante a autenticação: " + ex.Message, ex);
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }

    public int ObterPermissao(int idUsuario)
    {
        try
        {
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                string query = "SELECT IdPermissao FROM Usuario WHERE IdUsuario = @idUsuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    ConnectionManager.OpenConnection();

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            // Você pode lançar uma exceção personalizada ou retornar um código de erro específico aqui
            // Por exemplo, lançar uma exceção personalizada com uma mensagem de erro significativa
            throw new Exception("Erro ao obter permissão: " + ex.Message, ex);
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }

        // Indica que não foi encontrada permissão ou ocorreu um erro
        return -1; // Use um valor especial (por exemplo, -1) para indicar a ausência de permissão ou erro
    }


    public override List<Usuario> FilterData(string searchTerm)
    {
        List<Usuario> filteredData = new List<Usuario>();

        using (SqlConnection connection = ConnectionManager.GetConnection())
        {
            string query = $"SELECT * FROM Usuario WHERE IdUsuario = @searchTerm OR Login = @searchTerm";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@searchTerm", searchTerm);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario usuario = MapData(reader);
                        filteredData.Add(usuario);
                    }
                }
            }
        }

        return filteredData;
    }

    public override object[] GetHeaders()
    {
        string[] headers = { "IdUsuario", "IdPessoa", "IdPermissao", "Inativo", "Login", "Senha" };
        return headers;
    }

    public override void SetData(List<Usuario> data)
    {
        Data = data;
    }

    protected override Usuario MapData(SqlDataReader reader)
    {
        Usuario usuario = new Usuario
        {
            Id = (int)reader["IdPessoa"]
        };
        usuario.SetIdUsuario((int)reader["IdUsuario"]);
        usuario.SetIdPermissaoUsuario((int)reader["IdPermissao"]);
        usuario.SetStatusUsuario((bool)reader["Inativo"]);
        usuario.SetLoginUsuario(reader["Login"].ToString());
        usuario.SetSenhaUsuario(reader["Senha"].ToString());

        return usuario;
    }
}
