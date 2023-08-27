namespace Sistema.Model.Entidades
{
    public class BDFuncionario
    {
        private int _idBD;
        private int _idBeneficioDesconto;
        private int _idFuncionario;

        public BDFuncionario(int id, int idBeneficioDesconto, int funcionario)
        {
            _id = id;
            _idBeneficioDesconto = idBeneficioDesconto;
            _idFuncionario = funcionario;
        }

        public int GetIdBD() { return _id; }
        public int GetIdBenDesc() { return _idBeneficioDesconto; }
        public int GetIdBDFuncionario() { return _idFuncionario; }
    }
}
