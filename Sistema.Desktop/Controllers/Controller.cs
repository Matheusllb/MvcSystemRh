using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Windows.Markup;

public class Controller<T> where T : IEntidade
{
    private DAO<T> model;

    public Controller(DAO<T> model)
    {
        this.model = model;
    }

    public void FilterData(string searchTerm)
    {
        List<T> newData = model.FilterData(searchTerm);
        model.SetData(newData);
    }

    public DAO<T> GetModel()
    {
        return model;
    }

    public object[] GetHeaders()
    {
        return model.GetHeaders();
    }

    public void FetchAll()
    {
        List<T> newData = model.GetAll();
        model.SetData(newData);
    }

    public T GetById(int id)
    {
        return model.GetById(id);
    }

    public void InsertOne(T newData)
    {
        model.Insert(newData);
        FetchAll();
    }

    public void UpdateOne(T data)
    {
        model.Update(data);
        FetchAll();
    }

    public void DeleteOne(int id)
    {
        model.Delete(id);
        FetchAll();
    }

}
