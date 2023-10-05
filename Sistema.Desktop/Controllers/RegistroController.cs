using Sistema.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Desktop.Controllers
{
    public class RegistroController<T> where T : class // Definindo que "T" precisa ser uma classe, de modo que outro valor retornará erro
    {
        private AbstractDAO<T> _dao;

        public RegistroController(AbstractDAO<T> dao)
        {
            _dao = dao;
        }

        public bool CriarRegistro(T entidade, string nomeTabela)
        {
            try
            {
                // Chame o método Create do DAO para inserir a nova entidade no banco de dados
                return _dao.Create(entidade, nomeTabela);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                return false;
            }
        }
    }
}
