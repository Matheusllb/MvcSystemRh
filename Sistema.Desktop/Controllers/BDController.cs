using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Model.Entidades;

namespace Sistema.Desktop.Controllers
{
    public class BDController : Controller<BeneficioDesconto>
    {
        public BDController(BeneficioDescontoDAO dao) : base(dao)
        {
            Model = dao;
        }
    }
}
