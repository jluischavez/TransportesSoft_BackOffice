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

        public bool ActualizarPoliza(ContPolizasReg polizaExistente, SqlTransaction transaction)
        {
            var sql = @"UPDATE ContPolizasReg 
                        SET FolioPoliza = @FolioPoliza, 
                            FechaRegistro = @FechaRegistro, 
                            FechaExpira = @FechaExpira, 
                            idTipoPoliza = @idTipoPoliza, 
                            idUsuario = @idUsuario
                        WHERE Id = @Id";
            SqlConnection.Execute(sql, polizaExistente, transaction: transaction);

            return true;
        }

        /// <summary>
        /// Esta eliminación de póliza si elimina, no cambia el status.
        /// </summary>
        /// <param name="idPoliza"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool EliminarPoliza(int idPoliza, SqlTransaction transaction)
        {
            var sql = "DELETE FROM ContPolizasReg WHERE Id = @Id";
            SqlConnection.Execute(sql, new { Id = idPoliza }, transaction: transaction);
            return true;
        }
    }
}
