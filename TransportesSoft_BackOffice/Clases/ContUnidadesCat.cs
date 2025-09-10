using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Clases
{
    public class ContUnidadesCat
    {

        public int id_Unidad { get; set; }
        public string Marca { get; set; }

        public string Serie { get; set; }
        public int Kilometraje { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int id_Operador { get; set; }
        public int ProximoMantenimiento { get; set; }
        public string Estatus { get; set; }
        public int id_Remolque { get; set; }

        public string Descripcion => $"{id_Unidad} - {Marca} ({Serie})";
    }
}
