using Sistema.Model.Interfaces.IDAO;
using System.Collections.Generic;

namespace Sistema.Model.Entidades
{
    public class BDFuncionario : IEntidade
    {
        public int Id { get; set; }
        private int _idFuncionario;
        private int _idBeneficioDesconto;
        private List<BeneficioDesconto> _beneficioDesconto = new List<BeneficioDesconto> ();

        public BDFuncionario()
        {
        }

        public BDFuncionario(List<BeneficioDesconto> beneficioDescontos)
        {
            _beneficioDesconto = beneficioDescontos;
        } 

       public int IdF
        {
            get => _idFuncionario;
            set => _idFuncionario = value;
        }
       public int IdBD
        {
            get => _idBeneficioDesconto;
            set => _idBeneficioDesconto = value;
        }
       public List<BeneficioDesconto> BeneficioDesconto
        {
            get => _beneficioDesconto;
            set => _beneficioDesconto = value;
        }
    }
}
