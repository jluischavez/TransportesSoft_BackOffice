using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Repositories;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_RolesCat
    {
        Repo_RolesCat lRepoRolesCat;
        public Service_RolesCat()
        {
            lRepoRolesCat = new Repo_RolesCat();
        }
        public List<RolesCat> ObtenerRoles()
        {
            return lRepoRolesCat.ObtenerRoles();
        }
    }
}
