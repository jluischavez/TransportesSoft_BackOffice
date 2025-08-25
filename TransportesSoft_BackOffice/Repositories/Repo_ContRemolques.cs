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
    public class Repo_ContRemolques
    {

        private string ConnectionString;
        List<ContRemolques> lContRemolques;

        public Repo_ContRemolques()
        {
            lContRemolques = new List<ContRemolques>();
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public List<ContRemolques> ObtenerRemolques()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContRemolques";
                lContRemolques = db.Query<ContRemolques>(sql).ToList();
                return lContRemolques;
            }
        }
    }
}
