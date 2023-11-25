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
using System.Windows.Shapes;

namespace Sistema.Desktop.View.ViewFolha
{
    /// <summary>
    /// Lógica interna para TelaFolhaPrincipal.xaml
    /// </summary>
    public partial class TelaFolhaPrincipal : Window
    {
        public TelaFolhaPrincipal()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            TelaFolhaPagamento tela = new TelaFolhaPagamento();
            tela.Show();
            tela.WindowState = WindowState;
            Close();
        }

        private void btnGer_Click(object sender, RoutedEventArgs e)
        {
            TelaFolha telaFolha = new TelaFolha();
            telaFolha.Show();
            telaFolha.WindowState = WindowState;
            Close();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            menu.WindowState = WindowState;
            Close();
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
