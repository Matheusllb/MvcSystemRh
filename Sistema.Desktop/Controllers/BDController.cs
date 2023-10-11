using Sistema.Model.DAO;
using Sistema.Model.Entidades;
using Sistema.Model.Interfaces.IDAO;
using System.Collections.Generic;

public class BDController : Controller<BeneficioDesconto>
{
    public BDController(BeneficioDescontoDAO model) : base(model)
    {
    }
    
}
