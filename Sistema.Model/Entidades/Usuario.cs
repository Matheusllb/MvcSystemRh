using System;
using System.Collections.Generic;
using Sistema.Model.Entidades.Enum;

namespace Sistema.Model.Entidades
{
    public class Usuario : Pessoa
    {
        private int IdUsuario;
        private int IdPermissao;
        private bool Ativo;
        private string Login;
        private string Senha;
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Empresa> _empresas = new List<Empresa>();
        private List<Funcionario> _funcionarios = new List<Funcionario>();
        private List<FolhaPagamento> _folhas = new List<FolhaPagamento>();

        public Usuario() : base() { }

        public Usuario(string endereco, string nome, string cpf, DateTime dataNascimento, EstadoCivil estadoCivil, int idUsuario, int idPermissao, bool status, 
            string login, string senha) : base(endereco, nome, cpf, dataNascimento, estadoCivil)
        {
            IdUsuario = idUsuario;
            IdPermissao = idPermissao;
            Ativo = status;
            Login = login;
            Senha = senha;
        }

        public override string GetEnderecoPessoa() { return Endereco; }
        public override string GetNomePessoa() { return Nome; }
        public override string GetCpfPessoa() { return Cpf; }
        public override DateTime GetDataNascimentoPessoa() { return DataNascimento; }
        public override EstadoCivil GetEstadoCivilPessoa() { return EstadoCivil; }
        public int GetIdUsuario() { return IdUsuario; }
        public bool GetStatusUsuario() { return Ativo; }
        public int GetIdPermissaoUsuario() { return IdPermissao; }
        public string GetLogin() { return Login;}
        public string GetSenha() { return Senha;}
        public List<Usuario> GetUsuariosUsuario() { return _usuarios; }
        public List<Empresa> GetEmpresasUsuario() { return _empresas; }
        public List<Funcionario> GetFuncionariosUsuario() { return _funcionarios; }
        public List<FolhaPagamento> GetFolhasDePagamentoUsuario() { return _folhas; }


        public override void SetEnderecoPessoa(string endereco) { Endereco = endereco; }
        public override void SetNomePessoa(string nome) { Nome = nome; }
        public override void SetCpfPessoa(string cpf) { Cpf = cpf; }
        public override void SetDataNascimentoPessoa(DateTime dataNascimento) { DataNascimento = dataNascimento; }
        public override void SetEstadoCivilPessoa(EstadoCivil estadoCivil) { EstadoCivil = estadoCivil; }
        public void SetIdUsuario(int idUsuario) { IdUsuario = idUsuario; }
        public void SetStatusUsuario(bool status) { Ativo = status; }
        public void SetIdPermissaoUsuario(int idPermissao) { IdPermissao = idPermissao; }
        public void SetLoginUsuario(string login) { Login = login; }
        public void SetSenhaUsuario(string senha) {  Senha = senha; }
        public void SetUsuariosUsuario(List<Usuario> usuarios) { _usuarios = usuarios; }
        public void SetEmpresaUsuario(List<Empresa> empresas) { _empresas = empresas; }
        public void SetFuncionariosUsuario(List<Funcionario> funcionarios) { _funcionarios = funcionarios; }
        public void SetFolhaPagamentoUsuario(List<FolhaPagamento> folhas) { _folhas = folhas; }
        

        //------------------------------------------------------Métodos para Usuário------------------------------------------------------
        /*public void CadastraUsuario()
        {   
            CadastroUsuario cadastro = new CadastroUsuario();
            Usuario novoUsuario = cadastro.TelaCadastro();
            Usuarios.Add(novoUsuario);
        }*/

