using Sistema.Desktop.Controllers;
using Sistema.Desktop.View.ViewTelaEmpresa;
using Sistema.Model.Entidades;
using Sistema.Model.Entidades.Enum;
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

        private void btnProximo_Click(object sender, RoutedEventArgs e)
        {
            stkNome.Visibility = Visibility.Hidden;
            stkCPF.Visibility = Visibility.Hidden;
            stkDataNascimento.Visibility = Visibility.Hidden;
            stkEstadoCivil.Visibility = Visibility.Hidden;
            stkEndereco.Visibility = Visibility.Hidden;

            stkEmail.Visibility = Visibility.Visible;
            stkDataAdmissao.Visibility = Visibility.Visible;
            stkEmpresa.Visibility = Visibility.Visible;
            stkCargo.Visibility = Visibility.Visible;
            stkSalario.Visibility = Visibility.Visible;

            btnRetornar.Visibility = Visibility.Visible;
            btnProximo.Visibility = Visibility.Collapsed;
            btnRegistrar.Visibility = Visibility.Visible;
        }

        private void btnRetornar_Click(object sender, RoutedEventArgs e)
        {
            stkEmail.Visibility = Visibility.Hidden;
            stkDataAdmissao.Visibility = Visibility.Hidden;
            stkEmpresa.Visibility = Visibility.Hidden;
            stkCargo.Visibility = Visibility.Hidden;
            stkSalario.Visibility = Visibility.Hidden;

            stkNome.Visibility = Visibility.Visible;
            stkCPF.Visibility = Visibility.Visible;
            stkDataNascimento.Visibility = Visibility.Visible;
            stkEstadoCivil.Visibility = Visibility.Visible;
            stkEndereco.Visibility = Visibility.Visible;

            btnRetornar.Visibility = Visibility.Collapsed;
            btnProximo.Visibility = Visibility.Visible;
            btnRegistrar.Visibility = Visibility.Collapsed;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                string cpf = txtCpf.Text;
                DateTime dataNas = DateTime.Parse(txtDataNascimento.Text);
                EstadoCivil eC = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), txtEstadoCivil.Text);
                string endereco = txtEndereco.Text;
                string email = txtEmail.Text;
                DateTime dataAdm = DateTime.Parse(txtDataAdmissao.Text);
                int idEmpresa = int.Parse(txtEmpresa.Text);
                string cargo = txtCargo.Text;
                decimal salario = decimal.Parse(txtSalario.Text);
                bool ativo = true;

                if (string.IsNullOrEmpty(txtNome.Text) ||
                    string.IsNullOrEmpty(txtCpf.Text) ||
                    string.IsNullOrEmpty(txtDataNascimento.Text) ||
                    string.IsNullOrEmpty(txtEstadoCivil.Text) ||
                    string.IsNullOrEmpty(txtEndereco.Text) ||
                    string.IsNullOrEmpty(txtEmail.Text) ||
                    string.IsNullOrEmpty(txtDataAdmissao.Text) ||
                    string.IsNullOrEmpty(txtEmpresa.Text) ||
                    string.IsNullOrEmpty(txtCargo.Text) ||
                    string.IsNullOrEmpty(txtSalario.Text))
                {
                    throw new Exception("Preencha os campos vazios antes de continuar");
                }
                else
                {
                    // Instanciação de objetos
                    FuncionarioDAO dao = new FuncionarioDAO();
                    FuncionarioController controller = new FuncionarioController(dao);
                    Funcionario novoItem = new Funcionario(ativo, endereco, nome, cpf, dataNas, eC, email, dataAdm, idEmpresa, cargo, salario);

                    if (controller.InsertOne(novoItem))
                    {
                        if (controller.Insert(novoItem))
                        {
                            MessageBox.Show("Item cadastrado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
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
    }
}
