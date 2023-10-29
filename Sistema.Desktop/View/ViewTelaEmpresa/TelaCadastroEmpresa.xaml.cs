using Sistema.Desktop.Controllers;
using Sistema.Desktop.View.ViewBeneficioDesconto;
using Sistema.Model.DAO;
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

namespace Sistema.Desktop.View.ViewTelaEmpresa
{
    /// <summary>
    /// Lógica interna para TelaCadastroEmpresa.xaml
    /// </summary>
    public partial class TelaCadastroEmpresa : Window
    {
        public TelaCadastroEmpresa()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Captura dos dados
                string nome = txtNome.Text;
                string cnpj = txtCnpj.Text;
                string setor = txtSetor.Text;
                string email = txtEmail.Text;
                string telefone = txtTelefone.Text;
                string endereco = txtEndereco.Text;

                if (nome == null || cnpj == null || setor == null || email == null || telefone == null || endereco == null)
                {
                    throw new Exception("Preencha os campos vazios antes de continuar");
                }
                else
                {
                    // Instanciação de objetos
                    EmpresaDAO dao = new EmpresaDAO();
                    EmpresaController controller = new EmpresaController(dao);
                    Empresa novoItem = new Empresa(nome, cnpj, setor, email, telefone, endereco);

                    if (controller.InsertOne(novoItem))
                    {
                        MessageBox.Show("Item cadastrado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Falha ao registrar item!", "Falha!", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao registrar item!" + ex.Message, "Falha!", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
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
