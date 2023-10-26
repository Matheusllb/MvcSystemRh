using Sistema.Desktop.Controllers;
using Sistema.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
                listViewBD.ItemsSource = BfDs;
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
                string pesquisa = txtSearchBD.Text;
                if (pesquisa is null)
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

                    listViewBD.ItemsSource = listaFiltrada;
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
                if(listViewBD.SelectedItem is null)
                {
                    throw new Exception("Selecione um item que deseja modificar.");
                }
                else
                {
                    BeneficioDesconto selecionado = listViewBD.SelectedItem as BeneficioDesconto;
                    if(MessageBox.Show("Deseja modificar este item?","Alteração de dados", MessageBoxButton.YesNo, MessageBoxImage.Question) is MessageBoxResult.Yes)
                    {
                        txtSearchBD.Visibility = Visibility.Hidden;
                        btnFiltrar.Visibility = Visibility.Hidden;
                        btnCriarNovo.Visibility = Visibility.Hidden;
                        btnAlterar.Visibility = Visibility.Hidden;
                        btnDeletar.Visibility = Visibility.Hidden;
                        menuAlterar.Visibility = Visibility.Visible;
                        
                        if (controller.UpdateOne(selecionado))
                        {
                            MessageBox.Show("Item modificado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Falha ao modificar item!", "Falha!", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                    else
                    {
                        listViewBD.SelectedItem = null;
                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listViewBD.SelectedItem is null)
                {
                    throw new Exception("Selecione um item que deseja excluír.");
                }
                else
                {
                    BeneficioDesconto selecionado = listViewBD.SelectedItem as BeneficioDesconto;
                    if(MessageBox.Show("Tem certeza que deseja excluír este item?","Item será excluído", MessageBoxButton.YesNo, MessageBoxImage.Question) is MessageBoxResult.Yes)
                    {
                        if (controller.DeleteOne(selecionado.Id))
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
                        listViewBD.SelectedItem = null;
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

        }
    }
}
