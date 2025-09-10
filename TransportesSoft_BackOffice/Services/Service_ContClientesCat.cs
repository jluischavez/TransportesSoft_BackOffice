using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContClientesCat
    {

        List<ContClientesCat> lContClientes;
        Repo_ContClientesCat lRepoContClientes;
        public Service_ContClientesCat()
        {
            lRepoContClientes = new Repo_ContClientesCat();
        }

        public List<ContClientesCat> ObtenerClientes()
        {
            lContClientes = lRepoContClientes.ObtenerClientes();
            return lContClientes;
        }

        public List<ContClientesCat> ObtenerClientesActivos()
        {
            return lRepoContClientes.ObtenerClientesActivos();
        }

        public void GuardarCliente(ContClientesCat lCliente)
        {
            lRepoContClientes.GuardarCliente(lCliente);
        }

        public void ActualizarCliente(ContClientesCat lCliente)
        {
            lRepoContClientes.ActualizarCliente(lCliente);
        }

        public void EliminarCliente(int id_Cliente)
        {
            lRepoContClientes.EliminarCliente(id_Cliente);
        }
        public bool ValidarInfoAntesDeGuardar(string Nombre)
        {
            if (string.IsNullOrEmpty(Nombre))
                return false;

            return true;
        }
    }
}
