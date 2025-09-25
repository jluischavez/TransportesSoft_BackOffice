using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Repositories;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_UsuarioRoles
    {
        private Repo_UsuarioRoles lRepoUsuarioRoles;
        public Service_UsuarioRoles()
        {
            lRepoUsuarioRoles = new Repo_UsuarioRoles();
        }

        public int GuardarUsuarioRol(int id_Usuario, int id_Rol)
        {
            return lRepoUsuarioRoles.GuardarUsuarioRol(id_Usuario, id_Rol);
        }

        public int ActualizarUsuarioRol(int id_Usuario, int id_Rol)
        {
            return lRepoUsuarioRoles.ActualizarUsuarioRol(id_Usuario, id_Rol);
        }

        public int ObtenerIDRolPorIDUsuario(int idUsuario)
        {
            return lRepoUsuarioRoles.ObtenerIDRolPorIDUsuario(idUsuario);
        }
    }
}
