using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_GastosPorUnidad
    {
        List<C_ObtenerGastosUnidades> lListGastosUnidades;
        private string ConnectionString;
        public Repo_GastosPorUnidad()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public List<C_ObtenerGastosUnidades> ObtenerGastosPorUnidad(DateTime FechaIni, DateTime FechaFin, int idUnidad = 0)
        {
            lListGastosUnidades = new List<C_ObtenerGastosUnidades>();
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.sp_C_ObtenerGastosUnidades";
                var parametros = new
                {
                    FechaIni = FechaIni,
                    FechaFin = FechaFin,
                    IdUnidad = idUnidad
                };
                lListGastosUnidades = db.Query<C_ObtenerGastosUnidades>(sql, parametros, commandType: CommandType.StoredProcedure).ToList();
                return lListGastosUnidades;
            }
        }
    }
}
