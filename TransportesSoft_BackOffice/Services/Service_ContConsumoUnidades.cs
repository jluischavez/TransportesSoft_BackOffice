using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContConsumoUnidades
    {

        List<ContConsumoUnidades> lContConsumoUnidades;
        Repo_ContConsumoUnidades lRepoContConsumoUnidades;


        public Service_ContConsumoUnidades()
        {
            lContConsumoUnidades = new List<ContConsumoUnidades>();
            lRepoContConsumoUnidades = new Repo_ContConsumoUnidades();
        }

        public List<ContConsumoUnidades> ObtenerContConsumoUnidades()
        {
            lContConsumoUnidades = lRepoContConsumoUnidades.ObtenerContConsumoUnidades();

            return lContConsumoUnidades;
        }

        public List<ContConsumoUnidades> ObtenerContConsumoUnidadesPorFecha(DateTime FechaInicial, DateTime FechaFinal)
        {
            lContConsumoUnidades = lRepoContConsumoUnidades.ObtenerContConsumoUnidadesPorFecha(FechaInicial,FechaFinal);

            return lContConsumoUnidades;
        }

        public List<ContConsumoUnidades> ObtenerContConsumoUnidadPorFecha(DateTime FechaInicial, DateTime FechaFinal, int idUnidad)
        {
            lContConsumoUnidades = lRepoContConsumoUnidades.ObtenerContConsumoUnidadPorFecha(FechaInicial, FechaFinal, idUnidad);

            return lContConsumoUnidades;
        }

        public void GuardarConsumoUnidad(ContConsumoUnidades consumoUnidad)
        {
            lRepoContConsumoUnidades.GuardarConsumoUnidades(consumoUnidad);
        }



    }
}
