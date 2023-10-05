using Sistema.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Desktop.Controllers
{
    public class AtualizacaoController<T> where T : class
    {
        private AbstractDAO<T> _dao;

        public AtualizacaoController(AbstractDAO<T> dao)
        {
            _dao = dao;
        }

        public bool AtualizarRegistro(T entidade, string nomeTabela)
        {
            try
            {
                return _dao.Update(entidade, nomeTabela);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                return false;
            }
        }
    }
}
