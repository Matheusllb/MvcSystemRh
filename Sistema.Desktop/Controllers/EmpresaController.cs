using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using Sistema.Model.Interfaces.IController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Desktop.Controllers
{
    public class EmpresaController : Controller<Empresa>
    {
        public EmpresaController(EmpresaDAO dao) : base(dao)
        {
            Model = dao;
        }
    }
}
