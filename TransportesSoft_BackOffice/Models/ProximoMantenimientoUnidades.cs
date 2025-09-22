using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Models
{
    public class ProximoMantenimientoUnidades
    {
        public int Id_Unidad { get; set; }
        public int UltimoIdMantenimiento { get; set; }
        public int KMMantenimiento { get; set; }
        public DateTime FechaMantenimiento { get; set; }
        public int UltimoIdKilometraje { get; set; }
        public int KilometrajeActual { get; set; }
        public DateTime FechaKilometraje { get; set; }
        public int ProximoMantenimiento { get; set; }
        public decimal CostoTotal { get; set; }
    }
}
