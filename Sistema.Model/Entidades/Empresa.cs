using Sistema.Model.Interfaces.IDAO;

namespace Sistema.Model.Entidades
{
    public class Empresa : IEntidade
    {
        public int Id { get; set; }
        private string _nome;
        private string _cnpj;
        private string _setor;
        private string _email;
        private string _telefone;
        private string _endereco;

        public Empresa() { }

        public Empresa(int id, string nome, string cnpj, string setor, string email, string telefone, string endereco)
        {
            Id = id;
            _nome = nome;
            _cnpj = cnpj;
            _setor = setor;
            _email = email;
            _telefone = telefone;
            _endereco = endereco;
        }
        public string GetNomeEmpresa() { return _nome; }
        public string GetCnpjEmpresa() { return _cnpj; }
        public string GetSetorEmpresa() { return _setor; }
        public string GetEmailEmpresa() { return _email; }
        public string GetTelefoneEmpresa() { return _telefone; }
        public string GetEnderecoEmpresa() { return _endereco; }

        public void SetNomeEmpresa(string nome) { _nome = nome; }
        public void SetCnpjEmpresa(string cnpj) { _cnpj = cnpj; }
        public void SetSetorEmpresa(string setor) { _setor = setor; }
        public void SetEmailEmpresa(string email) { _email = email; }
        public void SetTelefoneEmpresa(string telefone) { _telefone = telefone; }
        public void SetEnderecoEmpresa(string endereco) { _endereco = endereco; }
    }
}
