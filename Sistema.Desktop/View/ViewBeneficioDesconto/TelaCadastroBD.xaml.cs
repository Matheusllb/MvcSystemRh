using Sistema.Desktop.Controllers;
using Sistema.Model.Entidades;
using System.Collections.ObjectModel;
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

namespace Sistema.Desktop.View.ViewBeneficioDesconto
{
    /// <summary>
    /// Lógica interna para TelaCadastroBD.xaml
    /// </summary>
    public partial class TelaCadastroBD : Window
    {
        public TelaCadastroBD()
        {
            InitializeComponent();
        }
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Captura dos dados
                string descricao = txtDescricao.Text;
                bool desconto = rbDesconto.IsChecked ?? false; // Usar ?? false para evitar possíveis valores nulos
                decimal valor;

                if (string.IsNullOrWhiteSpace(descricao))
                {
                    throw new Exception("Preencha o campo de descrição antes de continuar");
                }

                if (!decimal.TryParse(txtValor.Text, out valor))
                {
                    throw new Exception("O valor não é um número decimal válido");
                }

                // Instanciação de objetos
                BeneficioDescontoDAO dao = new BeneficioDescontoDAO();
                BDController controller = new BDController(dao);
                BeneficioDesconto novoItem = new BeneficioDesconto(descricao, desconto, valor);

                if (desconto)
                {
                    novoItem.Valor = -valor;
                }

                if (controller.InsertOne(novoItem))
                {
                    MessageBox.Show("Item cadastrado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Falha ao registrar item!", "Falha!", MessageBoxButton.OK, MessageBoxImage.Stop);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao registrar item!" + ex.Message, "Falha!", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            TelaBeneficioDesconto tela = new TelaBeneficioDesconto();
            tela.Show();
            tela.WindowState = WindowState;
            Close();
        }
    }
}
