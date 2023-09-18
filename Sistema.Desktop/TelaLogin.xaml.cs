using Sistema.Desktop.Controllers;
using Sistema.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sistema.Desktop
{
    /// <summary>
    /// Interação lógica para TelaLogin.xam
    /// </summary>
    public partial class TelaLogin : Window
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void TelaLogin_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AcessoController loginCtrl = new AcessoController();
            if (loginCtrl.Logar(txbUsername.Text, pwbSenha.Password))
            {
                MessageBox.Show("Logado!");
            }
            else
            {
                MessageBox.Show("Nome de usuário ou senha incorretos!");
            }
        }
    }
}
