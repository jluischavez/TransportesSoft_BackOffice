using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Models;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContMantenimientosDet
    {
        Repo_ContMantenimientosDet lRepoMantenimientosDet = new Repo_ContMantenimientosDet();
        public Service_ContMantenimientosDet()
        {
        }

        public List<ContMantenimientosDet> ObtenerMantenimientoDetPorId(int IdMantenimiento)
        {
            return lRepoMantenimientosDet.ObtenerMantenimientoPorId(IdMantenimiento);
        }

        public void GuardarMantenimientoDet(ContMantenimientosDet lmantenimiento)
        {
            lRepoMantenimientosDet.GuadarMantenimientoDet(lmantenimiento);
        }

        public void EliminarMantenimientoDetPorId(int IdMantenimiento)
        {
            lRepoMantenimientosDet.EliminarMantenimientoDetPorId(IdMantenimiento);
        }
    }
}
