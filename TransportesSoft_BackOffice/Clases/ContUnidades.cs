using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Clases
{
    public class ContUnidades
    {

        public int id_Unidad { get; set; }
        public string Marca { get; set; }

        public string Serie { get; set; }
        public int Kilometraje { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int id_Transportista { get; set; }
        public int ProximoManteminiento { get; set; }


    }
}
