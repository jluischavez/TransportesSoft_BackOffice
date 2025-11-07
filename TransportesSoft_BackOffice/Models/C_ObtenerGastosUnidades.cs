using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Models
{
    public class C_ObtenerGastosUnidades
    {
        public int id_Unidad { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoGasto { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
