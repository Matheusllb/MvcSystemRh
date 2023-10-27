using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model.Interfaces.IDAO
{
    public interface IDAO<T> where T : IEntidade
    {
        bool Insert(T entidade);
        bool Update(T entidade);
        bool Delete(int id);
        bool Inativar(int id);
        T GetById(int id);
        List<T> GetAll();
        List<T> FilterData(string termo);
        T MapData(SqlDataReader reader);

    }
}
