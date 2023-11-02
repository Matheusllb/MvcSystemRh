using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sistema.Desktop.Controllers
{
    public class FuncionarioController : Controller<Funcionario>
    {
        public FuncionarioController(FuncionarioDAO dao) : base(dao)
        {
            Model = dao;
        }

        public bool Update(Funcionario data)
        {
            try
            {
                FuncionarioDAO dAO = new FuncionarioDAO();
                dAO.UpdatePessoais(data);
                GetAll();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return false;
            }
        }

    }
}
