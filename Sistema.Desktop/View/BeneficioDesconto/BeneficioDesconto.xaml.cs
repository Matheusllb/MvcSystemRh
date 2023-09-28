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

namespace Sistema.Desktop.View.BeneficioDesconto
{
    /// <summary>
    /// Lógica interna para BeneficioDesconto.xaml
    /// </summary>
    public partial class BeneficioDesconto : Window
    {
        public BeneficioDesconto()
        {
            InitializeComponent();
        }

        private void txtSearchBD_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FormBeneficioDesconto formBeneficioDesconto = new FormBeneficioDesconto();
            frame.Content = formBeneficioDesconto;

        }

        private void frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
