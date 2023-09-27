using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Sistema.Model.DAO;

namespace Sistema.Desktop.Controllers
{
    public class AcessoController
    {
        private UsuarioDAO _dao = new UsuarioDAO();

        public bool Logar(string usuario, string senha)
        {
            if(usuario == null && senha == null)
            {
                MessageBox.Show("Preencha os campos vazios.", "Campo Vazio",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                return false;
            }
            else
            {
                return _dao.Logar(usuario, senha);
            }
            
        } 
    }
}
