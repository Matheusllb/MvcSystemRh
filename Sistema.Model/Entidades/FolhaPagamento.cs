using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;

namespace Sistema.Model.Entidades
{
    public class FolhaPagamento : IEntidade
    {
        public int Id { get; set; }
        private int IdEmpresa;
        private DateTime DataFechamento;
        private DateTime DataPagamento;
        private decimal TotalVencimentos;
        private decimal TotalDescontos;
        private decimal TotalLiquido;
        private Funcionario Funcionario;
        private decimal SalarioINSS;
        private decimal ValorFGTS;
        private decimal ValorIRRF;
        private List<string> Itens = new List<string>();
        

        public FolhaPagamento(int empresa, DateTime dataFechamento, DateTime pagamento,
         Funcionario funcionario)
        {
            IdEmpresa = empresa;
            DataFechamento = dataFechamento;
            DataPagamento = pagamento;
            Funcionario = funcionario;
            SalarioINSS = CalculaINSS();
            ValorFGTS = CalculaFGTS();
            ValorIRRF = CalculaIRRF();
            TotalVencimentos = CalculaTotalVencimentos();
            TotalDescontos = CalculaTotalDescontos();
            TotalLiquido = CalculaTotalLiquido();
        }
        public FolhaPagamento()
        {
        }

        public int GetIdEmpresaEmFolha() { return IdEmpresa; }
        public DateTime GetDataFechamentoEmFolha() { return DataFechamento; }
        public DateTime GetDataPagamentoEmFolha() { return DataPagamento; }
        public decimal GetTotalVencimentosEmFolha() { return TotalVencimentos; }
        public decimal GetTotalDescontosEmFolha() { return TotalDescontos; }
        public decimal GetTotalLiquidoEmFolha() { return TotalLiquido; }
        public Funcionario GetFuncionarioEmFolha() { return Funcionario; }
        public decimal GetSalarioINSSEmFolha() { return SalarioINSS; }
        public decimal GetValorFGTSEmFolha() { return ValorFGTS; }
        public decimal GetValorIRRFEmFolha() { return ValorIRRF; }
        public List<string> GetItensEmFolha() { return Itens; }

        public void SetIdEmpresaEmFolha(int idEmpresa) { IdEmpresa = idEmpresa; }
        public void SetDataFechamentoEmFolha(DateTime dataFechamento) { DataFechamento = dataFechamento; }
        public void SetDataPagamentoEmFolha(DateTime dataPagamento) { DataPagamento = dataPagamento; }
        public void SetTotalVencimentosEmFolha(decimal totalVencimentos) { TotalVencimentos = totalVencimentos; }
        public void SetTotalDescontosEmFolha(decimal totalDescontos) { TotalDescontos = totalDescontos; }
        public void SetTotalLiquidoEmFolha(decimal totalLiquido) { TotalLiquido = totalLiquido; }
        public void SetFuncionarioEmFolha(Funcionario funcionario) { Funcionario = funcionario; }
        public void SetSalarioINSSEmFolha(decimal salarioINSS) { SalarioINSS = salarioINSS; }
        public void SetFValorFGTSEmFolha(decimal valorFGTS) { ValorFGTS = valorFGTS; }
        public void SetValorIRRFEmFolha(decimal valorIRRF) { ValorIRRF = valorIRRF; }
        public void SetItensEmFolha(List<string> itens) { Itens = itens; }

        public decimal CalculaFGTS()
        {
            return ValorFGTS = Funcionario.GetSalarioBrutoFuncionario() * (decimal)0.08;
        }
        public decimal CalculaINSS()
        {
            if(Funcionario.GetSalarioBrutoFuncionario() <= 1320)
            {
                return SalarioINSS = Funcionario.GetSalarioBrutoFuncionario() * (decimal)0.075;
            }
            else if(Funcionario.GetSalarioBrutoFuncionario() >= 1321 || Funcionario.GetSalarioBrutoFuncionario() <= (decimal)2571.29)
            {
                return SalarioINSS = Funcionario.GetSalarioBrutoFuncionario() * (decimal)0.09;
            }
            else if(Funcionario.GetSalarioBrutoFuncionario() >= (decimal)2571.30 || Funcionario.GetSalarioBrutoFuncionario() <= (decimal)3856.94)
            {
                return SalarioINSS = Funcionario.GetSalarioBrutoFuncionario() * (decimal)0.12;
            }
            else if(Funcionario.GetSalarioBrutoFuncionario() > (decimal)3856.95)
            {
                return SalarioINSS = Funcionario.GetSalarioBrutoFuncionario() * (decimal)0.14; 
            }
            return SalarioINSS;
        }
        public decimal CalculaIRRF()
        {
            decimal baseDeCalculoIRRF = Funcionario.GetSalarioBrutoFuncionario() - SalarioINSS;
            if (baseDeCalculoIRRF >= (decimal)1903.99 || baseDeCalculoIRRF <= (decimal)2826.65)
            {
                return ValorIRRF = baseDeCalculoIRRF * (decimal)0.075;
            }
            else if(baseDeCalculoIRRF >= (decimal)2826.66 || baseDeCalculoIRRF <= (decimal)3751.05)
            {
                return ValorIRRF = baseDeCalculoIRRF * (decimal)0.15;
            }
            else if(baseDeCalculoIRRF >= (decimal)3751.06 || baseDeCalculoIRRF <= (decimal)4664.68)
            {
                return ValorIRRF = baseDeCalculoIRRF * (decimal)0.225;
            }
            else if(baseDeCalculoIRRF > (decimal)4664.68)
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
            return TotalVencimentos = Funcionario.GetSalarioBrutoFuncionario(); //+ CalculaTotalBenefico();

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
