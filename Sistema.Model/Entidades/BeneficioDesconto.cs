using Sistema.Model.Interfaces.IDAO;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.Model.Entidades
{
    public class BeneficioDesconto : IEntidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Desconto { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }

        public BeneficioDesconto()
        {

        }

        public BeneficioDesconto(string descricao, bool desconto, decimal valor)
        {
            Descricao = descricao;
            Desconto = desconto;
            Valor = valor;
            Ativo = true;
        }

        public string GetDescricaoBeneficioDesconto() { return Descricao; }
        public bool GetDescontoBeneficioDesconto() { return Desconto; }
        public bool GetAtivoBeneficioDesconto() { return Ativo; }
        public decimal GetValorBeneficioDesconto() { return Valor; }

        public void SetDescricaoBeneficioDesconto(string descricao) { Descricao = descricao; }
        public void SetDescontoBeneficioDesconto(bool desconto) { Desconto = desconto; }
        public void SetAtivoBeneficioDesconto(bool ativo) { Ativo = ativo; }
        public void SetValorBeneficioDesconto(decimal valor) { Valor = valor; }

    }
}


