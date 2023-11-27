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

        public TelaFolhaVisualizacao(TelaFolhaFuncionario telaFolhaFuncionario)
        {
            try
            {
                InitializeComponent();
                terceiraTela = telaFolhaFuncionario;

                int idE = terceiraTela.segundaTela.primeiraTela.idEmpresa;
                DateTime fechamentoNF = terceiraTela.segundaTela.primeiraTela.fechamento;
                DateTime pagamentoNF = terceiraTela.segundaTela.primeiraTela.pagamento;
                BDFuncionarioDAO dao = new BDFuncionarioDAO();
                BDFController controller = new BDFController(dao);
                List<BeneficioDesconto> lista = controller.BuscaBD(terceiraTela.funcionario.Id);

                FolhaPagamento novaFolha = new FolhaPagamento(idE, fechamentoNF, pagamentoNF, terceiraTela.funcionario, lista);

                MessageBox.Show("Folha gerada com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}
