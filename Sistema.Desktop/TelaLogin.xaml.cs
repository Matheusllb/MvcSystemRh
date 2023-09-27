using MahApps.Metro.IconPacks;
using Sistema.Desktop.Controllers;
using Sistema.Model.DAO;
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
        private string originalPassword = "";
        private TextBox tempTextBox;
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
            AcessoController loginCtrl = new AcessoController();
            if (loginCtrl.Logar(txbUsername.Text, pwbSenha.Password))
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nome de usuário ou senha incorretos!");
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
                // Se a senha estiver visível, oculte o TextBox e mostre o PasswordBox
                txtPasswordBox.Visibility = Visibility.Collapsed;
                pwbSenha.Visibility = Visibility.Visible;
            }
            else
            {
                // Se a senha estiver oculta, mostre o TextBox e oculte o PasswordBox
                txtPasswordBox.Text = pwbSenha.Password;
                txtPasswordBox.Visibility = Visibility.Visible;
                pwbSenha.Visibility = Visibility.Collapsed;
            }

            passwordVisible = !passwordVisible;
        }
    }
}
