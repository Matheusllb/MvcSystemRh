using Sistema.Model.Entidades;
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
    /// Lógica interna para TelaFolhaPagamento.xaml
    /// </summary>
    public partial class TelaFolhaPagamento : Window
    {
        public int idEmpresa;
        public int idFuncionario;
        public DateTime fechamento;
        public DateTime pagamento;

        public TelaFolhaPagamento()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            TelaFolhaPrincipal principal = new TelaFolhaPrincipal();
            principal.Show();
            principal.WindowState = WindowState;
            Close();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            menu.WindowState = WindowState;
            Close();
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnContinuar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtCodigoEmpresa.Text, out idEmpresa) && int.TryParse(txtCodigoFuncionario.Text, out idFuncionario))
                {
                    if (DateTime.TryParse(txtDataFechamento.Text, out fechamento) && DateTime.TryParse(txtDataPagamento.Text, out pagamento))
                    {
                        TelaFolhaEmpresa telaFolhaEmpresa = new TelaFolhaEmpresa(this);
                        telaFolhaEmpresa.Show();
                        telaFolhaEmpresa.WindowState = WindowState;
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, insira datas válidas.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, insira IDs válidos.");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Exceção " + ex.Message);
            }
        }

        private void dpDataFech_LostFocus(object sender, RoutedEventArgs e)
        {
            txtDataFechamento.Text = string.Empty;
            txtDataFechamento.Text = dpDataFechamento.Text.Trim();
            dpDataFechamento.Focusable = true;
        }

        private void dpDataPag_LostFocus(object sender, RoutedEventArgs e)
        {
            txtDataPagamento.Text = string.Empty;
            txtDataPagamento.Text = dpDataPagamento.Text.Trim();
            dpDataPagamento.Focusable = true;
        }

    }
}
