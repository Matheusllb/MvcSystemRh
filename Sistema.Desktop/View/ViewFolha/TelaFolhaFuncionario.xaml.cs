﻿using Sistema.Desktop.Controllers;
using Sistema.Model.DAO;
using Sistema.Model.Entidades;
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
    /// Lógica interna para TelaFolhaFuncionario.xaml
    /// </summary>
    public partial class TelaFolhaFuncionario : Window
    {
        public TelaFolhaEmpresa segundaTela;
        public Funcionario funcionario;
        public FuncionarioController controller;
        public FuncionarioDAO dao = new FuncionarioDAO();

        public TelaFolhaFuncionario(TelaFolhaEmpresa telaFolhaEmpresa)
        {
            try
            {
                InitializeComponent();
                segundaTela = telaFolhaEmpresa;
                controller = new FuncionarioController(dao);
                funcionario = controller.GetById(segundaTela.primeiraTela.idFuncionario);

                txtCodFuncionario.Text = funcionario.Id.ToString();
                txtNomeFuncionario.Text = funcionario.Nome;
                txtCPFFuncionario.Text = funcionario.CPF;
                txtDataNascFuncionario.Text = funcionario.DataNascimento.ToString("dd/MM/yyyy");
                txtECFuncionario.Text = funcionario.EstadoCivilP.ToString();
                txtEnderecoFuncionario.Text = funcionario.Endereco;
                txtEmailFuncionario.Text = funcionario.Email;
                txtDataAdmissãoFuncionario.Text = funcionario.DataAdmissao.ToString("dd/MM/yyyy");
                txtCodEmpresaF.Text = funcionario.IdEmpresa.ToString();
                txtCargoFuncionario.Text = funcionario.Cargo;
                txtSalarioFuncionario.Text = funcionario.SalarioBruto.ToString();

            }catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            segundaTela.Show();
            segundaTela.WindowState = WindowState;
            Close();
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
            TelaFolhaVisualizacao quartaTela = new TelaFolhaVisualizacao(this);
            quartaTela.Show();
            quartaTela.WindowState = WindowState;
            Close();
        }
    }
}
