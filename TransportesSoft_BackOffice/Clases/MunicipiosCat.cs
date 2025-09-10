using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Clases
{
    public class MunicipiosCat
    {
        public int IdMunicipio { get; set; }
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public string ClaveInegi { get; set; }
        public bool Activo { get; set; }
    }
}
