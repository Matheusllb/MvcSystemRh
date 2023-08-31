namespace Sistema.Model.Entidades
{
    public class BDFuncionario
    {
        private int _idBD;
        private int _idFuncionario;
        private int _idBeneficioDesconto;

        public BDFuncionario(int id, int funcionario, int idBeneficioDesconto)
        {
            _idBD = id;
            _idFuncionario = funcionario;
            _idBeneficioDesconto = idBeneficioDesconto;
        }

        public int GetIdBD() { return _idBD; }
        public int GetIdBDFuncionario() { return _idFuncionario; }
        public int GetIdBDBeneficioDesconto() { return _idBeneficioDesconto; }
    }
}
