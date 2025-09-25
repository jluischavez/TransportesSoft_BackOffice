using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_UsuarioRoles
    {
        private string ConnectionString;
        public Repo_UsuarioRoles()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public int GuardarUsuarioRol(int id_Usuario, int id_Rol)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = @"
            INSERT INTO UsuarioRoles (UsuarioId, RolId)
            VALUES (@UsuarioId, @RolId);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";
                int nuevoId = db.ExecuteScalar<int>(sql, new
                {
                    UsuarioId = id_Usuario,
                    RolId = id_Rol
                });
                return nuevoId;
            }
        }

        public int ActualizarUsuarioRol(int id_Usuario, int id_Rol)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = @"
            UPDATE UsuarioRoles
            SET RolId = @RolId
            WHERE UsuarioId = @UsuarioId;";
                int filasAfectadas = db.Execute(sql, new
                {
                    UsuarioId = id_Usuario,
                    RolId = id_Rol
                });
                return filasAfectadas;
            }
        }

        public int ObtenerIDRolPorIDUsuario(int idUsuario)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "SELECT RolId FROM UsuarioRoles WHERE UsuarioId = @UsuarioId";
                int rolId = db.QueryFirstOrDefault<int>(sql, new { UsuarioId = idUsuario });
                return rolId;
            }
        }
    }
}
