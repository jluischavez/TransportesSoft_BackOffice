using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Repositories;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_EstadosCat
    {
        Repo_EstadosCat lRepoEstados;
        public Service_EstadosCat()
        {
            lRepoEstados = new Repo_EstadosCat();
        }
        public List<EstadosCat> ObtenerEstados()
        {
            return lRepoEstados.ObtenerEstados();
        }
    }
}
