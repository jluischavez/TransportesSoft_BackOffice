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

        /// <summary>
        /// Repositorio de ContUnidades
        /// </summary>
        public Repo_ContUnidades()
        {
            lContUnidades = new List<ContUnidades>();
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }
        
        /// <summary>
        /// Regresa todas las unidades con Estatus 'A'
        /// </summary>
        /// <returns></returns>
        public List<ContUnidades> ObtenerUnidades()
        {

            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContUnidades";
                lContUnidades = db.Query<ContUnidades>(sql).ToList();

                return lContUnidades;
            }
        }


        /// <summary>
        /// Genera un registro nuevo de unidad.
        /// </summary>
        /// <param name="unidad"></param>
        public void GuadarUnidad(ContUnidades unidad)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlInsert = "Insert into ContUnidades(Marca, Serie, Kilometraje, FechaActualizacion, id_Operador, ProximoMantenimiento, Estatus, id_Remolque) " +
                    "Values(@Marca, @Serie, @Kilometraje, @FechaActualizacion, @id_Operador, @ProximoMantenimiento, @Estatus, @id_Remolque)";
                var result = db.Execute(sqlInsert, new
                {
                    Marca = unidad.Marca,
                    Serie = unidad.Serie,
                    Kilometraje = unidad.Kilometraje,
                    FechaActualizacion = DateTime.Now,
                    id_Operador = unidad.id_Operador,
                    ProximoMantenimiento = unidad.ProximoMantenimiento,
                    Estatus = unidad.Estatus,
                    id_Remolque = unidad.id_Remolque
                });
            }
        }

        /// <summary>
        /// Actualiza los campos de una Unidad en base de datos.
        /// </summary>
        /// <param name="unidad"></param>
        public void ActualizarUnidad(ContUnidades unidad)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlEdit = "UPDATE ContUnidades set Marca=@Marca, Serie=@Serie, Kilometraje=@Kilometraje, FechaActualizacion=@FechaActualizacion, " +
                    "ProximoMantenimiento=@ProximoMantenimiento, id_Operador = @id_Operador, Estatus=@Estatus, id_Remolque=@id_Remolque " +
                    "WHERE id_Unidad=@id_Unidad";
                var result = db.Execute(sqlEdit, new
                {
                    Marca = unidad.Marca,
                    Serie = unidad.Serie,
                    Kilometraje = unidad.Kilometraje,
                    FechaActualizacion = DateTime.Now,
                    id_Operador = unidad.id_Operador,
                    ProximoMantenimiento = unidad.ProximoMantenimiento,
                    id_Unidad = unidad.id_Unidad,
                    Estatus = unidad.Estatus,
                    id_Remolque = unidad.id_Remolque
                });;
            }
        }


        /// <summary>
        /// EliminarUnidad no Elimina, solo actualiza status en base de datos.
        /// </summary>
        /// <param name="id_Unidad"></param>
        public void EliminarUnidad(int id_Unidad)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlEdit = "UPDATE ContUnidades set Estatus=@Estatus " +
                   "WHERE id_Unidad=@id_Unidad";
                var result = db.Execute(sqlEdit, new { id_Unidad = id_Unidad, Estatus='C' });
            }
        }

        public List<ContUnidades> ObtenerTodasUnidadesPorMantenimiento()
        {
            lContUnidades = new List<ContUnidades>();

            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContUnidades " +
                    "WHERE ESTATUS = 'A'" +
                    " ORDER BY (ProximoMantenimiento - Kilometraje) desc";
                lContUnidades = db.Query<ContUnidades>(sql).ToList();

                return lContUnidades;
            }
        }

        public List<ContUnidades> ObtenerTodasUnidadesPorMantenimientoYKilometraje(int KilometrajeLimite)
        {
            lContUnidades = new List<ContUnidades>();

            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContUnidades" +
                    " WHERE (ProximoMantenimiento - Kilometraje) <= @KilometrajeLimite AND Estatus = 'A'" +
                    " ORDER BY (ProximoMantenimiento - Kilometraje) desc";
                lContUnidades = db.Query<ContUnidades>(sql, new { KilometrajeLimite = KilometrajeLimite }).ToList();

                return lContUnidades;
            }
        }
    }
}

                
       
