using Sistema.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Desktop.Controllers
{
    public class ConsultaController<T> where T : class
    {
        private AbstractDAO<T> _dao;

        public ConsultaController(AbstractDAO<T> dao)
        {
            _dao = dao;
        }

        public T BuscarPorId(int id, string nomeTabela)
        {
            try
            {
                return _dao.FindById(id, nomeTabela);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                return null;
            }
        }

        public List<T> BuscarTodos(string nomeTabela)
        {
            try
            {
                return _dao.FindAll<T>(nomeTabela);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                return new List<T>();
            }
        }
    }
}
