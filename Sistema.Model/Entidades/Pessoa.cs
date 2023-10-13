using System;
using Sistema.Model.Entidades.Enum;
using Sistema.Model.Interfaces.IDAO;

namespace Sistema.Model.Entidades
{
    abstract public class Pessoa : IEntidade
    {
        public int Id { get; set; }
        protected string Endereco;
        protected string Nome;
        protected string Cpf;
        protected DateTime DataNascimento;
        protected EstadoCivil EstadoCivil;

        public Pessoa()
        {

        }

        public Pessoa(string endereco, string nome, string cpf, DateTime dataNascimento, EstadoCivil estadoCivil)
        {
            Endereco = endereco;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            EstadoCivil = estadoCivil;
        }

        public virtual string GetEnderecoPessoa() { return Endereco; }
        public virtual string GetNomePessoa() { return Nome; }
        public virtual string GetCpfPessoa() { return Cpf; }
        public virtual DateTime GetDataNascimentoPessoa() { return DataNascimento; }
        public virtual EstadoCivil GetEstadoCivilPessoa() { return EstadoCivil; }

        public virtual void SetEnderecoPessoa(string endereco) { Endereco = endereco; }
        public virtual void SetNomePessoa(string nome) { Nome = nome; }
        public virtual void SetCpfPessoa(string cpf) { Cpf = cpf; }
        public virtual void SetDataNascimentoPessoa(DateTime dataNascimento) { DataNascimento = dataNascimento; }
        public virtual void SetEstadoCivilPessoa(EstadoCivil estadoCivil) { EstadoCivil = estadoCivil; }

    }
}
