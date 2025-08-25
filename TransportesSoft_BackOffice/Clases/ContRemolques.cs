using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Clases
{
    public class ContRemolques
    {

        public int id_Remolque { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public int Year { get; set; }
        public string Placas { get; set; }
        public DateTime Fecha_Llantas { get; set; }
        public DateTime Fecha_Fisico_SCT { get; set; }
        public DateTime Impermeabilizacion { get; set; }

    }
}
