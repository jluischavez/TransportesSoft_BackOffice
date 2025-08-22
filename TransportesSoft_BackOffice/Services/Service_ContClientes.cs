using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContClientes
    {

        List<ContClientes> lContClientes;
        Repo_ContClientes lRepoContClientes;
        public Service_ContClientes()
        {
            lRepoContClientes = new Repo_ContClientes();
        }

        public List<ContClientes> ObtenerClientes()
        {
            lContClientes = lRepoContClientes.ObtenerClientes();
            return lContClientes;
        }

    }
}
