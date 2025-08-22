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
    public class Repo_ContClientes
    {
        private string ConnectionString;
        List<ContClientes> lContClientes;
        public Repo_ContClientes()
        {
            lContClientes = new List<ContClientes>();
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public List<ContClientes> ObtenerClientes()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContClientes";
                lContClientes = db.Query<ContClientes>(sql).ToList();
                return lContClientes;
            }
        }
    }
}
