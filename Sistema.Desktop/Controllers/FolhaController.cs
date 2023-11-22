using Sistema.Model.Entidades;
using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Desktop.Controllers
{
    public class FolhaController : Controller<FolhaPagamento>
    {
        public FolhaController(DAO<FolhaPagamento> model) : base(model)
        {
            Model = model;
        }
    }
}
