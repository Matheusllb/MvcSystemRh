using Sistema.Model.Interfaces.IDAO;

namespace Sistema.Model.Entidades
{
    public class BDFuncionario : IEntidade
    {
        public int Id { get; set; }
        private int IdFuncionario;
        private int IdBeneficioDesconto;

        public BDFuncionario()
        {
        }

        public BDFuncionario(int funcionario, int idBeneficioDesconto)
        {

            IdFuncionario = funcionario;
            IdBeneficioDesconto = idBeneficioDesconto;
        } 

        public int GetIdBDFuncionario() { return IdFuncionario; }
        public int GetIdBDBeneficioDesconto() { return IdBeneficioDesconto; }
        public void SetIdBDFuncionario(int idFuncionario) { IdFuncionario = idFuncionario; }
        public void SetIdBDBeneficioDesconto(int idBeneficioDesconto) { IdBeneficioDesconto = idBeneficioDesconto; }
    }
}
