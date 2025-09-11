using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Models;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContPreciosDiesel
    {
        Repo_ContPreciosDiesel lRepoPreciosDiesel;
        public Service_ContPreciosDiesel() 
        { 
            lRepoPreciosDiesel = new Repo_ContPreciosDiesel();
        }

        public void GuardarPrecioDiesel(ContPreciosDiesel preciodiesel)
        {
            /*Actualiza ultimo registro para cerrarlo antes de guardar el nuevo*/
            lRepoPreciosDiesel.ActualizarUltimoPrecioDiesel();
            lRepoPreciosDiesel.GuadarPrecioDiesel(preciodiesel);
        }

        public ContPreciosDiesel PrecioActualDiesel()
        {
            return lRepoPreciosDiesel.PrecioActualDiesel();
        }
    }


}
