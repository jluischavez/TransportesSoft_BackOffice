using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_ContPolizasReg
    {
        SqlConnection SqlConnection;
        public Repo_ContPolizasReg(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        public int GuardarPoliza(ContPolizasReg nuevaPoliza, SqlTransaction transaction)
        {
            var sql = @"INSERT INTO ContPolizasReg (FolioPoliza, FechaRegistro, FechaExpira, idTipoPoliza, idUsuario) 
                        VALUES (@FolioPoliza, @FechaRegistro, @FechaExpira, @idTipoPoliza, @idUsuario);
                        SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = SqlConnection.Query<int>(sql, nuevaPoliza, transaction: transaction).Single();
            return id;
        }

        public List<ContPolizasReg> ObtenerPolizas()
        {
            var sql = "SELECT * FROM ContPolizasReg";
            var polizas = SqlConnection.Query<ContPolizasReg>(sql).ToList();
            return polizas;
        }
    }
}
