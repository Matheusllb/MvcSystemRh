using Sistema.Desktop.View.ViewTelaEmpresa;
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

namespace Sistema.Desktop.View.ViewTelaFuncionario
{
    /// <summary>
    /// Lógica interna para TelaCadastroFuncionario.xaml
    /// </summary>
    public partial class TelaCadastroFuncionario : Window
    {
        public TelaCadastroFuncionario()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            TelaEmpresa tela = new TelaEmpresa();
            tela.Show();
            tela.WindowState = WindowState;
            Close();
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
