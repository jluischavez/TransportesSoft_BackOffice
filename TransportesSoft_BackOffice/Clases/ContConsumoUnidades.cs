using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Clases
{
    public class ContConsumoUnidades
    {
        public int id_Unidad { get; set; }
        public DateTime Fecha { get; set; }
        public int ConsumoLitros { get; set; }
        public string Comentarios { get; set; }
        public decimal ConsumoPesos { get; set; }
    }
}
