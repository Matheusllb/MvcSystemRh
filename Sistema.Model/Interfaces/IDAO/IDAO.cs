using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model.Interfaces.IDAO
{
    public interface IDAO<T> where T : IEntidade
    {
        void Insert(T entidade);
        void Update(T entidade);
        void Delete(int id);
        T GetById(int id);
        List<T> GetAll();
        List<T> FilterData(string termo);
    }
}
