using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Models;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_GastosPorUnidad
    {

        Repo_GastosPorUnidad rep_GastosPorUnidad = new Repo_GastosPorUnidad();
        public Service_GastosPorUnidad()
        {
        }

        public List<C_ObtenerGastosUnidades> ObtenerGastosPorUnidad(DateTime FechaIni, DateTime FechaFin, int id_Unidad = 0)
        {
            return rep_GastosPorUnidad.ObtenerGastosPorUnidad(FechaIni, FechaFin, id_Unidad);
        }
    }
}
