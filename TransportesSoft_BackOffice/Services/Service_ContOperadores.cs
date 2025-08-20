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
    }
}
