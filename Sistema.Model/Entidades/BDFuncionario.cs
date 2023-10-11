using Sistema.Model.Interfaces.IDAO;

namespace Sistema.Model.Entidades
{
    public class BDFuncionario : IEntidade
    {
        public int Id { get; set; }
        private int _idFuncionario;
        private int _idBeneficioDesconto;

        public BDFuncionario()
        {
        }

        public BDFuncionario(int funcionario, int idBeneficioDesconto)
        {

            _idFuncionario = funcionario;
            _idBeneficioDesconto = idBeneficioDesconto;
        } 

        public int GetIdBDFuncionario() { return _idFuncionario; }
        public int GetIdBDBeneficioDesconto() { return _idBeneficioDesconto; }
        public void SetIdBDFuncionario(int idFuncionario) { _idFuncionario = idFuncionario; }
        public void SetIdBDBeneficioDesconto(int idBeneficioDesconto) { _idBeneficioDesconto = idBeneficioDesconto; }
    }
}
