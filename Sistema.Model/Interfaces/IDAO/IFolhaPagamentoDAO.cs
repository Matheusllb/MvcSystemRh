using Sistema.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model.Interfaces.IDAO
{
    public interface IFolhaPagamentoDAO : IDAO<FolhaPagamento>
    {
        List<FolhaPagamento> ProcuraFolhaPorDataFechamento(DateTime fechamento);
        List<FolhaPagamento> ProcuraFolhaPorDataPagamento(DateTime pagamento);
    }
}
