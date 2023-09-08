using System.Collections.Generic;
using System.Linq;

namespace Sistema.Model.Entidades
{
    public class BeneficioDesconto
    {
        private int _idBeneficioDesconto;
        private string _descricao;
        private bool _desconto;
        private bool _ativo;
        private decimal _valor;

        public BeneficioDesconto(int id, string descricao, bool desconto)
        {
            _idBeneficioDesconto = id;
            _descricao = descricao;
            _desconto = desconto;
        }

        public BeneficioDesconto(int id, string descricao, bool desconto, decimal valor)
        {
            _idBeneficioDesconto = id;
            _descricao = descricao;
            _desconto = desconto;
            _valor = valor;
        }

        public int GetIdBeneficioDesconto() { return _idBeneficioDesconto; }
        public string GetDescricaoBeneficioDesconto() { return _descricao; }
        public bool GetDescontoBeneficioDesconto() { return _desconto; }
        public decimal GetValorBeneficioDesconto() { return _valor; }

        public void SetIdBeneficioDesconto(int id) { _idBeneficioDesconto = id; }
        public void SetDescricaoBeneficioDesconto(string descricao) { _descricao = descricao; }
        public void SetDescontoBeneficioDesconto(bool desconto) { _desconto = desconto; }
        public void SetValorBeneficioDesconto(decimal valor) { _valor = valor; }

    }
}


