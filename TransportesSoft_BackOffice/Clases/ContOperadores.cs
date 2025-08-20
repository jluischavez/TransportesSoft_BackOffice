using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Clases
{
    public class ContOperadores
    {
        public int id_Operador { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
        public string Estatus { get; set; }
        public int id_Unidad { get; set; }
        public int id_Remolque { get; set; }
    }
}
