using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sistema.Model.Entidades
{
    public class FolhaPagamento : IEntidade, INotifyPropertyChanged
    {
        public int Id { get; set; }
        private int _idEmpresa;
        private DateTime _dataFechamento;
        private DateTime _dataPagamento;
        private decimal _totalVencimentos;
        private decimal _totalDescontos;
        private decimal _totalLiquido;
        private Funcionario _funcionario;
        private decimal _salarioINSS;
        private decimal _valorFGTS;
        private decimal _valorIRRF;
        private List<string> _itens = new List<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        public FolhaPagamento(int id,int idEmpresa, DateTime dataFechamento, DateTime dataPagamento, decimal totalVencimentos, decimal totalDescontos, decimal totalLiquido, Funcionario funcionario, decimal salarioINSS, decimal valorFGTS, List<string> itens)
        {
            Id = id;
            _idEmpresa = idEmpresa;
            _dataFechamento = dataFechamento;
            _dataPagamento = dataPagamento;
            _totalVencimentos = totalVencimentos;
            _totalDescontos = totalDescontos;
            _totalLiquido = totalLiquido;
            _funcionario = funcionario;
            _salarioINSS = salarioINSS;
            _valorFGTS = valorFGTS;
            _valorIRRF = (decimal)1000;
            _itens = itens;
        }

        public FolhaPagamento(int empresa, DateTime dataFechamento, DateTime pagamento,
         Funcionario funcionario)
        {
            _idEmpresa = empresa;
            _dataFechamento = dataFechamento;
            _dataPagamento = pagamento;
            _funcionario = funcionario;
            _salarioINSS = CalculaINSS();
            _valorFGTS = CalculaFGTS();
            _valorIRRF = CalculaIRRF();
            _totalVencimentos = CalculaTotalVencimentos();
            _totalDescontos = CalculaTotalDescontos();
            _totalLiquido = CalculaTotalLiquido();
        }

        public int IdEmpresa
        {
            get => _idEmpresa;
            set
            {
                if (_idEmpresa != value)
                {
                    _idEmpresa = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime DataFechamento
        {
            get => _dataFechamento;
            set
            {
                if (_dataFechamento != value)
                {
                    _dataFechamento = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime DataPagamento
        {
            get => _dataPagamento;
            set
            {
                if (_dataPagamento != value)
                {
                    _dataPagamento = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Funcionario Funcionario
        {
            get => _funcionario;
            set
            {
                if (_funcionario != value)
                {
                    _funcionario = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal SalarioINSS
        {
            get => _salarioINSS;
            set
            {
                if (_salarioINSS != value)
                {
                    _salarioINSS = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public decimal ValorFGTS
        {
            get => _valorFGTS;
            set
            {
                if (_valorFGTS != value)
                {
                    _valorFGTS = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public decimal ValorIRRF
        {
            get => _valorIRRF;
            set
            {
                if (_valorIRRF != value)
                {
                    _valorIRRF = value;
                    NotifyPropertyChanged();
                }
            }
        }

              
        public decimal TotalVencimentos
        {
            get => _totalVencimentos;
            set
            {
                if (_totalVencimentos != value)
                {
                    _totalVencimentos = value;
                    NotifyPropertyChanged();
                }
            }
        }
                     
        public decimal TotalDescontos
        {
            get => _totalDescontos;
            set
            {
                if (_totalDescontos != value)
                {
                    _totalDescontos = value;
                    NotifyPropertyChanged();
                }
            }
        }
                           
        public decimal TotalLiquido
        {
            get => _totalLiquido;
            set
            {
                if (_totalLiquido != value)
                {
                    _totalLiquido = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<string> Itens
        {
            get => _itens;
            set
            {
                if (_itens != value)
                {
                    _itens = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public decimal CalculaFGTS()
        {
            return ValorFGTS = Funcionario.SalarioBruto * (decimal)0.08;
        }

        public decimal CalculaINSS()
        {
            if (Funcionario.SalarioBruto <= (decimal)1320)
            {
                return SalarioINSS = Funcionario.SalarioBruto * (decimal)0.075;
            }
            else if (Funcionario.SalarioBruto >= 1321 || Funcionario.SalarioBruto <= (decimal)2571.29)
            {
                return SalarioINSS = Funcionario.SalarioBruto * (decimal)0.09;
            }
            else if (Funcionario.SalarioBruto >= (decimal)2571.30 || Funcionario.SalarioBruto <= (decimal)3856.94)
            {
                return SalarioINSS = Funcionario.SalarioBruto * (decimal)0.12;
            }
            else if (Funcionario.SalarioBruto > (decimal)3856.95)
            {
                return SalarioINSS = Funcionario.SalarioBruto * (decimal)0.14;
            }
            return SalarioINSS;
        }

        public decimal CalculaIRRF()
        {
            decimal baseDeCalculoIRRF = Funcionario.SalarioBruto - SalarioINSS;
            if (baseDeCalculoIRRF >= (decimal)1903.99 || baseDeCalculoIRRF <= (decimal)2826.65)
            {
                return ValorIRRF = baseDeCalculoIRRF * (decimal)0.075;
            }
            else if (baseDeCalculoIRRF >= (decimal)2826.66 || baseDeCalculoIRRF <= (decimal)3751.05)
            {
                return ValorIRRF = baseDeCalculoIRRF * (decimal)0.15;
            }
            else if (baseDeCalculoIRRF >= (decimal)3751.06 || baseDeCalculoIRRF <= (decimal)4664.68)
            {
                return ValorIRRF = baseDeCalculoIRRF * (decimal)0.225;
            }
            else if (baseDeCalculoIRRF > (decimal)4664.68)
            {
                return ValorIRRF = baseDeCalculoIRRF * (decimal)0.275;
            }
            return ValorIRRF;
        }

        /*public decimal CalculaTotalBenefico(decimal[] beneficios)
        {
            //Recebe valor da classe FolhaDAO (banco de dados)
        }
        public decimal CalculaTotalDesconto(decimal[] descontos)
        {
            //Recebe valor da classe FolhaDAO (banco de dados)
        }*/

        public decimal CalculaTotalVencimentos()
        {
            return TotalVencimentos = Funcionario.SalarioBruto; //+ CalculaTotalBenefico();

        }

        public decimal CalculaTotalDescontos()
        {
            return TotalDescontos = SalarioINSS + ValorIRRF; // + CalculaTotalDesconto();
        }

        public decimal CalculaTotalLiquido()
        {
            return TotalLiquido = TotalVencimentos - TotalDescontos;
        }
    }
}
