using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using Sistema.Model.Interfaces.IDAO;

namespace Sistema.Desktop.Controllers
{
    public class AcessoController
    {
        private IUsuarioDAO _dao;

        public AcessoController(IUsuarioDAO usuarioDAO)
        {
            _dao = usuarioDAO;
        }

        public bool Logar(string usuario, string senha)
        {
            try
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
            }catch(Exception ex)
            {
                MessageBox.Show("Falha ao entrar: " + ex.Message);
                return false;
            }
            
        } 
    }
}
