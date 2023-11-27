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
using System.Globalization;

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
                folha = new FolhaPagamento(idE, fechamentoNF, pagamentoNF, terceiraTela.funcionario);

                lblCodE.Content = terceiraTela.segundaTela.empresa.Id.ToString();
                lblNomeEmpresa.Content = terceiraTela.segundaTela.empresa.Nome;
                lblEnderecoEmpresa.Content = terceiraTela.segundaTela.empresa.Endereco;
                lblCNPJEmpresa.Content = terceiraTela.segundaTela.empresa.Cnpj;
                lblMesFechamento.Content = terceiraTela.segundaTela.primeiraTela.fechamento.ToString("MM/yyyy");
                lblCodF.Content = terceiraTela.funcionario.Id.ToString();
                lblNomeF.Content = terceiraTela.funcionario.Nome;
                lblCargo.Content = terceiraTela.funcionario.Cargo;
                lblAdmissao.Content = terceiraTela.funcionario.DataAdmissao.ToString("dd/MM/yyyy");
                lblValorSalario.Content = terceiraTela.funcionario.SalarioBruto.ToString("2F");
                lblValoVencimento.Content = terceiraTela.funcionario.SalarioBruto.ToString();
                lblVDescontoINSS.Content = folha.SalarioINSS.ToString();
                lblVDescontosIRRF.Content = folha.ValorIRRF.ToString();
                lblTotalVencimentos.Content = folha.CalculaTotalVencimentos().ToString();
                lblTotalDescontos.Content = folha.CalculaTotalDescontos().ToString();
                lblTotalLiquido.Content = folha.CalculaTotalLiquido().ToString();
                lblPagamento.Content = terceiraTela.segundaTela.primeiraTela.pagamento.ToString("dd/MM/yyyy");

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
