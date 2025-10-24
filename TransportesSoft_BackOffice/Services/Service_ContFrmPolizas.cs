using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Repositories;
using TransportesSoft_BackOffice.Models;
using System.Data.SqlClient;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContFrmPolizas
    {
        private string ConnectionString;
        private Repo_ContTiposPolizas repo_ContTiposPolizas;
        private Repo_ContPolizasReg repo_ContPolizasReg;
        public Service_ContFrmPolizas()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            repo_ContTiposPolizas = new Repo_ContTiposPolizas(new System.Data.SqlClient.SqlConnection(ConnectionString));
            repo_ContPolizasReg = new Repo_ContPolizasReg(new System.Data.SqlClient.SqlConnection(ConnectionString));
        }

        public List<ContTiposPolizas> ObtenerContTiposPolizas()
        {
            return repo_ContTiposPolizas.ObtenerContTiposPolizas();
        }

        public int GuardarPoliza(ContPolizasReg nuevaPoliza)
        {
            //CREAME UNA CONEXION AQUI PARA EL BEGIN TRANSSACTION Y EL COMMIT
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        repo_ContPolizasReg = new Repo_ContPolizasReg(connection);
                        int idPoliza = repo_ContPolizasReg.GuardarPoliza(nuevaPoliza, transaction);
                        transaction.Commit();
                        return idPoliza;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw; // Re-lanza la excepción para que pueda ser manejada más arriba
                    }
                }
            }
        }

        public List<ContPolizasReg> ObtenerPolizas()
        {
            return repo_ContPolizasReg.ObtenerPolizas();
        }

    }
}
