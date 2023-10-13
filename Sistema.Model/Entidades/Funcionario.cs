using System;
using System.Collections.Generic;
using Sistema.Model.Entidades.Enum;

namespace Sistema.Model.Entidades
{
    public class Funcionario : Pessoa
    {
        private int IdFuncionario;
        private bool Ativo;
        private string Email;
        private DateTime DataAdmissao;
        private int IdEmpresa;
        private string Cargo;
        private decimal SalarioBruto;

        public Funcionario() : base() { }

        public Funcionario(int idFuncionario, bool status,string endereco, string nome, string cpf, DateTime dataNascimento, EstadoCivil estadoCivil,
            string email, DateTime dataAdimissao, int idEmpresa, string cargo, decimal salario) : base(endereco, nome, cpf, dataNascimento, estadoCivil)
        {
            IdFuncionario = idFuncionario;
            Ativo = status;
            Email = email;
            DataAdmissao = dataAdimissao;
            IdEmpresa = idEmpresa;
            Cargo = cargo;
            SalarioBruto = salario;
        }

        public override string GetEnderecoPessoa() { return Endereco; }
        public override string GetNomePessoa() { return Nome; }
        public override string GetCpfPessoa() { return Cpf; }
        public override DateTime GetDataNascimentoPessoa() { return DataNascimento; }
        public override EstadoCivil GetEstadoCivilPessoa() { return EstadoCivil; }
        public int GetIdFuncionario() { return IdFuncionario; }
        public bool GetAtivo() { return Ativo; }
        public string GetEmailFuncionario() { return Email; }
        public bool GetStatusFuncionario() { return Ativo; }
        public DateTime GetDataAdmissaoFuncionario() { return DataAdmissao; }
        public int GetIdEmpresaFuncionario() { return IdEmpresa; }
        public string GetCargoFuncionario() { return Cargo; }
        public decimal GetSalarioBrutoFuncionario() { return SalarioBruto; }

        public override void SetEnderecoPessoa(string endereco) { Endereco = endereco; }
        public override void SetNomePessoa(string nome) { Nome = nome; }
        public override void SetCpfPessoa(string cpf) { Cpf = cpf; }
        public override void SetDataNascimentoPessoa(DateTime dataNascimento) { DataNascimento = dataNascimento; }
        public override void SetEstadoCivilPessoa(EstadoCivil estadoCivil) { EstadoCivil = estadoCivil; }
        public void SetIdFuncionario(int idFuncionario) { IdFuncionario = idFuncionario; }
        public void SetAtivo(bool ativo) {  Ativo = ativo; }
        public void SetStatusFuncionario(bool status) { Ativo = status; }
        public void SetEmailFuncionario(string email) { Email = email; }
        public void SetDataAdmissaoFuncionario(DateTime dataAdmissao) { DataAdmissao = dataAdmissao; }
        public void SetIdEmpresaFuncionario(int empresa) { IdEmpresa = empresa; }
        public void SetCargoFuncionario(string cargo) { Cargo = cargo; }
        public void SetSalarioBrutoFuncionario(decimal salarioBruto) { SalarioBruto = salarioBruto; } 

    }
}
