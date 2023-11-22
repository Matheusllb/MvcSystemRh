using System;
using System.Collections.Generic;
using Sistema.Model.Entidades.Enum;
using Sistema.Model.Interfaces.IDAO;

namespace Sistema.Model.Entidades
{
    public class Usuario : Pessoa, IEntidade
    {
        public int Id { get; set; }
        private int IdUsuario;
        private int IdPermissao;
        private bool Ativo;
        private string Login;
        private string Senha;

        public Usuario() : base() { }

        public Usuario(string endereco, string nome, string cpf, DateTime dataNascimento, EstadoCivil estadoCivil, int idUsuario, int idPermissao, bool status, 
            string login, string senha) : base(endereco, nome, cpf, dataNascimento, estadoCivil)
        {
            IdUsuario = idUsuario;
            IdPermissao = idPermissao;
            Ativo = status;
            Login = login;
            Senha = senha;
        }

        public int GetIdUsuario() { return IdUsuario; }
        public bool GetStatusUsuario() { return Ativo; }
        public int GetIdPermissaoUsuario() { return IdPermissao; }
        public string GetLogin() { return Login;}
        public string GetSenha() { return Senha;}
        public void SetIdUsuario(int idUsuario) { IdUsuario = idUsuario; }
        public void SetStatusUsuario(bool status) { Ativo = status; }
        public void SetIdPermissaoUsuario(int idPermissao) { IdPermissao = idPermissao; }
        public void SetLoginUsuario(string login) { Login = login; }
        public void SetSenhaUsuario(string senha) {  Senha = senha; }
    }

}
