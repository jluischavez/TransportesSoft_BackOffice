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
    public class Repo_ContOperadores
    {


        private string ConnectionString;
        private List<ContOperadores> lContOperadores;

        public Repo_ContOperadores()
        {
            lContOperadores = new List<ContOperadores>();
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }


        public List<ContOperadores> ObtenerOperadores()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContOperadores";
                lContOperadores = db.Query<ContOperadores>(sql).ToList();

                return lContOperadores;
            }
        }

        /// <summary>
        /// Genera un registro nuevo de operador.
        /// </summary>
        /// <param name="operador"></param>
        public void GuadarUnidad(ContOperadores operador)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlInsert = "INSERT INTO ContOperadores(Nombre, FechaIngreso, FechaEgreso, Estatus) " +
                    "Values(@Nombre, @FechaIngreso, @FechaEgreso, @Estatus)";
                var result = db.Execute(sqlInsert, new
                {
                    Nombre = operador.Nombre,
                    FechaIngreso = operador.FechaIngreso,
                    FechaEgreso = operador.FechaEgreso,
                    Estatus = operador.Estatus
                });
            }
        }


        /// <summary>
        /// Actualiza los campos de un operador en base de datos.
        /// </summary>
        /// <param name="operador"></param>
        public void ActualizarOperador(ContOperadores operador)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlEdit = "UPDATE ContOperadores set Nombre=@Nombre, FechaIngreso=@FechaIngreso, FechaEgreso=@FechaEgreso, Estatus=@Estatus " +
                    "WHERE id_Operador=@id_Operador";
                var result = db.Execute(sqlEdit, new
                {
                    Nombre = operador.Nombre,
                    FechaIngreso = operador.FechaIngreso,
                    FechaEgreso = operador.FechaEgreso,
                    Estatus = operador.Estatus,
                    id_Operador = operador.id_Operador
                }); ;
            }
        }

        /// <summary>
        /// EliminarOperador no Elimina, solo actualiza status en base de datos.
        /// </summary>
        /// <param name="id_Operador"></param>
        public void EliminarOperador(int id_Operador)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlEdit = "UPDATE ContOperadores set Estatus=@Estatus " +
                   "WHERE id_Operador=@id_Operador";
                var result = db.Execute(sqlEdit, new { id_Operador = id_Operador, Estatus = 'C' });
            }
        }
    }
}
