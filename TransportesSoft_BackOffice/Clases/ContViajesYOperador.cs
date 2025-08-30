using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesSoft_BackOffice.Clases
{
    public class ContViajesYOperador
    {
        public int id_viaje { get; set; }
        public int id_Client { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaViaje { get; set; }
        public DateTime FechaFactura { get; set; }
        public string Factura { get; set; }
        public int NumeroTansporte { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public decimal Monto { get; set; }
        public decimal IVA { get; set; }
        public decimal Retenciones { get; set; }
        public decimal Total { get; set; }
        public string Comentarios { get; set; }
        public decimal Maniobra { get; set; }
        public int id_Operador { get; set; }
        public string NombreOperador { get; set; }
    }
}
