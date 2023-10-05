using System;
using System.Collections.Generic;
using Sistema.Model.Entidades.Enum;

namespace Sistema.Model.Entidades
{
    public class Funcionario : Pessoa
    {
        private int _idFuncionario;
        private bool _ativo;
        private string _email;
        private DateTime _dataAdmissao;
        private int _idEmpresa;
        private string _cargo;
        private decimal _salarioBruto;

        public Funcionario() : base() { }

        public Funcionario(int id, int idFuncionario, bool status,string endereco, string nome, string cpf, DateTime dataNascimento, EstadoCivil estadoCivil,
            string email, DateTime dataAdimissao, int idEmpresa, string cargo, decimal salario) : base(id, endereco, nome, cpf, dataNascimento, estadoCivil)
        {
            _idFuncionario = idFuncionario;
            _ativo = status;
            _email = email;
            _dataAdmissao = dataAdimissao;
            _idEmpresa = idEmpresa;
            _cargo = cargo;
            _salarioBruto = salario;
        }

        public override string GetEnderecoPessoa() { return _endereco; }
        public override string GetNomePessoa() { return _nome; }
        public override string GetCpfPessoa() { return _cpf; }
        public override DateTime GetDataNascimentoPessoa() { return _dataNascimento; }
        public override EstadoCivil GetEstadoCivilPessoa() { return _estadoCivil; }
        public int GetIdFuncionario() { return _idFuncionario; }
        public bool GetAtivo() { return _ativo; }
        public string GetEmailFuncionario() { return _email; }
        public bool GetStatusFuncionario() { return _ativo; }
        public DateTime GetDataAdmissaoFuncionario() { return _dataAdmissao; }
        public int GetIdEmpresaFuncionario() { return _idEmpresa; }
        public string GetCargoFuncionario() { return _cargo; }
        public decimal GetSalarioBrutoFuncionario() { return _salarioBruto; }

        public override void SetEnderecoPessoa(string endereco) { _endereco = endereco; }
        public override void SetNomePessoa(string nome) { _nome = nome; }
        public override void SetCpfPessoa(string cpf) { _cpf = cpf; }
        public override void SetDataNascimentoPessoa(DateTime dataNascimento) { _dataNascimento = dataNascimento; }
        public override void SetEstadoCivilPessoa(EstadoCivil estadoCivil) { _estadoCivil = estadoCivil; }
        public void SetIdFuncionario(int idFuncionario) { _idFuncionario = idFuncionario; }
        public void SetAtivo(bool ativo) {  _ativo = ativo; }
        public void SetStatusFuncionario(bool status) { _ativo = status; }
        public void SetEmailFuncionario(string email) { _email = email; }
        public void SetDataAdmissaoFuncionario(DateTime dataAdmissao) { _dataAdmissao = dataAdmissao; }
        public void SetIdEmpresaFuncionario(int empresa) { _idEmpresa = empresa; }
        public void SetCargoFuncionario(string cargo) { _cargo = cargo; }
        public void SetSalarioBrutoFuncionario(decimal salarioBruto) { _salarioBruto = salarioBruto; } 

    }
}
