using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Clases
{
    public class Municipios
    {
        public int idMunicipio { get; set; }
        public int idEstado { get; set; }
        public string Nombre { get; set; }
        public string ClaveInegi { get; set; }
        public bool Activo { get; set; }
    }
}
