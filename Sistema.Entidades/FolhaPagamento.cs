using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sistema.Entidades
{
    public class FolhaPagamento
    {
        private int _id;
        private Empresa _empresa;
        private DateTime _dataFechamento;
        private DateTime _dataPagamento;
        private decimal _totalVencimentos;
        private decimal _totalDescontos;
        private decimal _totalLiquido;
        private Funcionario _funcionario;
        private decimal _salarioINSS;
        private decimal _valorFGTS;
        private decimal _valorIRRF;
        private BeneficioDesconto _itens;
        //private decimal _horaExtra;
        

        public FolhaPagamento(int id, Empresa empresa, DateTime pagamento,
         decimal salarioBruto, /*decimal horaExtra,*/ BeneficioDesconto itens)
        {
            _id = id;
            _empresa = empresa;
            _dataFechamento = DateTime.Now;
            _dataPagamento = pagamento;
            _funcionario.SetSalarioBrutoFuncionario(salarioBruto);
            _itens = itens;
            _salarioINSS = CalculaINSS();
            _valorFGTS = CalculaFGTS();
            _valorIRRF = CalculaIRRF();
            _totalVencimentos = CalculaTotalVencimentos();
            _totalDescontos = CalculaTotalDescontos();
            _totalLiquido = CalculaTotalLiquido();
            //_horaExtra = horaExtra;

        }

        public int GetIdEmFolha() { return _id; }
        public Empresa GetEmpresaEmFolha() { return _empresa; }
        public DateTime GetDataFechamentoEmFolha() { return _dataFechamento; }
        public DateTime GetDataPagamentoEmFolha() { return _dataPagamento; }
        public decimal GetTotalVencimentosEmFolha() { return _totalVencimentos; }
        public decimal GetTotalDescontosEmFolha() { return _totalDescontos; }
        public decimal GetTotalLiquidoEmFolha() { return _totalLiquido; }
        public Funcionario GetFuncionarioEmFolha() { return _funcionario; }
        public decimal GetSalarioINSSEmFolha() { return _salarioINSS; }
        public decimal GetValorFGTSEmFolha() { return _valorFGTS; }
        public decimal GetValorIRRFEmFolha() { return _valorIRRF; }
        public BeneficioDesconto GetItensEmFolha() { return _itens; }

        public void SetIdEmFolha(int id) { _id = id; }
        public void SetEmpresaEmFolha(Empresa empresa) { _empresa = empresa; }
        public void SetDataFechamentoEmFolha(DateTime dataFechamento) { _dataFechamento = dataFechamento; }
        public void SetDataPagamentoEmFolha(DateTime dataPagamento) { _dataPagamento = dataPagamento; }
        public void SetTotalVencimentosEmFolha(decimal totalVencimentos) { _totalVencimentos = totalVencimentos; }
        public void SetTotalDescontosEmFolha(decimal totalDescontos) { _totalDescontos = totalDescontos; }
        public void SetTotalLiquidoEmFolha(decimal totalLiquido) { _totalLiquido = totalLiquido; }
        public void SetFuncionarioEmFolha(Funcionario funcionario) { _funcionario = funcionario; }
        public void SetSalarioINSSEmFolha(decimal salarioINSS) { _salarioINSS = salarioINSS; }
        public void SetFValorFGTSEmFolha(decimal valorFGTS) { _valorFGTS = valorFGTS; }
        public void SetValorIRRFEmFolha(decimal valorIRRF) { _valorIRRF = valorIRRF; }
        public void SetItensEmFolha(BeneficioDesconto itens) { _itens = itens; }

        public decimal CalculaFGTS()
        {
            return _valorFGTS = _funcionario.GetSalarioBrutoFuncionario() * (decimal)0.08;
        }
        public decimal CalculaINSS()
        {
            if(_funcionario.GetSalarioBrutoFuncionario() <= 1320)
            {
                return _salarioINSS = _funcionario.GetSalarioBrutoFuncionario() * (decimal)0.075;
            }
            else if(_funcionario.GetSalarioBrutoFuncionario() >= 1321 || _funcionario.GetSalarioBrutoFuncionario() <= (decimal)2571.29)
            {
                return _salarioINSS = _funcionario.GetSalarioBrutoFuncionario() * (decimal)0.09;
            }
            else if(_funcionario.GetSalarioBrutoFuncionario() >= (decimal)2571.30 || _funcionario.GetSalarioBrutoFuncionario() <= (decimal)3856.94)
            {
                return _salarioINSS = _funcionario.GetSalarioBrutoFuncionario() * (decimal)0.12;
            }
            else if(_funcionario.GetSalarioBrutoFuncionario() > (decimal)3856.95)
            {
                return _salarioINSS = _funcionario.GetSalarioBrutoFuncionario() * (decimal)0.14; 
            }
            return _salarioINSS;
        }
        public decimal CalculaIRRF()
        {
            decimal baseDeCalculoIRRF = _funcionario.GetSalarioBrutoFuncionario() - _salarioINSS;
            if (baseDeCalculoIRRF >= (decimal)1903.99 || baseDeCalculoIRRF <= (decimal)2826.65)
            {
                return _valorIRRF = baseDeCalculoIRRF * (decimal)0.075;
            }
            else if(baseDeCalculoIRRF >= (decimal)2826.66 || baseDeCalculoIRRF <= (decimal)3751.05)
            {
                return _valorIRRF = baseDeCalculoIRRF * (decimal)0.15;
            }
            else if(baseDeCalculoIRRF >= (decimal)3751.06 || baseDeCalculoIRRF <= (decimal)4664.68)
            {
                return _valorIRRF = baseDeCalculoIRRF * (decimal)0.225;
            }
            else if(baseDeCalculoIRRF > (decimal)4664.68)
            {
                return _valorIRRF = baseDeCalculoIRRF * (decimal)0.275;
            }
            return _valorIRRF;
        }

        public decimal CalculaTotalVencimentos()
        {
            return _totalVencimentos = _funcionario.GetSalarioBrutoFuncionario() + _itens.GetBeneficioTotal() /*+ _horaExtra*/;

        }
        public decimal CalculaTotalDescontos()
        {
            return _totalDescontos = _salarioINSS + _valorIRRF + _itens.GetDescontoTotal();
        }
        public decimal CalculaTotalLiquido()
        {
            return _totalLiquido = _totalVencimentos - _totalDescontos;
        }
    }
}
