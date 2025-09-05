using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_Municipios
    {
        List<Municipios> lMunicipios;
        Repo_Municipios lRepoMunicipios;
        public Service_Municipios()
        {
            lRepoMunicipios = new Repo_Municipios();
        }

        public List<Municipios> ObtenerMunicipios()
        {
            return lRepoMunicipios.ObtenerMunicipios();
        }
    }
}
