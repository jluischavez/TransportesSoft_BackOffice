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

        public int GuardarTipoPoliza(ContTiposPolizas tipoPoliza, SqlTransaction transaction)
        {
            var sql = "INSERT INTO ContTiposPolizas (TipoPoliza) VALUES (@TipoPoliza); SELECT CAST(SCOPE_IDENTITY() as int)";
            var idGenerado = SqlConnection.QuerySingle<int>(sql, new { tipoPoliza.TipoPoliza }, transaction: transaction);
            return idGenerado;
        }

        public bool ActualizarTipoPoliza(ContTiposPolizas tipoPoliza, SqlTransaction transaction)
        {
            var sql = "UPDATE ContTiposPolizas SET TipoPoliza = @TipoPoliza WHERE Id = @Id";
            var filasAfectadas = SqlConnection.Execute(sql, new { tipoPoliza.TipoPoliza, tipoPoliza.Id }, transaction: transaction);
            return filasAfectadas > 0;
        }

        public bool EliminarTipoPoliza(int idTipoPoliza, SqlTransaction transaction)
        {
            var sql = "DELETE FROM ContTiposPolizas WHERE Id = @Id";
            var filasAfectadas = SqlConnection.Execute(sql, new { Id = idTipoPoliza }, transaction: transaction);
            return filasAfectadas > 0;
        }
    }
}
