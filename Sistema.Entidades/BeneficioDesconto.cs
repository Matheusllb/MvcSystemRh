using System.Collections.Generic;
using System.Linq;

namespace Sistema.Entidades
{
    public class BeneficioDesconto
    {
        private int _id;
        private string _descricao;
        private bool _desconto;
        private decimal _valor;
        private decimal _descontoTotal;
        private decimal _beneficioTotal;
        private List<BeneficioDesconto> _listaBeneficio = new List<BeneficioDesconto> { };
        private List<BeneficioDesconto> _listaDesconto = new List<BeneficioDesconto> { };

        public BeneficioDesconto(int id, string descricao, bool desconto)
        {
            _id = id;
            _descricao = descricao;
            _desconto = desconto;
        }

        public BeneficioDesconto(int id, string descricao, bool desconto, decimal valor)
        {
            _id = id;
            _descricao = descricao;
            _desconto = desconto;
            _valor = valor;
        }

        public int GetIdBeneficioDesconto() { return _id; }
        public string GetDescricaoBeneficioDesconto() { return _descricao; }
        public bool GetDescontoBeneficioDesconto() { return _desconto; }
        public decimal GetValorBeneficioDesconto() { return _valor; }
        public decimal GetBeneficioTotal() { return _beneficioTotal; }
        public decimal GetDescontoTotal() { return _descontoTotal; }

        public void SetIdBeneficioDesconto(int id) { _id = id; }
        public void SetDescricaoBeneficioDesconto(string descricao) { _descricao = descricao; }
        public void SetDescontoBeneficioDesconto(bool desconto) { _desconto = desconto; }
        public void SetValorBeneficioDesconto(decimal valor) { _valor = valor; }
        public void SetBeneficioTotal(decimal beneficioTotal) { _beneficioTotal = beneficioTotal; }
        public void SetDescontoTotal(decimal descontoTotal) { _descontoTotal = descontoTotal; }

        public void AdicionarBeneficio(BeneficioDesconto ben) { _listaBeneficio.Add(ben); }
        public void AdicionaroDesconto(BeneficioDesconto des) { _listaDesconto.Add(des); }
        public void RemoverBeneficio(BeneficioDesconto ben) { _listaBeneficio.Remove(ben); }
        public void RemoverDesconto(BeneficioDesconto des) { _listaDesconto.Remove(des); }
        public int QuantidadeBeneficio() { return _listaBeneficio.Count(); }
        public int QuantidadeDesconto() { return _listaDesconto.Count(); }
        public void CalculaTotalBeneficio()
        {
            foreach (BeneficioDesconto item in _listaBeneficio)
            {
                if (item._valor != 0)
                {
                    _beneficioTotal += item._valor;
                }
            }
        }
        public void CalculaTotalDesconto()
        {
            foreach (BeneficioDesconto item in _listaDesconto)
            {
                if (item._valor != 0)
                {
                    _descontoTotal += item._valor;
                }
            }
        }

        /*public void CalculaTotal()
        {
            foreach(BeneficioDesconto item in ListaBenDes) 
            {
                if (item.Valor != 0)
                {
                    if(item.Desconto is true)
                    {
                        DescontoTotal += item.Valor;
                    }
                    else
                    {
                        BeneficioTotal += item.Valor;
                    }
                }
            }
        }*/

    }
}


