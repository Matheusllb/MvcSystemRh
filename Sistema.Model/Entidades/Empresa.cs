using Sistema.Model.Interfaces.IDAO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sistema.Model.Entidades
{
    public class Empresa : IEntidade
    {
        public int Id { get; set; }
        private string _nome;
        private string _cnpj;
        private string _setor;
        private string _email;
        private string _telefone;
        private string _endereco;

        public event PropertyChangedEventHandler PropertyChanged;
        public Empresa() { }

        public Empresa(string nome, string cnpj, string setor, string email, string telefone, string endereco)
        {
            _nome = nome;
            _cnpj = cnpj;
            _setor = setor;
            _email = email;
            _telefone = telefone;
            _endereco = endereco;
        }

        public string Nome 
        {
            get => _nome;
            set
            {
                if (_nome != value)
                {
                    _nome = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Cnpj 
        {
            get => _cnpj;
            set
            {
                if (_cnpj != value)
                {
                    _cnpj = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Setor
        {
            get => _setor;
            set
            {
                if (_setor != value)
                {
                    _setor = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Telefone
        {
            get => _telefone;
            set
            {
                if (_telefone != value)
                {
                    _telefone = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Endereco
        {
            get => _endereco;
            set
            {
                if (_endereco != value)
                {
                    _endereco = value;
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
