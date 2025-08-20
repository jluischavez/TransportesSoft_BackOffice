using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContUnidades
    {
        List<ContUnidades> lContUnidades;
        Repo_ContUnidades lRepo;

        public Service_ContUnidades()
        {
            lRepo = new Repo_ContUnidades();
        }


        public List<ContUnidades> ObtenerUnidades() 
        {
            lContUnidades = new List<ContUnidades>();

            lContUnidades = lRepo.ObtenerUnidades();

            return lContUnidades;
        }
        public void GuardarUnidad(ContUnidades unidad)
        {
            lRepo.GuadarUnidad(unidad);
        }
        public void ActualizarUnidad(ContUnidades unidad)
        {
            lRepo.ActualizarUnidad(unidad);
        }
    }
}
