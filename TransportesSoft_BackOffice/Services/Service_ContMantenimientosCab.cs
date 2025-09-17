using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Repositories;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContMantenimientosCab
    {
        Repo_ContMantenimientosCab lRepoContManteminentosCab = new Repo_ContMantenimientosCab();
        public Service_ContMantenimientosCab()
        {
        }

        public ContMantenimientosCab ObtenerMantenimientoPorId(int IdMantenimiento)
        {
            return lRepoContManteminentosCab.ObtenerMantenimientoPorId(IdMantenimiento);
        }

        public int GuardarMantenimientoCab(ContMantenimientosCab lmantenimiento)
        {
            return lRepoContManteminentosCab.GuardarMantenimientoCab(lmantenimiento);
        }
        public void ActualizarMantenimientoCab(ContMantenimientosCab lmantenimiento)
        {
            lRepoContManteminentosCab.ActualizarMantenimientoCab(lmantenimiento);
        }
        public void EliminarMantenimientoCab(int IdMantenimiento)
        {
            lRepoContManteminentosCab.EliminarMantenimientoCab(IdMantenimiento);
        }
        public List<ContMantenimientosCab> ObtenerMantenimientosRemolques()
        {
            return lRepoContManteminentosCab.ObtenerMantenimientosRemolques();
        }

        public List<ContMantenimientosCab> ObtenerMantenimientosUnidades()
        {
            return lRepoContManteminentosCab.ObtenerMantenimientosUnidades();
        }
    }
}
