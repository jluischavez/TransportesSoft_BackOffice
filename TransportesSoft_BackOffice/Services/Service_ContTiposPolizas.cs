using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Models;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContTiposPolizas
    {
        private string ConnectionString;
        private Repo_ContTiposPolizas repo_ContTiposPolizas;

        public Service_ContTiposPolizas()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            repo_ContTiposPolizas = new Repo_ContTiposPolizas(new System.Data.SqlClient.SqlConnection(ConnectionString));
        }
        public List<ContTiposPolizas> ObtenerTiposPolizas()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                repo_ContTiposPolizas = new Repo_ContTiposPolizas(connection);
                return repo_ContTiposPolizas.ObtenerContTiposPolizas();
            }
        }
        public int GuardarTipoPoliza(ContTiposPolizas tipoPoliza)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        repo_ContTiposPolizas = new Repo_ContTiposPolizas(connection);
                        int idPoliza = repo_ContTiposPolizas.GuardarTipoPoliza(tipoPoliza, transaction);
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

        public bool ActualizarTipoPoliza(ContTiposPolizas tipoPoliza)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        repo_ContTiposPolizas = new Repo_ContTiposPolizas(connection);
                        bool resultado = repo_ContTiposPolizas.ActualizarTipoPoliza(tipoPoliza, transaction);
                        transaction.Commit();
                        return resultado;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw; // Re-lanza la excepción para que pueda ser manejada más arriba
                    }
                }
            }
        }

        public bool EliminarTipoPoliza(int idTipoPoliza)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        repo_ContTiposPolizas = new Repo_ContTiposPolizas(connection);
                        bool resultado = repo_ContTiposPolizas.EliminarTipoPoliza(idTipoPoliza, transaction);
                        transaction.Commit();
                        return resultado;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw; // Re-lanza la excepción para que pueda ser manejada más arriba
                    }
                }
            }
        }
    }
}
