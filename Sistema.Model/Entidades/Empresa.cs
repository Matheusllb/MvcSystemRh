using Sistema.Model.Interfaces.IDAO;

namespace Sistema.Model.Entidades
{
    public class Empresa : IEntidade
    {
        public int Id { get; set; }
        private string Nome;
        private string Cnpj;
        private string Setor;
        private string Email;
        private string Telefone;
        private string Endereco;

        public Empresa() { }

        public Empresa(string nome, string cnpj, string setor, string email, string telefone, string endereco)
        {
            Nome = nome;
            Cnpj = cnpj;
            Setor = setor;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }
        public string GetNomeEmpresa() { return Nome; }
        public string GetCnpjEmpresa() { return Cnpj; }
        public string GetSetorEmpresa() { return Setor; }
        public string GetEmailEmpresa() { return Email; }
        public string GetTelefoneEmpresa() { return Telefone; }
        public string GetEnderecoEmpresa() { return Endereco; }

        public void SetNomeEmpresa(string nome) { Nome = nome; }
        public void SetCnpjEmpresa(string cnpj) { Cnpj = cnpj; }
        public void SetSetorEmpresa(string setor) { Setor = setor; }
        public void SetEmailEmpresa(string email) { Email = email; }
        public void SetTelefoneEmpresa(string telefone) { Telefone = telefone; }
        public void SetEnderecoEmpresa(string endereco) { Endereco = endereco; }
    }
}
