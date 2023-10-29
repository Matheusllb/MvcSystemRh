using Sistema.Desktop.Controllers;
using Sistema.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
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
        public BDController controller;
        public BeneficioDescontoDAO dao = new BeneficioDescontoDAO();

        public TelaBeneficioDesconto()
        {
            try
            {
                controller = new BDController(dao);

                // Obtém os dados usando o método GetAll
                List<BeneficioDesconto> beneficios = controller.GetAll();

                // Adiciona os dados à lista de dados da view
                if (beneficios != null)
                {
                    BfDs = new ObservableCollection<BeneficioDesconto>(beneficios);
                }

                InitializeComponent();

                // Associa a lista de dados à ListView
                listView.ItemsSource = BfDs;
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

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pesquisa = txtSearch.Text;
                if (string.IsNullOrEmpty(pesquisa))
                {
                    throw new Exception("Insira um valor na barra de pesquisa antes de filtrar os dados.");
                }
                else
                {
                    List<BeneficioDesconto> listaFiltrada = controller.FilterData(pesquisa);

                    if (listaFiltrada != null)
                    {
                        BfDs = new ObservableCollection<BeneficioDesconto>(listaFiltrada);
                    }

                    listView.ItemsSource = listaFiltrada;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listView.SelectedItem is null)
                {
                    throw new Exception("Selecione um item que deseja modificar.");
                }
                else
                {

                    if (MessageBox.Show("Deseja modificar este item?", "Alteração de dados", MessageBoxButton.YesNo, MessageBoxImage.Question) is MessageBoxResult.Yes)
                    {
                        txtSearch.Visibility = Visibility.Hidden;
                        btnFiltrar.Visibility = Visibility.Hidden;
                        btnAtualizar.Visibility = Visibility.Hidden;
                        btnBuscaId.Visibility = Visibility.Hidden;
                        btnCriarNovo.Visibility = Visibility.Hidden;
                        btnAlterar.Visibility = Visibility.Hidden;
                        btnDeletar.Visibility = Visibility.Hidden;
                        menuAlterar.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        listView.SelectedItem = null;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listView.SelectedItem is null)
                {
                    throw new Exception("Selecione um item que deseja excluír.");
                }
                else
                {
                    BeneficioDesconto selecionado = listView.SelectedItem as BeneficioDesconto;
                    if (MessageBox.Show("Tem certeza que deseja excluír este item?", "Item será excluído", MessageBoxButton.YesNo, MessageBoxImage.Question) is MessageBoxResult.Yes)
                    {
                        if (controller.Inativar(selecionado.Id))
                        {
                            MessageBox.Show("Item excluído com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                            BfDs.Remove(selecionado);
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluír item!", "Falha!", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                    else
                    {
                        listView.SelectedItem = null;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BeneficioDesconto selecionado = listView.SelectedItem as BeneficioDesconto;
                if ((bool)rbDesconto.IsChecked)
                {
                    selecionado.Desconto = true;
                    selecionado.Valor = -selecionado.Valor;
                }
                else if ((bool)rbBeneficio.IsChecked)
                {
                    selecionado.Desconto = false;
                    selecionado.Valor = Math.Abs(selecionado.Valor);
                }

                if (controller.UpdateOne(selecionado))
                {
                    MessageBox.Show("Item modificado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtSearch.Visibility = Visibility.Visible;
                    btnAtualizar.Visibility = Visibility.Visible;
                    btnBuscaId.Visibility = Visibility.Visible;
                    btnFiltrar.Visibility = Visibility.Visible;
                    btnCriarNovo.Visibility = Visibility.Visible;
                    btnAlterar.Visibility = Visibility.Visible;
                    btnDeletar.Visibility = Visibility.Visible;
                    menuAlterar.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Falha ao modificar item!", "Falha!", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscaId_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pesquisa = txtSearch.Text;
                if (string.IsNullOrEmpty(pesquisa))
                {
                    MessageBox.Show("Insira um valor na barra de pesquisa antes de filtrar os dados.");
                    return;
                }

                if (int.TryParse(pesquisa, out int id))
                {
                    BeneficioDesconto itemEncontrado = controller.GetById(id);
                    if (itemEncontrado != null)
                    {
                        BfDs = new ObservableCollection<BeneficioDesconto>(new List<BeneficioDesconto> { itemEncontrado });
                        listView.ItemsSource = BfDs;
                    }
                    else
                    {
                        MessageBox.Show("ID não encontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("Somente números representam um ID!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtSearch.Text = null;
                List<BeneficioDesconto> beneficios = controller.GetAll();

                // Adiciona os dados à lista de dados da view
                if (beneficios != null)
                {
                    BfDs = new ObservableCollection<BeneficioDesconto>(beneficios);
                }

                listView.ItemsSource = BfDs;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
