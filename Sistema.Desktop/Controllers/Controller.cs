using Sistema.Model.Interfaces.IController;
using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

public abstract class Controller<T> : IController<T> where T : IEntidade
{
    protected DAO<T> Model {  get; set; }

    public Controller(DAO<T> model)
    {
        Model = model;
    }

    public List<T> FilterData(string termo)
    {
        try
        {
            List<T> newData = Model.FilterData(termo);
            return newData;
        }catch (Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message);
            return null;
        }
    }

    public List<T> GetAll()
    {
        try
        {
            // Chama o método GetAll() do modelo
            List<T> dados = Model.GetAll();

            // Verifica se a lista de dados está vazia
            if (dados == null)
            {
                // Lança uma exceção
                throw new Exception("Erro no controlador: Está retornando nulo!");
            }

            // Retorna a lista de dados
            return dados;
        }
        catch (SqlException sqlEx)
        {
            // Exibe uma mensagem de erro no console
            MessageBox.Show("Erro SQL: " + sqlEx.Message);

            // Retorna null
            return null;
        }
        catch (Exception ex)
        {
            // Exibe uma mensagem de erro no console
            MessageBox.Show("Erro geral: " + ex.Message);

            // Retorna null
            return null;
        }
    }


    public T GetById(int id)
    {
        try
        {
            return Model.GetById(id);
        }catch(Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message);
            return default(T);
        }
    }

    public bool InsertOne(T newData)
    {
        try
        {
            return Model.Insert(newData);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro de controle: " + ex.Message);
            return false;
        }
    }

    public bool UpdateOne(T data)
    {
        try
        {
            Model.Update(data);
            GetAll();
            return true;
        }catch(Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message);
            return false;
        }
    }

    public bool DeleteOne(int id)
    {
        try
        {
            Model.Delete(id);
            return true;
        }catch (Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message);
            return false;
        }
    }
    
    public bool Inativar(int id)
    {
        try
        {
            Model.Inativar(id);
            return true;
        }catch (Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message);
            return false;
        }
    }

}
