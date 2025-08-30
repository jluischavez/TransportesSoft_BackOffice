using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_ContViajes
    {
        private string ConnectionString;
        List<ContViajes> lListContViajes;
        List<ContViajesYOperador> lListContViajesYOperador;
        public Repo_ContViajes()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public List<ContViajesYOperador> ObtenerViajesPorFecha(DateTime FechaInicial, DateTime FechaFinal)
        {
            lListContViajesYOperador = new List<ContViajesYOperador>();
                using (var db = new SqlConnection(ConnectionString))
                {
                    var sql = "SELECT id_Viaje,id_Client,NombreCliente,FechaViaje,FechaFactura,Factura,NumeroTransporte," +
                    "Origen,Destino,Monto,IVA,Retenciones,Total,Comentarios,Maniobra,OP.id_Operador,OP.Nombre AS NombreOperador " +
                    "FROM ContViajes VI " +
                    "LEFT JOIN ContOperadores OP ON OP.id_Operador = VI.id_Operador" +
                    " WHERE FechaViaje Between @FechaInicial AND @FechaFinal";
                    var parametros = new
                    {
                        FechaInicial = FechaInicial,
                        FechaFinal = FechaFinal
                    };
                lListContViajesYOperador = db.Query<ContViajesYOperador>(sql, parametros).ToList();

                    return lListContViajesYOperador;
                }
        }
        public List<ContViajes> ObtenerViajes()
        {
            lListContViajes = new List<ContViajes>();
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContViajes";
                lListContViajes = db.Query<ContViajes>(sql).ToList();

                return lListContViajes;
            }
        }
        public List<ContViajesYOperador> ObtenerViajesPorFechaPorCliente(DateTime lFechaInicial, DateTime lFechaFinal, int lid_Client)
        {
            lListContViajesYOperador = new List<ContViajesYOperador>();
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT id_Viaje,id_Client,NombreCliente,FechaViaje,FechaFactura,Factura,NumeroTransporte," +
                    "Origen,Destino,Monto,IVA,Retenciones,Total,Comentarios,Maniobra,OP.id_Operador,OP.Nombre AS NombreOperador " +
                    "FROM ContViajes VI " +
                    "LEFT JOIN ContOperadores OP ON OP.id_Operador = VI.id_Operador" +
                    " WHERE FechaViaje Between @FechaInicial AND @FechaFinal AND id_Client = @id_Client";
                var parametros = new
                {
                    FechaInicial = lFechaInicial,
                    FechaFinal = lFechaFinal,
                    id_Client = lid_Client
                };
                lListContViajesYOperador = db.Query<ContViajesYOperador>(sql, parametros).ToList();

                return lListContViajesYOperador;
            }
        }
    }
}
