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
    public class Repo_ContUnidadesCat
    {
        private string ConnectionString;
        List<ContUnidadesCat> lContUnidades;

        /// <summary>
        /// Repositorio de ContUnidades
        /// </summary>
        public Repo_ContUnidadesCat()
        {
            lContUnidades = new List<ContUnidadesCat>();
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }
        
        /// <summary>
        /// Regresa todas las unidades con Estatus 'A'
        /// </summary>
        /// <returns></returns>
        public List<ContUnidadesCat> ObtenerUnidades()
        {

            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContUnidadesCat";
                lContUnidades = db.Query<ContUnidadesCat>(sql).ToList();

                return lContUnidades;
            }
        }

        public ContUnidadesCat UnidadPorIDOperador(int idOperador)
        {
            ContUnidadesCat lUnidad = new ContUnidadesCat();

            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM ContUnidadesCat " +
                    "WHERE id_Operador = @id_Operador";
                lUnidad = db.QueryFirst<ContUnidadesCat>(sql, new
                {
                    id_Operador = idOperador
                });
            }

            return lUnidad;
        }


        /// <summary>
        /// Genera un registro nuevo de unidad.
        /// </summary>
        /// <param name="unidad"></param>
        public void GuadarUnidad(ContUnidadesCat unidad)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlInsert = "Insert into ContUnidadesCat(Marca, Serie, Kilometraje, FechaActualizacion, id_Operador, ProximoMantenimiento, Estatus, id_Remolque) " +
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
        public void ActualizarUnidad(ContUnidadesCat unidad)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlEdit = "UPDATE ContUnidadesCat set Marca=@Marca, Serie=@Serie, Kilometraje=@Kilometraje, FechaActualizacion=@FechaActualizacion, " +
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
                var sqlEdit = "UPDATE ContUnidadesCat set Estatus=@Estatus " +
                   "WHERE id_Unidad=@id_Unidad";
                var result = db.Execute(sqlEdit, new { id_Unidad = id_Unidad, Estatus='C' });
            }
        }

        public List<ContUnidadesCat> ObtenerTodasUnidadesPorMantenimiento()
        {
            lContUnidades = new List<ContUnidadesCat>();

            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContUnidadesCat " +
                    "WHERE ESTATUS = 'A'" +
                    " ORDER BY (ProximoMantenimiento - Kilometraje) desc";
                lContUnidades = db.Query<ContUnidadesCat>(sql).ToList();

                return lContUnidades;
            }
        }

        public List<ContUnidadesCat> ObtenerTodasUnidadesPorMantenimientoYKilometraje(int KilometrajeLimite)
        {
            lContUnidades = new List<ContUnidadesCat>();

            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContUnidadesCat" +
                    " WHERE (ProximoMantenimiento - Kilometraje) <= @KilometrajeLimite AND Estatus = 'A'" +
                    " ORDER BY (ProximoMantenimiento - Kilometraje) desc";
                lContUnidades = db.Query<ContUnidadesCat>(sql, new { KilometrajeLimite = KilometrajeLimite }).ToList();

                return lContUnidades;
            }
        }
    }
}

                
       
