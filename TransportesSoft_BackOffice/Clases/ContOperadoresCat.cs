using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace TransportesSoft_BackOffice.Clases
{
    public class ContOperadores
    {
        public int id_Operador { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
        public string Estatus { get; set; }

        public string Descripcion => $"{id_Operador} - {Nombre}";
    }
}
