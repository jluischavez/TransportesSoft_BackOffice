using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContUnidadesCat
    {
        List<ContUnidadesCat> lContUnidades;
        Repo_ContUnidadesCat lRepoContUnidades;

        public Service_ContUnidadesCat()
        {
            lRepoContUnidades = new Repo_ContUnidadesCat();
        }


        public List<ContUnidadesCat> ObtenerUnidades() 
        {
            lContUnidades = new List<ContUnidadesCat>();

            lContUnidades = lRepoContUnidades.ObtenerUnidades();

            return lContUnidades;
        }
        public void GuardarUnidad(ContUnidadesCat unidad)
        {
            lRepoContUnidades.GuadarUnidad(unidad);
        }
        public void ActualizarUnidad(ContUnidadesCat unidad)
        {
            lRepoContUnidades.ActualizarUnidad(unidad);
        }
        public ContUnidadesCat UnidadPorID(int idOperador)
        {
            return lRepoContUnidades.UnidadPorIDOperador(idOperador);
        }
        public void EliminarUnidad(int id_Unidad)
        {
            lRepoContUnidades.EliminarUnidad(id_Unidad);
        }
        public List<ContUnidadesCat> ObtenerUnidadesPorMantenimiento()
        {
            return lRepoContUnidades.ObtenerTodasUnidadesPorMantenimiento();
        }
        public List<ContUnidadesCat> ObtenerUnidadesPorMantenimientoYKilometraje(int Kilometraje)
        {
            return lRepoContUnidades.ObtenerTodasUnidadesPorMantenimientoYKilometraje(Kilometraje);
        }
        #region "Validaciones"
        public bool ValidarKilometraje(int kilometraje, int proximomantenimiento)
        {
            // Si ProximoMantenimiento es 0, se permite cualquier kilometraje
            if (proximomantenimiento == 0)
                return true;

            if (kilometraje >= proximomantenimiento)
                return false;


            return true;
        }
        public bool ValidarDatosObligatoriosGuardado(string lMarca, string lSerie)
        {
            if (string.IsNullOrEmpty(lMarca) || string.IsNullOrEmpty(lSerie))
                return false;

            return true;
        }
        #endregion
    }
}
