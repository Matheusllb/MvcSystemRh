using Sistema.Desktop.Controllers;
using Sistema.Desktop.View.ViewBeneficioDesconto;
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

namespace Sistema.Desktop.View.ViewTelaEmpresa
{
    /// <summary>
    /// Lógica interna para TelaEmpresa.xaml
    /// </summary>
    public partial class TelaEmpresa : Window
    {
        public ObservableCollection<Empresa> empresas = new ObservableCollection<Empresa>();
        public EmpresaController controller;
        public EmpresaDAO dao = new EmpresaDAO();
        public TelaEmpresa()
        {
            try
            {
                controller = new EmpresaController(dao);

                List<Empresa> dados = controller.GetAll();

                if (dados != null)
                {
                    empresas = new ObservableCollection<Empresa>(dados);
                }

                InitializeComponent();

                listView.ItemsSource = empresas;
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

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtSearch.Text = null;
                List<Empresa> dados = controller.GetAll();

                // Adiciona os dados à lista de dados da view
                if (dados != null)
                {
                    empresas = new ObservableCollection<Empresa>(dados);
                }

                listView.ItemsSource = empresas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    List<Empresa> listaFiltrada = controller.FilterData(pesquisa);

                    if (listaFiltrada != null)
                    {
                        empresas = new ObservableCollection<Empresa>(listaFiltrada);
                    }

                    listView.ItemsSource = listaFiltrada;
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
                    Empresa itemEncontrado = controller.GetById(id);
                    if (itemEncontrado != null)
                    {
                        empresas = new ObservableCollection<Empresa>(new List<Empresa> { itemEncontrado });
                        listView.ItemsSource = empresas;
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

        private void btnCriarNovo_Click(object sender, RoutedEventArgs e)
        {
            TelaCadastroEmpresa telaCadastro = new TelaCadastroEmpresa();
            telaCadastro.Show();
            telaCadastro.WindowState = WindowState;
            Close();
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
                    Empresa selecionado = listView.SelectedItem as Empresa;
                    if (MessageBox.Show("Tem certeza que deseja excluír este item?", "Item será excluído", MessageBoxButton.YesNo, MessageBoxImage.Question) is MessageBoxResult.Yes)
                    {
                        if (controller.Inativar(selecionado.Id))
                        {
                            MessageBox.Show("Item excluído com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                            empresas.Remove(selecionado);
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
                Empresa selecionado = listView.SelectedItem as Empresa;

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
    }
}
