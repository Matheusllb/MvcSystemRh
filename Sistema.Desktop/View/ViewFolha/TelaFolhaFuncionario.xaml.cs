using Sistema.Desktop.Controllers;
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

namespace Sistema.Desktop.View.ViewFolha
{
    /// <summary>
    /// Lógica interna para TelaFolhaFuncionario.xaml
    /// </summary>
    public partial class TelaFolhaFuncionario : Window
    {
        private TelaFolhaEmpresa telaFolhaEmpresa;
        public Funcionario funcionario;
        public FuncionarioController controller;
        public FuncionarioDAO dao = new FuncionarioDAO();

        public TelaFolhaFuncionario(TelaFolhaEmpresa telaFolhaEmpresa)
        {
            this.telaFolhaEmpresa = telaFolhaEmpresa;

            funcionario = controller.GetById(telaFolhaEmpresa.telaFolhaPagamento.idFuncionario);

            InitializeComponent();
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            telaFolhaEmpresa.Show();
            telaFolhaEmpresa.WindowState = WindowState;
            Close();
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
            MessageBox.Show("Nova tela em breve");
        }
    }
}
