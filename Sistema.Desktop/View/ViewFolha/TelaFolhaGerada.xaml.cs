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
    /// Lógica interna para TelaFolhaGerada.xaml
    /// </summary>
    public partial class TelaFolhaGerada : Window
    {
        public TelaFolhaGerada()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExportar_Click(object sender, RoutedEventArgs e)
        {
            TelaFolha telaFolha = new TelaFolha();
            telaFolha.Show();
            telaFolha.WindowState = WindowState;
            Close();
        }
    }
}
