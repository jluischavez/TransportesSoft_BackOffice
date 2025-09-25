using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Models
{
    public class UsuariosCat
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string ContrasenaHash { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
    }
}
