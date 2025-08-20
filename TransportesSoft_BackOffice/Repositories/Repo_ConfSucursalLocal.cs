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
    public class Repo_ConfSucursalLocal
    {
        private string ConnectionString;
        ConfSucursalLocal lConfSucursalLocal;

        public Repo_ConfSucursalLocal()
        {
            lConfSucursalLocal = new ConfSucursalLocal();
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }


        public ConfSucursalLocal ObtenerConfiguracionSucursalLocal()
        {

            using (var db = new SqlConnection(ConnectionString))
            {

                var sql = "SELECT * FROM ConfSucursalLocal";

                lConfSucursalLocal = db.QueryFirst<ConfSucursalLocal>(sql);

                return lConfSucursalLocal;
            }


        }
    }
}
