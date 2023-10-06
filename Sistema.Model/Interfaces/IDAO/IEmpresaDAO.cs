using Sistema.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model.Interfaces.IDAO
{
    public interface IEmpresaDAO : IDAO<Empresa>
    {
        List<Empresa> ProcuraEmpresaPorNome(string nome);
        List<Empresa> ProcuraEmpresaPorSetor(string setor);
    }
}
