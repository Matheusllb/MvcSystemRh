using Sistema.Desktop.Controllers;
using Sistema.Model.Entidades;
using Sistema.Model.Interfaces.IDAO;
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
    /// Lógica interna para TelaFolhaVisualizacao.xaml
    /// </summary>
    public partial class TelaFolhaVisualizacao : Window
    {
        public TelaFolhaFuncionario terceiraTela;
        public BDFuncionarioDAO dao = new BDFuncionarioDAO();
        public BDFController controller;
        public FolhaPagamento folha;


        public TelaFolhaVisualizacao(TelaFolhaFuncionario telaFolhaFuncionario)
        {
            try
            {
                InitializeComponent();
                terceiraTela = telaFolhaFuncionario;
                controller = new BDFController(dao);

                int idE = terceiraTela.segundaTela.primeiraTela.idEmpresa;
                DateTime fechamentoNF = terceiraTela.segundaTela.primeiraTela.fechamento;
                DateTime pagamentoNF = terceiraTela.segundaTela.primeiraTela.pagamento;
                List<BeneficioDesconto> lista = controller.BuscaBD(terceiraTela.funcionario.Id);
                folha = new FolhaPagamento(idE, fechamentoNF, pagamentoNF, terceiraTela.funcionario, lista);

                MessageBox.Show("Folha gerada com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
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
            TelaFolhaGerada gerada = new TelaFolhaGerada();
            gerada.Show();
            gerada.WindowState = WindowState;
            Close();
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            terceiraTela.Show();
            terceiraTela.WindowState = WindowState;
            Close();
        }
    }
}
