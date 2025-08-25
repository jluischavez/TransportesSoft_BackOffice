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
        Repo_ContUnidades lRepoContUnidades;

        public Service_ContUnidades()
        {
            lRepoContUnidades = new Repo_ContUnidades();
        }


        public List<ContUnidades> ObtenerUnidades() 
        {
            lContUnidades = new List<ContUnidades>();

            lContUnidades = lRepoContUnidades.ObtenerUnidades();

            return lContUnidades;
        }
        public void GuardarUnidad(ContUnidades unidad)
        {
            lRepoContUnidades.GuadarUnidad(unidad);
        }
        public void ActualizarUnidad(ContUnidades unidad)
        {
            lRepoContUnidades.ActualizarUnidad(unidad);
        }

        public void EliminarUnidad(int id_Unidad)
        {
            lRepoContUnidades.EliminarUnidad(id_Unidad);
        }

        public bool ValidarKilometraje(int kilometraje, int proximomantenimiento)
        {
            // Si ProximoMantenimiento es 0, se permite cualquier kilometraje
            if (proximomantenimiento == 0)
                return true;

            // Si no, el kilometraje debe ser mayor o igual
            return kilometraje >= proximomantenimiento;
        }
    }
}
