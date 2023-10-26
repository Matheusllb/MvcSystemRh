using Sistema.Desktop.Controllers;
using Sistema.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
    /// Lógica interna para BeneficioDesconto.xaml
    /// </summary>
    public partial class TelaBeneficioDesconto : Window
    {
        public ObservableCollection<BeneficioDesconto> BfDs = new ObservableCollection<BeneficioDesconto>();

        public TelaBeneficioDesconto()
        {
            try
            {
                BeneficioDescontoDAO dao = new BeneficioDescontoDAO();
                BDController controller = new BDController(dao);

                // Obtém os dados usando o método GetAll
                List<BeneficioDesconto> beneficios = controller.GetAll();

                // Adiciona os dados à lista de dados da view
                if (beneficios != null)
                {
                    BfDs = new ObservableCollection<BeneficioDesconto>(beneficios);
                }

                InitializeComponent();

                // Associa a lista de dados à ListView
                listViewBD.ItemsSource = BfDs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro SQL: " + ex.Message);
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            menu.WindowState = WindowState;
            Close();
        }

        private void btnCriarNovo_Click(object sender, RoutedEventArgs e)
        {
            TelaCadastroBD telaCadastro = new TelaCadastroBD();
            telaCadastro.Show();
            telaCadastro.WindowState = WindowState;
            Close();
        }

    }
}
