using Sistema.Model.Interfaces.IController;
using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Markup;

public abstract class Controller<T> : IController<T> where T : IEntidade
{
    protected DAO<T> Model;

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

    public bool GetAll()
    {
        try
        {
            List<T> newData = Model.GetAll();
            Model.SetData(newData);
            return true;
        }catch(Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message);
            return false;
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
            Model.Insert(newData);
            GetAll();
            return true;
        }catch(Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message);
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
