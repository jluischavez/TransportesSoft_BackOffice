using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ConfSucursalLocal
    {
        ConfSucursalLocal lConfSucursalLocal;
        Repo_ConfSucursalLocal lRepoConfSucLocal;


        public Service_ConfSucursalLocal()
        {
            lConfSucursalLocal = new ConfSucursalLocal();
            lRepoConfSucLocal = new Repo_ConfSucursalLocal();
        }

        public ConfSucursalLocal ObtenerConfiguracionSucursalLocal()
        {
            lConfSucursalLocal = lRepoConfSucLocal.ObtenerConfiguracionSucursalLocal();

            return lConfSucursalLocal;
        }

        public bool GuardarConfiguracionSucursalLocal(ConfSucursalLocal pConfSucursalLocal)
        {
            lRepoConfSucLocal.GuardarConfiguracionSucursalLocal(pConfSucursalLocal);
            return true;
        }

        public bool ActualizarConfiguracionSucursalLocal(ConfSucursalLocal pConfSucursalLocal)
        {
            lRepoConfSucLocal.ActualizarConfiguracionSucursalLocal(pConfSucursalLocal);
            return true;
        }


    }
}