        public void ProcuraUsuarioPorId(int id)
        {
            Usuario usuarioEncontrado = _usuarios.Find(u => u.GetIdUsuario() == id);
            if(usuarioEncontrado != null)
            {
                Console.WriteLine($"Usuário encontrado: {usuarioEncontrado}");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

        public void ProcuraUsuarioPorNome(string nome)
        {
            Usuario usuarioEncontrado = _usuarios.Find(u => u.Nome == nome);

            if (usuarioEncontrado != null)
            {
                Console.WriteLine($"Usuário encontrado: {usuarioEncontrado}");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

        public List<Usuario> ProcuraUsuariosPorParteDoNome(string parteNome)
        {
            List<Usuario> usuariosEncontrados = _usuarios.FindAll(u => u.Nome.Contains(parteNome));
            return usuariosEncontrados;
        }

        public List<Usuario> ProcuraUsuariosPorIdade(int idade)
        {
            DateTime dataAtual = DateTime.Today;
            List<Usuario> usuariosEncontrados = _usuarios.FindAll(u => CalculaIdade(u.DataNascimento, dataAtual) == idade);
            return usuariosEncontrados;
        }

        public int CalculaIdade(DateTime dataNascimento, DateTime dataAtual)
        {
            int idade = dataAtual.Year - dataNascimento.Year;
            if (dataNascimento > dataAtual.AddYears(-idade))
            {
                idade--;
            }
            else if (dataNascimento.Month == dataAtual.Month && dataNascimento.Day > dataAtual.Day)
            {
                idade--;
            }
            return idade;
        }

        public void RemoveUsuario(Usuario usuario)
        {
            _usuarios.Remove(usuario);
        }

        //-------------------------------------------------------Métodos para Empresas----------------------------------------------------

        /*public void CadastraEmpresa()
        {
            CadastroEmpresa cadastro = new CadastroEmpresa();
            Empresa novaEmpresa = cadastro.TelaCadastro();
            Empresas.Add(novaEmpresa);
        }*/

        public void ProcuraEmpresaPorId(int id)
        {
            Empresa empresaEncontrada = _empresas.Find(e => e.Id == id);
            if (empresaEncontrada != null)
            {
                Console.WriteLine($"Empresa encontrada: {empresaEncontrada}");
            }
            else
            {
                Console.WriteLine("Empresa não encontrada.");
            }
        }

        public List<Empresa> ProcuraEmpresaPorNome(string nome)
        {
            List<Empresa> empresasEncontradas = _empresas.FindAll(e => e.GetNomeEmpresa() == nome);
            if (empresasEncontradas != null)
            {
                return empresasEncontradas;
            }
            else
            {
                Console.WriteLine("Empresa não encontrada.");
            }
            return empresasEncontradas;
        }
        
        public List<Empresa> ProcuraEmpresaPorSetor(string setor)
        {
            List<Empresa> empresasEncontradas = _empresas.FindAll(e => e.GetSetorEmpresa() == setor);
            return empresasEncontradas;
        }

        public void RemoveEmrpesa(Empresa empresa)
        {
            _empresas.Remove(empresa);
        }

        //-----------------------------------------------------Métodos para Funcionário----------------------------------------------------

        /*public void CadastraFuncionario(Empresa empresa, Cargo cargo)
        {
            CadastroFuncionario cadastro = new CadastroFuncionario();
            Funcionario novoFuncionario = cadastro.TelaCadastro(empresa, cargo);
            Funcionarios.Add(novoFuncionario);
        }*/

        public void ProcuraFuncionarioPorId(int id)
        {
            Funcionario funcionarioEncontrado = _funcionarios.Find(f => f.GetIdFuncionario() == id);
            if (funcionarioEncontrado != null)
            {
                Console.WriteLine($"Funcionário encontrado: {funcionarioEncontrado}");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
        }

        public List<Funcionario> ProcuraFuncionarioPorNome(string nome)
        {
            List<Funcionario> funcionariosEncontrados = _funcionarios.FindAll(f => f.GetNomePessoa() == nome);
            if (funcionariosEncontrados != null)
            {
                return funcionariosEncontrados;
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
            return funcionariosEncontrados;
        }

        public List<Funcionario> ProcuraFuncionarioPorCargo(string cargo)
        {
            List<Funcionario> funcionariosEncontrados = _funcionarios.FindAll(f => f.GetCargoFuncionario() == cargo);
            if (funcionariosEncontrados != null)
            {
                return funcionariosEncontrados;
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
            return funcionariosEncontrados;
        }

        public List<Funcionario> ProcuraFuncionarioPorDataAdimissao(DateTime dataAdimissao)
        {
            List<Funcionario> funcionariosEncontrados = _funcionarios.FindAll(f => f.GetDataAdmissaoFuncionario() == dataAdimissao);
            if (funcionariosEncontrados != null)
            {
                return funcionariosEncontrados;
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
            return funcionariosEncontrados;
        }
        public List<Funcionario> ProcuraFuncionarioPorMesNascimento(int mesNascimento)
        {
            List<Funcionario> funcionariosEncontrados = _funcionarios.FindAll(f => f.GetDataNascimentoPessoa().Month == mesNascimento);
            if (funcionariosEncontrados != null)
            {
                return funcionariosEncontrados;
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
            return funcionariosEncontrados;
        }
        public List<Funcionario> ProcuraFuncionarioPorAnoNascimento(int anoNascimento)
        {
            List<Funcionario> funcionariosEncontrados = _funcionarios.FindAll(f => f.GetDataNascimentoPessoa().Year == anoNascimento);
            if (funcionariosEncontrados != null)
            {
                return funcionariosEncontrados;
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
            return funcionariosEncontrados;
        }
        public List<Funcionario> ProcuraFuncionarioPorDataNascimento(DateTime dataNascimento)
        {
            List<Funcionario> funcionariosEncontrados = _funcionarios.FindAll(f => f.GetDataNascimentoPessoa() == dataNascimento);
            if (funcionariosEncontrados != null)
            {
                return funcionariosEncontrados;
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
            return funcionariosEncontrados;
        }

     /*   public List<Funcionario> ProcuraFuncionarioPorEmpresa(string nomeEmpresa)
        {
            List<Funcionario> funcionariosEncontrados = _funcionarios.FindAll(f => f.GetEmpresaFuncionario().GetNomeEmpresa() == nomeEmpresa);
            if (funcionariosEncontrados != null)
            {
                return funcionariosEncontrados;
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
            return funcionariosEncontrados;
        }*/

        public List<Funcionario> ProcuraFuncionarioPorEmail(string email)
        {
            List<Funcionario> funcionariosEncontrados = _funcionarios.FindAll(f => f.GetEmailFuncionario() == email);
            if (funcionariosEncontrados != null)
            {
                return funcionariosEncontrados;
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
            return funcionariosEncontrados;
        }

        public List<Funcionario> ProcuraFuncionarioPorEstadoCivil(EstadoCivil estadoCivil)
        {
            List<Funcionario> funcionariosEncontrados = _funcionarios.FindAll(f => f.GetEstadoCivilPessoa() == estadoCivil);
            if (funcionariosEncontrados != null)
            {
                return funcionariosEncontrados;
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
            return funcionariosEncontrados;
        }

        public List<Funcionario> ProcuraFuncionarioPorSalario(decimal valor)
        {
            List<Funcionario> salariosEncontrados = _funcionarios.FindAll(f => f.GetSalarioBrutoFuncionario() == valor);
            if (salariosEncontrados != null)
            {
                return salariosEncontrados;
            }
            else
            {
                Console.WriteLine("Salário não encontrado.");
            }
            return salariosEncontrados;
        }

        public void RemoveFuncionario(Funcionario funcionario)
        {
            _funcionarios.Remove(funcionario);
        }

        //--------------------------------------------------Métodos para Folhas De Pagamento--------------------------------------------------

        /*public void CadastraFolhaPagamento(Empresa empresa, Salario salBruto, ItensFolha itens)
        {
            CadastroFolhaPagamento cadastro = new CadastroFolhaPagamento();
            FolhaPagamento novaFolhaP = cadastro.TelaCadastro(empresa, salBruto, itens);
            Folhas.Add(novaFolhaP);
        }*/

        /*public List<FolhaPagamento> ProcuraFolhaPorEmpresa(string nomeEmpresa)
        {
            List<FolhaPagamento> folhasEncontradas = _folhas.FindAll(f => f.GetEmpresaEmFolha().GetNomeEmpresa() == nomeEmpresa);
            if (folhasEncontradas != null)
            {
                return folhasEncontradas;
            }
            else
            {
                Console.WriteLine("Folha não encontrada.");
            }
            return folhasEncontradas;
        }*/

        public List<FolhaPagamento> ProcuraFolhaPorDataFechamento(DateTime fechamento)
        {
            List<FolhaPagamento> folhasEncontradas = _folhas.FindAll(f => f.GetDataFechamentoEmFolha() == fechamento);
            if (folhasEncontradas != null)
            {
                return folhasEncontradas;
            }
            else
            {
                Console.WriteLine("Folha não encontrada.");
            }
            return folhasEncontradas;
        }
        
        public List<FolhaPagamento> ProcuraFolhaPorDataPagamento(DateTime pagamento)
        {
            List<FolhaPagamento> folhasEncontradas = _folhas.FindAll(f => f.GetDataPagamentoEmFolha() == pagamento);
            if (folhasEncontradas != null)
            {
                return folhasEncontradas;
            }
            else
            {
                Console.WriteLine("Folha não encontrada.");
            }
            return folhasEncontradas;
        }

        public List<FolhaPagamento> ProcuraFolhaPorSalarioBruto(decimal valor)
        {
            List<FolhaPagamento> folhasEncontrados = _folhas.FindAll(f => f.GetFuncionarioEmFolha().GetSalarioBrutoFuncionario() == valor);
            if (folhasEncontrados != null)
            {
                return folhasEncontrados;
            }
            else
            {
                Console.WriteLine("Folha não encontrada.");
            }
            return folhasEncontrados;
        }
        public List<FolhaPagamento> ProcuraFolhaPorVencimentosEmFolha(decimal valor)
        {
            List<FolhaPagamento> folhasEncontrados = _folhas.FindAll(f => f.GetTotalVencimentosEmFolha() == valor);
            if (folhasEncontrados != null)
            {
                return folhasEncontrados;
            }
            else
            {
                Console.WriteLine("Folha não encontrada.");
            }
            return folhasEncontrados;
        }

        /*public List<FolhaPagamento> ProcuraFolhaPorBeneficioDesconto(BeneficioDesconto itens)
        {
            List<FolhaPagamento> folhasEncontrados = _folhas.FindAll(f => f.GetItensEmFolha() == itens);
            if (folhasEncontrados != null)
            {
                return folhasEncontrados;
            }
            else
            {
                Console.WriteLine("Folha não encontrada.");
            }
            return folhasEncontrados;
        }*/

    }

}
