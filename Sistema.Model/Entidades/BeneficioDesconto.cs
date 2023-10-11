using Sistema.Model.Interfaces.IDAO;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.Model.Entidades
{
    public class BeneficioDesconto : IEntidade
    {
        public int Id { get; set; }
        private string _descricao;
        private bool _desconto;
        private bool _ativo;
        private decimal _valor;

        public BeneficioDesconto()
        {

        }

        public BeneficioDesconto(string descricao, bool desconto, decimal valor)
        {
            _descricao = descricao;
            _desconto = desconto;
            _ativo = true;
            _valor = valor;
        }

        public string GetDescricaoBeneficioDesconto() { return _descricao; }
        public bool GetDescontoBeneficioDesconto() { return _desconto; }
        public bool GetAtivoBeneficioDesconto() { return _ativo; }
        public decimal GetValorBeneficioDesconto() { return _valor; }

        public void SetDescricaoBeneficioDesconto(string descricao) { _descricao = descricao; }
        public void SetDescontoBeneficioDesconto(bool desconto) { _desconto = desconto; }
        public void SetAtivoBeneficioDesconto(bool ativo) { _ativo = ativo; }
        public void SetValorBeneficioDesconto(decimal valor) { _valor = valor; }

    }
}


