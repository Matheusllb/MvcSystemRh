using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Sistema.Model.DAO;
using Sistema.Model.Entidades;

namespace Sistema.Desktop.Controllers
{
    public class AcessoController
    {
        private DbConnectionManager _connectionManager = new DbConnectionManager(); // Crie uma instância de DbConnectionManager ou use a que você já possui.
        private UsuarioDAO _dao;

        public AcessoController()
        {
            _dao = new UsuarioDAO(_connectionManager);
        }

        public bool Logar(string usuario, string senha)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha os campos vazios.", "Campo Vazio", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            else
            {
                return _dao.Logar(usuario, senha);
            }
            
        } 
    }
}
