using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_ContMantenimientosCab
    {
        private string ConnectionString;
        public Repo_ContMantenimientosCab()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }
        public ContMantenimientosCab ObtenerMantenimientoPorId(int IdMantenimiento)
        {
            ContMantenimientosCab objMantenimiento = new ContMantenimientosCab();

            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM ContMantenimientosCab WHERE IdMantenimiento = @IdMantenimiento";
                objMantenimiento = db.QueryFirst<ContMantenimientosCab>(sql, new { IdMantenimiento = IdMantenimiento } );
            }
            return objMantenimiento;
        }

        public int GuardarMantenimientoCab(ContMantenimientosCab lmantenimiento)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = @"INSERT INTO ContMantenimientosCab 
                       (FechaMantenimiento, Kilometraje, Proveedor, CostoTotal, id_Unidad, id_Remolque) 
                       VALUES (@FechaMantenimiento, @Kilometraje, @Proveedor, @CostoTotal, @id_Unidad, @id_Remolque);
                       SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int idGenerado = db.ExecuteScalar<int>(sql, lmantenimiento);
                return idGenerado;
            }
        }

        public void ActualizarMantenimientoCab(ContMantenimientosCab lmantenimiento)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = @"UPDATE ContMantenimientosCab SET 
                               FechaMantenimiento = @FechaMantenimiento, 
                               Kilometraje = @Kilometraje, 
                               Proveedor = @Proveedor, 
                               CostoTotal = @CostoTotal, 
                               id_Unidad = @id_Unidad, 
                               id_Remolque = @id_Remolque
                               WHERE IdMantenimiento = @IdMantenimiento";
                db.Execute(sql, lmantenimiento);
            }
        }

        public void EliminarMantenimientoCab(int IdMantenimiento)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "DELETE FROM ContMantenimientosCab WHERE IdMantenimiento = @IdMantenimiento";
                db.Execute(sql, new { IdMantenimiento = IdMantenimiento });
            }
        }
        public List<ContMantenimientosCab> ObtenerMantenimientosRemolques()
        {
            List<ContMantenimientosCab> objMantenimiento = new List<ContMantenimientosCab>();

            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM ContMantenimientosCab " +
                    "WHERE id_Remolque <> 0" +
                    "ORDER BY IdMantenimiento Desc";
                objMantenimiento = db.Query<ContMantenimientosCab>(sql).ToList();
            }
            return objMantenimiento;
        }

        public List<ContMantenimientosCab> ObtenerMantenimientosUnidades()
        {
            List<ContMantenimientosCab> objMantenimiento = new List<ContMantenimientosCab>();

            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM ContMantenimientosCab " +
                    "WHERE id_Unidad <> 0" +
                    "ORDER BY IdMantenimiento Desc";
                objMantenimiento = db.Query<ContMantenimientosCab>(sql).ToList();
            }
            return objMantenimiento;
        }

    }
}
