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
using Sistema.Desktop.View.BeneficioDesconto;

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

        private void Ir_Para_Beneficio_Desconto_Button_Click(object sender, RoutedEventArgs e)
        {
            BeneficioDesconto beneficioDesconto = new BeneficioDesconto();
            beneficioDesconto.Show();
        }
    }
}
