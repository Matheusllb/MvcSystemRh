using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Model.Entidades;

namespace Sistema.Model.Interfaces.IDAO
{
    public interface IFuncionarioDAO : IDAO<Funcionario>
    {
        bool UpdatePessoais(Funcionario funcionario);
    }
}
