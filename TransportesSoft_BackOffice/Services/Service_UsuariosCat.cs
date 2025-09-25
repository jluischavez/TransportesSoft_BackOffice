using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Models;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_UsuariosCat
    {
        Repo_UsuariosCat lRepoUsuariosCat;
        public Service_UsuariosCat()
        {
            lRepoUsuariosCat = new Repo_UsuariosCat();
        }

        public List<UsuariosCat> ObtenerUsuarios()
        {
            return lRepoUsuariosCat.ObtenerUsuarios();
        }
        public UsuariosCat ObtenerUsuarioPorNombre(string username)
        {
            return lRepoUsuariosCat.ObtenerUsuarioPorNombre(username);
        }

        public int GuardarUsuario(UsuariosCat lusuario)
        {
            return lRepoUsuariosCat.GuardarUsuario(lusuario);
        }

        public void ActualizarContrasena(int userId, string nuevaContrasenaHash)
        {
            lRepoUsuariosCat.ActualizarContrasena(userId, nuevaContrasenaHash);
        }

        public void DesactivarUsuario(int userId)
        {
            lRepoUsuariosCat.DesactivarUsuario(userId);
        }

        public string HashContrasena(string contraseña)
        {
            // Ejemplo con SHA256
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(contraseña);
                var hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public bool ValidarContraseña(string contraseñaIngresada, string contraseñaHashAlmacenada)
        {
            // Ejemplo con SHA256
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(contraseñaIngresada);
                var hash = sha.ComputeHash(bytes);
                var hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();

                return hashString == contraseñaHashAlmacenada.ToLower();
            }
        }
    }
}
