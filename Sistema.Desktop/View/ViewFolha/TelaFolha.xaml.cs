using Sistema.Desktop.Controllers;
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
    /// Lógica interna para TelaFolha.xaml
    /// </summary>
    public partial class TelaFolha : Window
    {

        public ObservableCollection<FolhaPagamento> Folhas = new ObservableCollection<FolhaPagamento>();
        public FolhaController controller;
        public FolhaPagamentoDAO dao = new FolhaPagamentoDAO();

        public TelaFolha()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscaId_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCriarNovo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
