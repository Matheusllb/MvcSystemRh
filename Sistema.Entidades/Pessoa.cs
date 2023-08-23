using System;

namespace Sistema.Entidades
{
    abstract public class Pessoa
    {
        protected int _id;
        protected string _endereco;
        protected string _nome;
        protected string _cpf;
        protected DateTime _dataNascimento;
        protected EstadoCivil _estadoCivil;

        public Pessoa(int id, string endereco, string nome, string cpf, DateTime dataNascimento, EstadoCivil estadoCivil)
        {
            _id = id;
            _endereco = endereco;
            _nome = nome;
            _cpf = cpf;
            _dataNascimento = dataNascimento;
            _estadoCivil = estadoCivil;
        }

        virtual public int GetIdPessoa() { return _id; }
        virtual public string GetEnderecoPessoa() { return _endereco; }
        virtual public string GetNomePessoa() { return _nome; }
        virtual public string GetCpfPessoa() { return _cpf; }
        virtual public DateTime GetDataNascimentoPessoa() { return _dataNascimento; }
        virtual public EstadoCivil GetEstadoCivilPessoa() { return _estadoCivil; }

        virtual public void SetIdPessoa(int id) { _id = id; }
        virtual public void SetEnderecoPessoa(string endereco) { _endereco = endereco; }
        virtual public void SetNomePessoa(string nome) { _nome = nome; }
        virtual public void SetCpfPessoa(string cpf) { _cpf = cpf; }
        virtual public void SetDataNascimentoPessoa(DateTime dataNascimento) { _dataNascimento = dataNascimento; }
        virtual public void SetEstadoCivilPessoa(EstadoCivil estadoCivil) { _estadoCivil = estadoCivil; }

    }
}
