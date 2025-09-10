using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Repositories;
using TransportesSoft_BackOffice.Clases;

namespace TransportesSoft_BackOffice.Services
{
    public class Service_ContRemolquesCat
    {
        Repo_ContRemolquesCat lRepoContRemolques;
        List<ContRemolquesCat> lContRemolques;
        public Service_ContRemolquesCat()
        {
            lRepoContRemolques = new Repo_ContRemolquesCat();
        }

        public List<ContRemolquesCat> ObtenerRemolques()
        {
            lContRemolques = lRepoContRemolques.ObtenerRemolques();

            return lContRemolques;
        }

        public void GuardarRemolque(ContRemolquesCat lContRemolque)
        {
            lRepoContRemolques.GuardarRemolque(lContRemolque);
        }
        public void ActualizarRemolque(ContRemolquesCat lRemolque)
        {
            lRepoContRemolques.ActualizarRemolque(lRemolque); 
        }
    }
}
