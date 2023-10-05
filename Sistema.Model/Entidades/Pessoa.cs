using System;
using Sistema.Model.Entidades.Enum;
using Sistema.Model.Interfaces.IDAO;

namespace Sistema.Model.Entidades
{
    abstract public class Pessoa : IEntidade
    {
        public int Id { get; set; }
        protected string _endereco;
        protected string _nome;
        protected string _cpf;
        protected DateTime _dataNascimento;
        protected EstadoCivil _estadoCivil;

        public Pessoa()
        {

        }

        public Pessoa(int id, string endereco, string nome, string cpf, DateTime dataNascimento, EstadoCivil estadoCivil)
        {
            Id = id;
            _endereco = endereco;
            _nome = nome;
            _cpf = cpf;
            _dataNascimento = dataNascimento;
            _estadoCivil = estadoCivil;
        }

        public virtual string GetEnderecoPessoa() { return _endereco; }
        public virtual string GetNomePessoa() { return _nome; }
        public virtual string GetCpfPessoa() { return _cpf; }
        public virtual DateTime GetDataNascimentoPessoa() { return _dataNascimento; }
        public virtual EstadoCivil GetEstadoCivilPessoa() { return _estadoCivil; }

        public virtual void SetEnderecoPessoa(string endereco) { _endereco = endereco; }
        public virtual void SetNomePessoa(string nome) { _nome = nome; }
        public virtual void SetCpfPessoa(string cpf) { _cpf = cpf; }
        public virtual void SetDataNascimentoPessoa(DateTime dataNascimento) { _dataNascimento = dataNascimento; }
        public virtual void SetEstadoCivilPessoa(EstadoCivil estadoCivil) { _estadoCivil = estadoCivil; }

    }
}
