using Sistema.Model.Interfaces.IDAO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sistema.Model.Entidades
{
    public class BeneficioDesconto : IEntidade, INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _descricao;
        private bool _desconto;
        private decimal _valor;
        private bool _ativo;

        public event PropertyChangedEventHandler PropertyChanged;

        public BeneficioDesconto() { }
        public BeneficioDesconto(string descricao, bool desconto, decimal valor)
        {
            _descricao = descricao;
            _desconto = desconto;
            _valor = valor;
            _ativo = true;
        }

        public string Descricao
        {
            get => _descricao;
            set
            {
                if (_descricao != value)
                {
                    _descricao = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool Desconto
        {
            get => _desconto;
            set
            {
                if (_desconto != value)
                {
                    _desconto = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal Valor
        {
            get => _valor;
            set
            {
                if (_valor != value)
                {
                    _valor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool Ativo
        {
            get => _ativo;
            set
            {
                if (_ativo != value)
                {
                    _ativo = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

}


