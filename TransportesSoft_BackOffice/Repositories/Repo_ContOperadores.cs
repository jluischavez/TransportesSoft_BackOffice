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
    }
}
