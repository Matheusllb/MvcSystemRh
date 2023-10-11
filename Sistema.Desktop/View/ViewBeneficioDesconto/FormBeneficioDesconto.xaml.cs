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
using Sistema.Model.Entidades;

namespace Sistema.Desktop.View.ViewBeneficioDesconto
{
    /// <summary>
    /// Interação lógica para FormBeneficioDesconto.xam
    /// </summary>
    public partial class FormBeneficioDesconto : Page
    {
        public FormBeneficioDesconto()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Caputa dos dados
                string descricao = txtDescricao.Text;
                bool desconto = rbDesconto.IsChecked.Value;
                decimal valor = decimal.Parse(txtValor.Text);

                // Instanciação de objetos
                BeneficioDescontoDAO dao = new BeneficioDescontoDAO();
                BDController controller = new BDController(dao);
                BeneficioDesconto novoItem = new BeneficioDesconto(descricao, desconto, valor);

                if (desconto is true) // Se o desconto estiver marcado
                {
                    novoItem.SetValorBeneficioDesconto(-valor); // O valor do novo item passa a ser negativo
                }

                if (controller.InsertOne(novoItem)) // Se o método retornar 'true' indica sucesso
                {
                    MessageBox.Show("Item cadastrado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }

    }
}
