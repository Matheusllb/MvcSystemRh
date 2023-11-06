using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sistema.Model.Entidades.Enum;
using Sistema.Model.Interfaces.IDAO;

namespace Sistema.Model.Entidades
{
    abstract public class Pessoa
    {
        public int IdPessoa { get; set; }
        protected string _endereco;
        protected string _nome;
        protected string _cpf;
        protected DateTime _dataNascimento;
        protected EstadoCivil _estadoCivil;

        public event PropertyChangedEventHandler PropertyChanged;

        public Pessoa()
        {

        }

        public Pessoa(string endereco, string nome, string cpf, DateTime dataNascimento, EstadoCivil estadoCivil)
        {
            _endereco = endereco;
            _nome = nome;
            _cpf = cpf;
            _dataNascimento = dataNascimento;
            _estadoCivil = estadoCivil;
        }

        public string Endereco
        {
            get => _endereco;
            set
            {
                if(_endereco != value)
                {
                    _endereco = value;
                }
                NotifyPropertyChanged();
            }
        }
        
        public string Nome
        {
            get => _nome;
            set
            {
                if(_nome != value)
                {
                    _nome = value;
                }
                NotifyPropertyChanged();
            }
        }
        
        public string CPF
        {
            get => _cpf;
            set
            {
                if(_cpf != value)
                {
                    _cpf = value;
                }
                NotifyPropertyChanged();
            }
        }
        
        public DateTime DataNascimento
        {
            get => _dataNascimento;
            set
            {
                if(_dataNascimento != value)
                {
                    _dataNascimento = value;
                }
                NotifyPropertyChanged();
            }
        }
        
        public EstadoCivil EstadoCivilP
        {
            get => _estadoCivil;
            set
            {
                if(_estadoCivil != value)
                {
                    _estadoCivil = value;
                }
                NotifyPropertyChanged();
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
