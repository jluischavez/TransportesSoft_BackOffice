using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContOperadores
    {
        List<ContOperadores> lContOperadores;
        Repo_ContOperadores lRepoContOperadores;

        public Service_ContOperadores()
        {
            lContOperadores = new List<ContOperadores>();
            lRepoContOperadores = new Repo_ContOperadores();
        }

        public List<ContOperadores> ObtenerOperadores()
        {
            lContOperadores = lRepoContOperadores.ObtenerOperadores();

            return lContOperadores;
        }
        public List<ContOperadores> ObtenerOperadoresActivos()
        {
            return lRepoContOperadores.ObtenerOperadoresActivos();
        }

        public ContOperadores OperadorPorID(int idOperador)
        {
            return lRepoContOperadores.OperadorPorID(idOperador);
        }
        public void GuardarOperador(ContOperadores operador)
        {
            lRepoContOperadores.GuadarUnidad(operador);
        }

        public void ActualizarOperador(ContOperadores operador)
        {
            lRepoContOperadores.ActualizarOperador(operador);
        }

        public void EliminarOperador(int id_Operador)
        {
            lRepoContOperadores.EliminarOperador(id_Operador);
        }
        public bool ValidarOperador(string lNombre)
        {
            if (String.IsNullOrEmpty(lNombre))
                return false;

            return true;
        }
    }
}
