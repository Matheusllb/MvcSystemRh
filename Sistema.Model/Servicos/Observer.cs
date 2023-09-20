using Sistema.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model.Interfaces.IDAO
{
    public class Observer<T> where T : class
    {
        // Método para inscrever um DAO como observador
        public void Subscribe(AbstractDAO<T> dao)
        {
            dao.DataChanged += HandleDataChanged;
        }

        // Método para cancelar a inscrição de um DAO como observador
        public void Unsubscribe(AbstractDAO<T> dao)
        {
            dao.DataChanged -= HandleDataChanged;
        }

        // Método de tratamento para ser chamado quando ocorrerem alterações nos dados
        private void HandleDataChanged(object sender, EventArgs<T> e)
        {
            // Exibe uma mensagem indicando que os dados foram alterados e a entidade afetada
            Console.WriteLine("Dados alterados. Entidade: " + e.Value);
        }
    }
}