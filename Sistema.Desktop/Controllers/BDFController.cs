using Sistema.Model.Entidades;
using Sistema.Model.Interfaces.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sistema.Desktop.Controllers
{
    public class BDFController
    {
        BDFuncionarioDAO Model;

        public BDFController(BDFuncionarioDAO dao)
        {
            Model = dao;
        }

        public List<BeneficioDesconto> BuscaBD(int id)
        {
            try
            {
                List<BeneficioDesconto> resultado = Model.BuscaBeneficiosDescontos(id);

                if (resultado != null)
                {

                    return resultado;
                }
                else
                {
                    throw new Exception("Sem resultado");
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message);
                return null;
            }
        }
    }
}
