using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Models
{
    public class ContMantenimientosDet
    {
        public int IdMantenimiento { get; set; }
        public string Refaccion { get; set; }
        public string Proveedor { get; set; }
        public decimal PrecioRefaccion { get; set; }
        public string Comentarios { get; set; }
        public int Renglon { get; set; }
    }
}
