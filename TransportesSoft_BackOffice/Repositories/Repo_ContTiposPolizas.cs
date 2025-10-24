using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_ContTiposPolizas
    {
        SqlConnection SqlConnection;

        public Repo_ContTiposPolizas(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        public List<ContTiposPolizas> ObtenerContTiposPolizas()
        {
            var sql = "SELECT * FROM ContTiposPolizas";
            var lContTiposPolizas = SqlConnection.Query<ContTiposPolizas>(sql).ToList();
            return lContTiposPolizas;
        }
    }
}
