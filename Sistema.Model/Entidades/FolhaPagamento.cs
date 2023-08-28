using System;
using System.Collection.Generics;

namespace Sistema.Model.Entidades
{
    public class FolhaPagamento
    {
        private int _id;
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
        private List<string> _itens = new List<string> { };
        

        public FolhaPagamento(int id, int empresa, DateTime pagamento,
         Funcionario funcionario)
        {
            _id = id;
            _empresa = empresa;
            _dataFechamento = DateTime.Now;
            _dataPagamento = pagamento;
            _funcionario = funcionario;
            _salarioINSS = CalculaINSS();
            _valorFGTS = CalculaFGTS();
            _valorIRRF = CalculaIRRF();
            _totalVencimentos = CalculaTotalVencimentos();
            _totalDescontos = CalculaTotalDescontos();
            _totalLiquido = CalculaTotalLiquido();
        }

        public int GetIdEmFolha() { return _id; }
        public int GetIdEmpresaEmFolha() { return _idEmpresa; }
        public DateTime GetDataFechamentoEmFolha() { return _dataFechamento; }
        public DateTime GetDataPagamentoEmFolha() { return _dataPagamento; }
        public decimal GetTotalVencimentosEmFolha() { return _totalVencimentos; }
        public decimal GetTotalDescontosEmFolha() { return _totalDescontos; }
        public decimal GetTotalLiquidoEmFolha() { return _totalLiquido; }
        public int GetIdFuncionarioEmFolha() { return _funcionario.GetIdPessoa(); }
        public decimal GetSalarioINSSEmFolha() { return _salarioINSS; }
        public decimal GetValorFGTSEmFolha() { return _valorFGTS; }
        public decimal GetValorIRRFEmFolha() { return _valorIRRF; }
        public List<string> GetItensEmFolha() { return _itens; }

        public void SetIdEmFolha(int id) { _id = id; }
        public void SetIdEmpresaEmFolha(int idEmpresa) { _idEmpresa = idEmpresa; }
        public void SetDataFechamentoEmFolha(DateTime dataFechamento) { _dataFechamento = dataFechamento; }
        public void SetDataPagamentoEmFolha(DateTime dataPagamento) { _dataPagamento = dataPagamento; }
        public void SetTotalVencimentosEmFolha(decimal totalVencimentos) { _totalVencimentos = totalVencimentos; }
        public void SetTotalDescontosEmFolha(decimal totalDescontos) { _totalDescontos = totalDescontos; }
        public void SetTotalLiquidoEmFolha(decimal totalLiquido) { _totalLiquido = totalLiquido; }
        public void SetIdFuncionarioEmFolha(int funcionario) { _funcionario = funcionario; }
        public void SetSalarioINSSEmFolha(decimal salarioINSS) { _salarioINSS = salarioINSS; }
        public void SetFValorFGTSEmFolha(decimal valorFGTS) { _valorFGTS = valorFGTS; }
        public void SetValorIRRFEmFolha(decimal valorIRRF) { _valorIRRF = valorIRRF; }
        public void SetItensEmFolha(List<string> itens) { _itens = itens; }

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

        public decimal CalculaTotalBenefico(decimal[] beneficios)
        {
            //Recebe valor da classe FolhaDAO (banco de dados)
        }
        public decimal CalculaTotalDesconto(decimal[] descontos)
        {
            //Recebe valor da classe FolhaDAO (banco de dados)
        }

        public decimal CalculaTotalVencimentos()
        {
            return _totalVencimentos = _funcionario.GetSalarioBrutoFuncionario() + CalculaTotalBenefico();

        }
        public decimal CalculaTotalDescontos()
        {
            return _totalDescontos = _salarioINSS + _valorIRRF + CalculaTotalDesconto();
        }
        public decimal CalculaTotalLiquido()
        {
            return _totalLiquido = _totalVencimentos - _totalDescontos;
        }
    }
}
