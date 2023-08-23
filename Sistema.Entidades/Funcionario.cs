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

        public override int GetIdPessoa() { return _id; }
        public override string GetEnderecoPessoa() { return _endereco; }
        public override string GetNomePessoa() { return _nome; }
        public override string GetCpfPessoa() { return _cpf; }
        public override DateTime GetDataNascimentoPessoa() { return _dataNascimento; }
        public override EstadoCivil GetEstadoCivilPessoa() { return _estadoCivil; }
        public string GetEmailFuncionario() { return _email; }
        public DateTime GetDataAdmissaoFuncionario() { return _dataAdmissao; }
        public Empresa GetEmpresaFuncionario() { return _empresa; }
        public string GetCargoFuncionario() { return _cargo; }
        public decimal GetSalarioBrutoFuncionario() { return _salarioBruto; }

        public override void SetIdPessoa(int id) { _id = id; }
        public override void SetEnderecoPessoa(string endereco) { _endereco = endereco; }
        public override void SetNomePessoa(string nome) { _nome = nome; }
        public override void SetCpfPessoa(string cpf) { _cpf = cpf; }
        public override void SetDataNascimentoPessoa(DateTime dataNascimento) { _dataNascimento = dataNascimento; }
        public override void SetEstadoCivilPessoa(EstadoCivil estadoCivil) { _estadoCivil = estadoCivil; }
        public void SetEmailFuncionario(string email) { _email = email; }
        public void SetDataAdmissaoFuncionario(DateTime dataAdmissao) { _dataAdmissao = dataAdmissao; }
        public void SetEmpresaFuncionario(Empresa empresa) { _empresa = empresa; }
        public void SetCargoFuncionario(string cargo) { _cargo = cargo; }
        public void SetSalarioBrutoFuncionario(decimal salarioBruto) { _salarioBruto = salarioBruto; } 

    }
}
