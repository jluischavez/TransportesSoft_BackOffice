using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TransportesSoft_BackOffice.Clases
{
    public static class ConexionHelper
    {
        public static string ObtenerCadenaConexion()
        {
            string ruta = "config_conexion.json"; // O usa AppData si lo moviste

            if (!File.Exists(ruta))
                throw new FileNotFoundException("No se encontró el archivo de configuración de conexión.");

            var json = File.ReadAllText(ruta);
            var config = JsonConvert.DeserializeObject<ConfigConexion>(json);

            return config?.CadenaConexion ?? throw new InvalidOperationException("Cadena de conexión vacía.");
        }
    }
}
