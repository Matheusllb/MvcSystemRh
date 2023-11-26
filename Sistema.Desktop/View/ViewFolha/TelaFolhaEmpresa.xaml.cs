using Sistema.Desktop.Controllers;
using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica interna para TelaEmpresa.xaml
    /// </summary>
    /// 

    public partial class TelaFolhaEmpresa : Window
    {
        public TelaFolhaPagamento telaAnterior;
        public Empresa empresa;
        public EmpresaDAO dao = new EmpresaDAO();
        public EmpresaController controller;

        public TelaFolhaEmpresa(TelaFolhaPagamento telaFolhaPagamento)
        {
            try
            {
                InitializeComponent();
                telaAnterior = telaFolhaPagamento;
                controller = new EmpresaController(dao);
                empresa = controller.GetById(telaAnterior.idEmpresa);

                txtCodEmpresa.Text = empresa.Id.ToString();
                txtNomeEmpresa.Text = empresa.Nome;
                txtCNPJEmpresa.Text = empresa.Cnpj;
                txtSetorEmpresa.Text = empresa.Setor;
                txtEmailEmpresa.Text = empresa.Email;
                txtEnderecoEmpresa.Text = empresa.Endereco;
                txtTelefoneEmpresa.Text = empresa.Telefone;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            telaAnterior.Show();
            telaAnterior.WindowState = WindowState;
            Close();
        }

        private void btnContinuar_Click(object sender, RoutedEventArgs e)
        {
            TelaFolhaFuncionario telaFolhaFuncionario = new TelaFolhaFuncionario(this);
            telaFolhaFuncionario.Show();
            telaFolhaFuncionario.WindowState = WindowState;
            Hide();
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
    }
}
