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
    public class Repo_UsuariosCat
    {
        private string ConnectionString;
        public Repo_UsuariosCat()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }
        public List<UsuariosCat> ObtenerUsuarios()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM UsuariosCat";
                return db.Query<UsuariosCat>(sql).ToList();
            }
        }

        public UsuariosCat ObtenerUsuarioPorNombre(string username)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM UsuariosCat WHERE NombreUsuario = @NombreUsuario AND Activo = 1";
                return db.QueryFirstOrDefault<UsuariosCat>(sql, new { NombreUsuario = username });
            }
        }

        public int GuardarUsuario(UsuariosCat lusuario)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                string sql = @"
            INSERT INTO UsuariosCat (NombreUsuario, ContrasenaHash, FechaRegistro, Activo)
            VALUES (@NombreUsuario, @ContrasenaHash, @FechaRegistro, @Activo);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int nuevoId = db.ExecuteScalar<int>(sql, new
                {
                    NombreUsuario = lusuario.NombreUsuario,
                    ContrasenaHash = lusuario.ContrasenaHash,
                    FechaRegistro = DateTime.Now,
                    Activo = true 
                });

                return nuevoId;
            }
        }

        public void ActualizarContrasena(int userId, string nuevaContrasenaHash)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                string sql = "UPDATE UsuariosCat SET ContrasenaHash = @ContrasenaHash, Activo = 1 WHERE Id = @Id";
                db.Execute(sql, new { ContrasenaHash = nuevaContrasenaHash, Id = userId });
            }
        }

        public void DesactivarUsuario(int userId)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                string sql = "UPDATE UsuariosCat SET Activo = 0 WHERE Id = @Id";
                db.Execute(sql, new { Id = userId });
            }
        }

    }
}
