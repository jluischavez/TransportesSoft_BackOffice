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
                //var SqlInsert = "UPDATE contUnidades set MARCA = @MARCA WHERE id_Unidad = @id_Unidad";
                //var resultEdit = db.Execute(SqlInsert, new { MARCA = "VOLVO", id_Unidad = 5 });

                var sql = "SELECT * FROM ContUnidades";

                lContUnidades = db.Query<ContUnidades>(sql).ToList();

                return lContUnidades;
            }


        }


     }
}

                
       
