using System;
using System.Windows.Forms;

namespace Sistema.Entidades
{
    public class Funcionario : Pessoa
    {
        private string _email;
        private DateTime _dataAdmissao;
        private Empresa _empresa;
        private string _cargo;
        private decimal _salarioBruto;


        public Funcionario(int id, string endereco, string nome, string cpf, DateTime dataNascimento, EstadoCivil estadoCivil,
            string email, DateTime dataAdimissao, Empresa empresa, string cargo, decimal salario) : base(id, endereco, nome, cpf, dataNascimento, estadoCivil)
        {
            _email = email;
            _dataAdmissao = dataAdimissao;
            _empresa = empresa;
            _cargo = cargo;
            _salarioBruto = salario;
        }

        override public int GetIdPessoa() { return _id; }
        override public string GetEnderecoPessoa() { return _endereco; }
        override public string GetNomePessoa() { return _nome; }
        override public string GetCpfPessoa() { return _cpf; }
        override public DateTime GetDataNascimentoPessoa() { return _dataNascimento; }
        override public EstadoCivil GetEstadoCivilPessoa() { return _estadoCivil; }
        public string GetEmailFuncionario() { return _email; }
        public DateTime GetDataAdmissaoFuncionario() { return _dataAdmissao; }
        public Empresa GetEmpresaFuncionario() { return _empresa; }
        public string GetCargoFuncionario() { return _cargo; }
        public decimal GetSalarioBrutoFuncionario() { return _salarioBruto; }

        override public void SetIdPessoa(int id) { _id = id; }
        override public void SetEnderecoPessoa(string endereco) { _endereco = endereco; }
        override public void SetNomePessoa(string nome) { _nome = nome; }
        override public void SetCpfPessoa(string cpf) { _cpf = cpf; }
        override public void SetDataNascimentoPessoa(DateTime dataNascimento) { _dataNascimento = dataNascimento; }
        override public void SetEstadoCivilPessoa(EstadoCivil estadoCivil) { _estadoCivil = estadoCivil; }
        public void SetEmailFuncionario(string email) { _email = email; }
        public void SetDataAdmissaoFuncionario(DateTime dataAdmissao) { _dataAdmissao = dataAdmissao; }
        public void SetEmpresaFuncionario(Empresa empresa) { _empresa = empresa; }
        public void SetCargoFuncionario(string cargo) { _cargo = cargo; }
        public void SetSalarioBrutoFuncionario(decimal salarioBruto) { _salarioBruto = salarioBruto; } 

    }
}
