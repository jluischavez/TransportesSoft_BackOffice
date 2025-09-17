using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Models
{
    public class ContMantenimientosCab
    {
        public int IdMantenimiento { get; set; }
        public DateTime FechaMantenimiento { get; set; }    
        public int Kilometraje { get; set; }
        public string Proveedor { get; set; }
        public decimal CostoTotal { get; set; }
        public int id_Unidad { get; set; }
        public int id_Remolque { get; set; }
    }
}
