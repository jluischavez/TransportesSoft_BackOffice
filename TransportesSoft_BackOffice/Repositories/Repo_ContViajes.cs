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
        /*VALIDACIONES*/
        public bool ValidarFolioFactura(string folioFactura)
        {
            List<ContViajes> viajes = new List<ContViajes>();
            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContViajes " +
                    "WHERE Factura = @FolioFactura";
                viajes = db.Query<ContViajes>(sql, new {FolioFactura = folioFactura}).ToList();
            }
            if (viajes.Count == 0)
                return true;
            else
                return false;
        }
        public bool ValidarNumeroTransporte(int NumeroTransporte)
        {
            List<ContViajes> viajes = new List<ContViajes>();
            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContViajes " +
                    "WHERE NumeroTransporte = @NumeroTransporte";
                viajes = db.Query<ContViajes>(sql, new { NumeroTransporte = NumeroTransporte }).ToList();
            }
            if (viajes.Count == 0)
                return true;
            else
                return false;
        }
        /*END VALIDACIONES*/

        public void GuardarViaje(ContViajes objViaje)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlInsert = "INSERT INTO ContViajes(id_Client, NombreCliente, FechaViaje, FechaFactura, Factura, NumeroTransporte, Origen, Destino, Monto, IVA, Retenciones, Total, Comentarios, Maniobra, " +
                    "id_Operador, id_Unidad, id_Remolque) " +
                    "Values(@id_Client, @NombreCliente, @FechaViaje, @FechaFactura, @Factura, @NumeroTransporte, @Origen, @Destino, @Monto, @IVA, @Retenciones, @Total, @Comentarios, @Maniobra, " +
                    "@id_Operador, @id_Unidad, @id_Remolque)";
                var result = db.Execute(sqlInsert, new
                {
                    id_Client = objViaje.id_Client,
                    NombreCliente = objViaje.NombreCliente,
                    FechaViaje = objViaje.FechaViaje,
                    FechaFactura = objViaje.FechaFactura,
                    Factura = objViaje.Factura,
                    NumeroTransporte = objViaje.NumeroTansporte,
                    Origen = objViaje.Origen,
                    Destino = objViaje.Destino,
                    Monto = objViaje.Monto,
                    Maniobra = objViaje.Maniobra,
                    IVA = objViaje.IVA,
                    Retenciones = objViaje.Retenciones,
                    Total = objViaje.Total,
                    Comentarios = objViaje.Comentarios,
                    id_Operador = objViaje.id_Operador,
                    id_Unidad = objViaje.id_Unidad,
                    id_Remolque = objViaje.id_Remolque
                });
            }
        }
    }
}
