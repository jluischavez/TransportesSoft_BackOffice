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
    public class Repo_ContConsumoUnidades
    {
        private string ConnectionString;
        private List<ContConsumoUnidades> lContConsumoUnidades;

        public Repo_ContConsumoUnidades()
        {
            lContConsumoUnidades = new List<ContConsumoUnidades>();
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public List<ContConsumoUnidades> ObtenerContConsumoUnidades()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContConsumoUnidades";
                lContConsumoUnidades = db.Query<ContConsumoUnidades>(sql).ToList();

                return lContConsumoUnidades;
            }
        }

        public List<ContConsumoUnidades> ObtenerContConsumoUnidadesPorFecha(DateTime FechaInicial, DateTime FechaFinal)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContConsumoUnidades WHERE Fecha Between @FechaInicial AND @FechaFinal";
                var parametros = new
                {
                    FechaInicial = FechaInicial,
                    FechaFinal = FechaFinal
                };
                lContConsumoUnidades = db.Query<ContConsumoUnidades>(sql, parametros).ToList();

                return lContConsumoUnidades;
            }
        }
        public List<ContConsumoUnidades> ObtenerContConsumoUnidadPorFecha(DateTime FechaInicial, DateTime FechaFinal, int idUnidad)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContConsumoUnidades WHERE id_Unidad=@id_Unidad AND Fecha Between @FechaInicial AND @FechaFinal";
                var parametros = new
                {
                    FechaInicial = FechaInicial,
                    FechaFinal = FechaFinal,
                    id_Unidad = idUnidad
                };
                lContConsumoUnidades = db.Query<ContConsumoUnidades>(sql, parametros).ToList();

                return lContConsumoUnidades;
            }
        }

        public void GuardarConsumoUnidades(ContConsumoUnidades consumounidad)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlInsert = "Insert into ContConsumoUnidades(id_Unidad, Fecha, ConsumoLitros, Comentarios, ConsumoPesos) " +
                    "Values(@id_Unidad, @Fecha, @ConsumoLitros, @Comentarios, @ConsumoPesos)";
                var result = db.Execute(sqlInsert, new
                {
                    id_Unidad = consumounidad.id_Unidad,
                    Fecha = consumounidad.Fecha,
                    ConsumoLitros = consumounidad.ConsumoLitros,
                    Comentarios = consumounidad.Comentarios,
                    ConsumoPesos = consumounidad.ConsumoPesos
                });
            }
        }


    }
}
