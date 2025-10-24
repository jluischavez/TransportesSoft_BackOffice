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
    public class Repo_ConfSucursalLocal
    {
        private string ConnectionString;
        ConfSucursalLocal lConfSucursalLocal;

        public Repo_ConfSucursalLocal()
        {
            lConfSucursalLocal = new ConfSucursalLocal();
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }


        public ConfSucursalLocal ObtenerConfiguracionSucursalLocal()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ConfSucursalLocal";
                lConfSucursalLocal = db.QueryFirstOrDefault<ConfSucursalLocal>(sql);
                return lConfSucursalLocal;
            }
        }

        public bool GuardarConfiguracionSucursalLocal(ConfSucursalLocal conf)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = @"INSERT INTO ConfSucursalLocal (NombreSucursal, Direccion, URLImagen, Telefono, KilometrajeNotificaciones)
                            VALUES (@NombreSucursal, @Direccion, @URLImagen, @Telefono, @KilometrajeNotificaciones)";
                db.Execute(sql, conf);
                return true;
            }
        }

        public void ActualizarConfiguracionSucursalLocal(ConfSucursalLocal conf)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = @"UPDATE ConfSucursalLocal 
                            SET NombreSucursal = @NombreSucursal, 
                                Direccion = @Direccion, 
                                URLImagen = @URLImagen, 
                                Telefono = @Telefono,
                                KilometrajeNotificaciones = @KilometrajeNotificaciones";
                db.Execute(sql, conf);
            }
        }
    }
}
