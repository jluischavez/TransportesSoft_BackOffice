using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TransportesSoft_BackOffice.Clases;
using System.Data.SqlClient;
using Dapper;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_ContUnidades
    {
        private string ConnectionString;
        List<ContUnidades> lContUnidades;

        public Repo_ContUnidades()
        {
            lContUnidades = new List<ContUnidades>();
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }
        

        public List<ContUnidades> ObtenerUnidades()
        {

            using (var db = new SqlConnection(ConnectionString))
            {

                var sql = "SELECT * FROM ContUnidades";

                lContUnidades = db.Query<ContUnidades>(sql).ToList();

                return lContUnidades;
            }


        }

        public void GuadarUnidad(ContUnidades unidad)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlInsert = "Insert into ContUnidades(Marca, Serie, Kilometraje, FechaActualizacion, id_Operador, ProximoMantenimiento) " +
                    "Values(@Marca, @Serie, @Kilometraje, @FechaActualizacion, @id_Operador, @ProximoMantenimiento)";
                var result = db.Execute(sqlInsert, new
                {
                    Marca = unidad.Marca,
                    Serie = unidad.Serie,
                    Kilometraje = unidad.Kilometraje,
                    FechaActualizacion = DateTime.Now,
                    id_Operador = unidad.id_Operador,
                    ProximoMantenimiento = unidad.ProximoMantenimiento
                });
            }
        }


     }
}

                
       
