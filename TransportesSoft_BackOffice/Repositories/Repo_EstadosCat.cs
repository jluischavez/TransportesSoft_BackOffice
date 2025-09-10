using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_EstadosCat
    {
        private string ConnectionString;
        private List<EstadosCat> lListEstados;

        public Repo_EstadosCat()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            lListEstados = new List<EstadosCat>();
        }

        /// <summary>
        /// Obtiene todos los estados.
        /// </summary>
        /// <returns></returns>
        public List<EstadosCat> ObtenerEstados()
        {
            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM EstadosCat";
                lListEstados = db.Query<EstadosCat>(sql).ToList();
            }

            return lListEstados;
        }
    }
}
