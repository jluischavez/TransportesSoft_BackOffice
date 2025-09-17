using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_ContMantenimientosDet
    {
        private string ConnectionString;
        public Repo_ContMantenimientosDet()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }
        public List<ContMantenimientosDet> ObtenerMantenimientoPorId(int IdMantenimiento)
        {
            List<ContMantenimientosDet> ListMantenimientoDet = new List<ContMantenimientosDet>();
            using (var context = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT IdMantenimiento, Refaccion, Proveedor, PrecioRefaccion, Comentarios, Renglon FROM ContMantenimientosDet WHERE IdMantenimiento = @IdMantenimiento";
                ListMantenimientoDet = context.Query<ContMantenimientosDet>(sql, new { IdMantenimiento = IdMantenimiento }).ToList();
            }
            return ListMantenimientoDet;
        }

        public void GuadarMantenimientoDet(ContMantenimientosDet lmantenimiento)
        {
            using (var context = new SqlConnection(ConnectionString))
            {
                string sql = "INSERT INTO ContMantenimientosDet (IdMantenimiento, Refaccion, Proveedor, PrecioRefaccion, Comentarios) " +
                             "VALUES (@IdMantenimiento, @Refaccion, @Proveedor, @PrecioRefaccion, @Comentarios)";
                context.Execute(sql, lmantenimiento);
            }
        }

        public void EliminarMantenimientoDetPorId(int IdMantenimiento)
        {
            using (var context = new SqlConnection(ConnectionString))
            {
                string sql = "DELETE FROM ContMantenimientosDet WHERE IdMantenimiento = @IdMantenimiento";
                context.Execute(sql, new { IdMantenimiento = IdMantenimiento });
            }
        }
    }
}
