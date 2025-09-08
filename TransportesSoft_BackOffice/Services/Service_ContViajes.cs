using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{

    public class Service_ContViajes
    {
        List<ContViajes> lListContViajes;
        List<ContViajesYOperador> lListContViajesYOperador;
        Repo_ContViajes RepoContViajes;

        public Service_ContViajes()
        {
            RepoContViajes = new Repo_ContViajes();
        }
        public List<ContViajes> ObtenerTodosLosViajes()
        {
            return RepoContViajes.ObtenerTodosLosViajes();
        }
        public List<ContViajesYOperador> ObtenerViajesPorFecha(DateTime FechaInicial, DateTime FechaFinal)
        {
            lListContViajesYOperador = new List<ContViajesYOperador>();
            lListContViajesYOperador = RepoContViajes.ObtenerViajesPorFecha(FechaInicial, FechaFinal);
            return lListContViajesYOperador;
        }
        public void ActualizarViaje(ContViajes objViaje)
        {
            RepoContViajes.ActualizarViaje(objViaje);
        }
        public void EliminarViaje(int id_Viaje)
        {
            RepoContViajes.EliminarViaje(id_Viaje);
        }
        public List<ContViajesYOperador> ObtenerViajesPorFechaPorCliente(DateTime FechaInicial, DateTime FechaFinal, int id_Client)
        {
            lListContViajesYOperador = new List<ContViajesYOperador>();
            lListContViajesYOperador = RepoContViajes.ObtenerViajesPorFechaPorCliente(FechaInicial, FechaFinal, id_Client);
            return lListContViajesYOperador;
        }
        public bool ValidarFolioFactura(string FolioFactura)
        {
            return RepoContViajes.ValidarFolioFactura(FolioFactura);
        }
        public bool ValidarNumeroTransporte(int NumeroTransporte)
        {
            return RepoContViajes.ValidarNumeroTransporte(NumeroTransporte);
        }
        public void GuardarViaje(ContViajes objViaje)
        {
            RepoContViajes.GuardarViaje(objViaje);
        }
    }
}
