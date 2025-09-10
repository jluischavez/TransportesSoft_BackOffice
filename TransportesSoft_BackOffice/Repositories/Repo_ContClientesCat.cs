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
    public class Repo_ContClientesCat
    {
        private string ConnectionString;
        List<ContClientesCat> lContClientes;
        public Repo_ContClientesCat()
        {
            lContClientes = new List<ContClientesCat>();
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public List<ContClientesCat> ObtenerClientes()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContClientesCat";
                lContClientes = db.Query<ContClientesCat>(sql).ToList();
                return lContClientes;
            }
        }
        public List<ContClientesCat> ObtenerClientesActivos()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContClientesCat " +
                    "WHERE Estatus = 'A'";
                lContClientes = db.Query<ContClientesCat>(sql).ToList();
                return lContClientes;
            }
        }

        public void GuardarCliente(ContClientesCat lCliente)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlInsert = "Insert into ContClientesCat(Nombre, Direccion, Telefono, Estatus) " +
                    "Values(@Nombre, @Direccion, @Telefono, @Estatus)";
                var result = db.Execute(sqlInsert, new
                {
                    Nombre = lCliente.Nombre,
                    Direccion = lCliente.Direccion,
                    Telefono = lCliente.Telefono,
                    Estatus = lCliente.Estatus
                });
            }
        }

        public void ActualizarCliente(ContClientesCat lCliente)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlEdit = "UPDATE ContClientesCat set Nombre=@Nombre, Direccion=@Direccion, Telefono=@Telefono, Estatus=@Estatus" +
                    " WHERE id_Client=@id_Client";
                var result = db.Execute(sqlEdit, new
                {
                    Nombre = lCliente.Nombre,
                    Direccion = lCliente.Direccion,
                    Telefono = lCliente.Telefono,
                    Estatus = lCliente.Estatus,
                    id_Client = lCliente.id_Client
                }); ;
            }
        }

        /// <summary>
        /// EliminarCliente no Elimina, solo actualiza estatus en base de datos.
        /// </summary>
        /// <param name="id_Unidad"></param>
        public void EliminarCliente(int id_Client)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlEdit = "UPDATE ContClientesCat set Estatus=@Estatus " +
                   "WHERE id_Client=@id_Client";
                var result = db.Execute(sqlEdit, new { id_Client = id_Client, Estatus = 'C' });
                //var sqlDelete = "DELETE FROM ContUnidades WHERE id_Unidad=@id_Unidad";
                //db.Execute(sqlDelete, new { id_Unidad = id_Unidad});
            }
        }
    }
}
