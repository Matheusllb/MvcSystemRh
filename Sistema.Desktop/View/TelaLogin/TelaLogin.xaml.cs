using MahApps.Metro.IconPacks;
using Sistema.Desktop.Controllers;
using Sistema.Model.DAO;
using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sistema.Desktop
{
    /// <summary>
    /// Interação lógica para TelaLogin.xam
    /// </summary>
    public partial class TelaLogin : Window
    {
        private bool passwordVisible = false;
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void TelaLogin_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void pwbSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            TextBlock placeholderPasswordText = passwordBox.Template.FindName("PlaceholderPasswordText", passwordBox) as TextBlock;

            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                // Quando a senha estiver vazia, mostra o TextBlock de marcador de posição.
                placeholderPasswordText.Visibility = Visibility.Visible;
            }
            else
            {
                // Quando a senha tiver algum valor, oculta o TextBlock de marcador de posição.
                placeholderPasswordText.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string usuario = txbUsername.Text;
                string senha = pwbSenha.Password;

                UsuarioDAO usuarioDAO = new UsuarioDAO();
                AcessoController loginCtrl = new AcessoController(usuarioDAO);

                if (loginCtrl.Logar(usuario, senha))
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    this.Close();
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Falha ao entrar: " + ex.Message);
            }
        }

        private void FecharJanela_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMostrarSenha_Click(object sender, RoutedEventArgs e)
        {
            if (passwordVisible)
            {
                // Se a senha estiver visível, oculta o TextBox e mostra o PasswordBox
                btnMostrarSenha.Content = new PackIconMaterial { Kind = PackIconMaterialKind.Eye, Foreground = Brushes.White };
                pwbSenha.Password = txtPasswordBox.Text;
                txtPasswordBox.Visibility = Visibility.Hidden;
                pwbSenha.Visibility = Visibility.Visible;
            }
            else
            {
                // Se a senha estiver oculta, sincroniza o TextBox com o PasswordBox e mostra o TextBox
                btnMostrarSenha.Content = new PackIconMaterial { Kind = PackIconMaterialKind.EyeOff, Foreground = Brushes.White };
                txtPasswordBox.Text = pwbSenha.Password;
                txtPasswordBox.Visibility = Visibility.Visible;
                pwbSenha.Visibility = Visibility.Hidden;
            }

            passwordVisible = !passwordVisible;
        }
    }
}
