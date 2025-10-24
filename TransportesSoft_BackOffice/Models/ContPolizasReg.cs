using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Models
{
    public class ContPolizasReg
    {

        public int Id { get; set; }
        public string FolioPoliza { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaExpira { get; set; }
        public int idTipoPoliza { get; set; }
        public int idUsuario { get; set; }
    }
}
