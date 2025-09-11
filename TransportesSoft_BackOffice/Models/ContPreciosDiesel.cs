using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Models
{
    public class ContPreciosDiesel
    {
        public int idDiesel {  get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaExpiro { get; set; }
    }
}
