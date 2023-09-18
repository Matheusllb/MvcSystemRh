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
        public TelaLogin()
        {
            InitializeComponent();
            txbUsername.GotFocus += TextBox_GotFocus;
            txbSenha.GotFocus += PasswordBox_GotFocus;


        }
        private bool usernameBoxFirstFocus = true;
        private bool senhaBoxFirstFocus = true;

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                if (textBox.Name == "txbUsername" && usernameBoxFirstFocus)
                {
                    textBox.Text = "";
                    usernameBoxFirstFocus = false;
                }
                else if (textBox.Name == "txbSenha" && senhaBoxFirstFocus)
                {
                    textBox.Text = "";
                    senhaBoxFirstFocus = false;
                }
            }
        }
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox != null)
            {
                if (passwordBox.Name == "txbSenha" && senhaBoxFirstFocus)
                {
                    passwordBox.Clear();
                    senhaBoxFirstFocus = false;
                }
            }
        }








        private void TelaLogin_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AcessoController loginCtrl = new AcessoController();
            if (loginCtrl.Logar(txbUsername.Text, pwbSenha.Password))
            {
                this.Close();   
                MessageBox.Show("Logado!");
            }
            else
            {
                MessageBox.Show("Nome de usuário ou senha incorretos!");
            }
        }
    }
}
