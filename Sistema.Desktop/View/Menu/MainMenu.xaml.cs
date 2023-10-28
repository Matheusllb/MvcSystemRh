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
using Sistema.Desktop.View.ViewBeneficioDesconto;
using Sistema.Desktop.View.ViewTelaEmpresa;

namespace Sistema.Desktop
{
    /// <summary>
    /// Lógica interna para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Ir_Para_Beneficio_Desconto_Click(object sender, RoutedEventArgs e)
        {
            TelaBeneficioDesconto beneficioDesconto = new TelaBeneficioDesconto();
            beneficioDesconto.Show();
            beneficioDesconto.WindowState = WindowState;
            Close();
        }

        private void Ir_Para_Empresa_Click(object sender, RoutedEventArgs e)
        {
            TelaEmpresa empresa = new TelaEmpresa();
            empresa.Show();
            empresa.WindowState = WindowState;
            Close();
        }

        private void Ir_Para_Funcionarios_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ir_Para_FolhaPagamento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
