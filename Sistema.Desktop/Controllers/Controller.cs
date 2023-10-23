using Sistema.Model.Interfaces.IController;
using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

public abstract class Controller<T> : IController<T> where T : IEntidade
{
    protected DAO<T> Model {  get; set; }

    public List<T> Data = new List<T>();

    public Controller(DAO<T> model)
    {
        Model = model;
    }

    public void FilterData(string termo)
    {
        try
        {
            List<T> newData = Model.FilterData(termo);
            Model.SetData(newData);
        }catch (Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message);
        }
    }

    public DAO<T> GetModel()
    {
        try
        {
            return Model;
        }catch (Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message);
            return null;
        }
    }

    public object[] GetHeaders()
    {
        try
        {
            return Model.GetHeaders();
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
            Model.GetAll();
            if (Model.Data == null)
            {
                throw new Exception("Erro no controlador: Está retornando nulo!");
            }
            return Model.Data; // Atualiza a lista no controlador
        }
        catch (SqlException sqlEx)
        {
            MessageBox.Show("Erro SQL: " + sqlEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro geral: " + ex.Message);
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
            GetAll();
            return true;
        }catch (Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message);
            return false;
        }
    }

}
