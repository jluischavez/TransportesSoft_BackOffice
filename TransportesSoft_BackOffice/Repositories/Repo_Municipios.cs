using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TransportesSoft_BackOffice.Clases;
using Dapper;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_Municipios
    {
        List<Municipios> lMunicipios;
        private string ConnectionString;
        public Repo_Municipios()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }
        public List<Municipios> ObtenerMunicipios()
        {
            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM Municipios";
                lMunicipios = db.Query<Municipios>(sql).ToList();
            }

                return lMunicipios;
        }
    }
}
