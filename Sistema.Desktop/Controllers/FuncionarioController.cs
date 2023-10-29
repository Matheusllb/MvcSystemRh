using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Desktop.Controllers
{
    public class FuncionarioController : Controller<Funcionario>
    {
        public FuncionarioController(FuncionarioDAO dao) : base(dao)
        {
            Model = dao;
        }

    }
}
