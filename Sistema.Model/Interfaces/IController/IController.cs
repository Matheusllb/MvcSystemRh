using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model.Interfaces.IController
{
    public interface IController<T> where T : IEntidade
    {
        void FilterData(string termo);
        T GetById(int id);
        bool GetAll();
        bool InsertOne(T newData);
        bool UpdateOne(T data);
        bool DeleteOne(int id);
    }

}
