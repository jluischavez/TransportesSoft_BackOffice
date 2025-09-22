using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Repositories;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContKilometrajeUnidad
    {
        private Repo_ContKilometrajeUnidad lRepoContKilometrajeUnidad;

        public Service_ContKilometrajeUnidad()
        {

            lRepoContKilometrajeUnidad = new Repo_ContKilometrajeUnidad();
        }

        public void GuardarKilometrajeUnidad(ContKilometrajeUnidad objKilometraje)
        {
            lRepoContKilometrajeUnidad.GuardarKilometrajeUnidad(objKilometraje);
        }

        public int ObtenerKilometrajeActualPorUnidad(int id_Unidad)
        {
            return lRepoContKilometrajeUnidad.ObtenerKilometrajeActualPorUnidad(id_Unidad);
        }

        public List<ProximoMantenimientoUnidades> ObtenerProximosMantenimientos()
        {
            return lRepoContKilometrajeUnidad.ObtenerProximosMantenimientos();
        }

        public List<ProximoMantenimientoUnidades> ObtenerProximosMantenimientosPorKilometraje(int Kilometraje)
        {
            return lRepoContKilometrajeUnidad.ObtenerProximoMantenimientoPorKilometraje(Kilometraje);
        }
    }
}
