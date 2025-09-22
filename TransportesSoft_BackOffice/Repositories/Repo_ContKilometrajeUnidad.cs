using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_ContKilometrajeUnidad
    {
        private string ConnectionString;

        public Repo_ContKilometrajeUnidad()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public void GuardarKilometrajeUnidad(ContKilometrajeUnidad objKilometraje)
        {
            using (SqlConnection context = new SqlConnection(ConnectionString))
            {
                string sql = "INSERT INTO ContKilometrajeUnidad " +
                    "VALUES (@id_Unidad, @FechaRegistro, @KilometrajeActual)";
                context.Execute(sql, objKilometraje);
            }
        }

        public int ObtenerKilometrajeActualPorUnidad(int id_Unidad)
        {
            using (SqlConnection context = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT TOP 1 KilometrajeActual FROM ContKilometrajeUnidad " +
                    "WHERE Id_Unidad = @id_Unidad ORDER BY Id DESC";
                var resultado = context.QueryFirstOrDefault<int?>(sql, new { id_Unidad });
                if (resultado.HasValue)
                {
                    // Aquí puedes manejar el kilometraje actual como necesites
                    return resultado.Value;
                }
                else
                {
                    return 0;
                }
            }
        }

        public List<ProximoMantenimientoUnidades> ObtenerProximosMantenimientos()
        {
            List<ProximoMantenimientoUnidades> lista = new List<ProximoMantenimientoUnidades>();

            using (SqlConnection context = new SqlConnection(ConnectionString))
            {
                lista = context.Query<ProximoMantenimientoUnidades>("dbo.sp_ObtenerProximosMantenimientos", commandType: CommandType.StoredProcedure).ToList();
            }
                return lista;
        }

        public List<ProximoMantenimientoUnidades> ObtenerProximoMantenimientoPorKilometraje(int Kilometraje)
        {
            List<ProximoMantenimientoUnidades> lista = new List<ProximoMantenimientoUnidades>();
            using (SqlConnection context = new SqlConnection(ConnectionString))
            {
                lista = context.Query<ProximoMantenimientoUnidades>("dbo.sp_ObtenerProximosMantenimientosKilometraje", new { Kilometraje }, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }

    }
}
