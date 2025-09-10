using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_MunicipiosCat
    {
        List<MunicipiosCat> lMunicipios;
        Repo_MunicipiosCat lRepoMunicipios;
        public Service_MunicipiosCat()
        {
            lRepoMunicipios = new Repo_MunicipiosCat();
        }

        public List<MunicipiosCat> ObtenerMunicipios()
        {
            return lRepoMunicipios.ObtenerMunicipios();
        }
        public List<MunicipiosCatYEstado> ObtenerMunicipiosYEstado()
        {
            return lRepoMunicipios.ObtenerMunicipiosYEstado();
        }
        public void GuardarMunicipio(MunicipiosCat municipio)
        {
            lRepoMunicipios.GuadarMunicipio(municipio);
        }
        public void EliminarMunicipio(int IdMunicipio)
        {
            lRepoMunicipios.EliminarMunicipio(IdMunicipio);
        }
        public void ActualizarMunicipio(MunicipiosCat lMunicipio)
        {
            lRepoMunicipios.ActualizarMunicipio(lMunicipio);
        }
    }
}
