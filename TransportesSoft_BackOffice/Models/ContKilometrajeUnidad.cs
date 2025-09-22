using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Models
{
    public class ContKilometrajeUnidad
    {
        public int Id { get; set; }
        public int Id_Unidad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int KilometrajeActual { get; set; }
    }
}
