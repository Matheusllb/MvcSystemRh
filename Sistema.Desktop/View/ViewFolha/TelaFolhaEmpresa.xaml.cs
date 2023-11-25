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
        public TelaFolhaPagamento telaFolhaPagamento;
        public Empresa empresa;
        public EmpresaController controller;
        public EmpresaDAO dao = new EmpresaDAO();

        public TelaFolhaEmpresa(TelaFolhaPagamento telaFolhaPagamento)
        {
            InitializeComponent();
            this.telaFolhaPagamento = telaFolhaPagamento;

            try
            {
                empresa = controller.GetById(telaFolhaPagamento.idEmpresa);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            telaFolhaPagamento.Show();
            telaFolhaPagamento.WindowState = WindowState;
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
