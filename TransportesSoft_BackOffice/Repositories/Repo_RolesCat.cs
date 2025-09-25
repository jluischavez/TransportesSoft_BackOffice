using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_RolesCat
    {
        private string ConnectionString;
        public Repo_RolesCat()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public List<RolesCat> ObtenerRoles()
        {
            List<RolesCat> lListRolesCat = new List<RolesCat>();

            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM RolesCat";
                lListRolesCat = db.Query<RolesCat>(sql).ToList();
            }

            return lListRolesCat;
        }
    }
}
