using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public Funcionario(int idFuncionario, bool status,string endereco, string nome, string cpf, DateTime dataNascimento, EstadoCivil estadoCivil,
            string email, DateTime dataAdimissao, int idEmpresa, string cargo, decimal salario) : base(endereco, nome, cpf, dataNascimento, estadoCivil)
        {
            _idFuncionario = idFuncionario;
            _ativo = status;
            _email = email;
            _dataAdmissao = dataAdimissao;
            _idEmpresa = idEmpresa;
            _cargo = cargo;
            _salarioBruto = salario;
        }

        public int IdFuncionario
        {
            get => _idFuncionario;
            set
            {
                if(_idFuncionario != value)
                {
                    _idFuncionario = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public bool Ativo
        {
            get => _ativo;
            set
            {
                if(_ativo != value)
                {
                    _ativo = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public string Email
        {
            get => _email;
            set
            {
                if(_email != value)
                {
                    _email = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public DateTime DataAdmissao
        {
            get => _dataAdmissao;
            set
            {
                if(_dataAdmissao != value)
                {
                    _dataAdmissao = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public int IdEmpresa
        {
            get => _idEmpresa;
            set
            {
                if(_idEmpresa != value)
                {
                    _idEmpresa = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public string Cargo
        {
            get => _cargo;
            set
            {
                if(_cargo != value)
                {
                    _cargo = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public decimal SalarioBruto
        {
            get => _salarioBruto;
            set
            {
                if(_salarioBruto != value)
                {
                    _salarioBruto = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
