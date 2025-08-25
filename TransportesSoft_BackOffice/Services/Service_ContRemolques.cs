using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Repositories;
using TransportesSoft_BackOffice.Clases;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContRemolques
    {
        Repo_ContRemolques lRepoContRemolques;
        List<ContRemolques> lContRemolques;
        public Service_ContRemolques()
        {
            lRepoContRemolques = new Repo_ContRemolques();
        }

        public List<ContRemolques> ObtenerRemolques()
        {
            lContRemolques = lRepoContRemolques.ObtenerRemolques();

            return lContRemolques;
        }
    }
}
