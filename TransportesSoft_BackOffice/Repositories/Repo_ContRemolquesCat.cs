using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_ContRemolquesCat
    {

        private string ConnectionString;
        List<ContRemolquesCat> lContRemolques;

        public Repo_ContRemolquesCat()
        {
            lContRemolques = new List<ContRemolquesCat>();
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public List<ContRemolquesCat> ObtenerRemolques()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContRemolquesCat";
                lContRemolques = db.Query<ContRemolquesCat>(sql).ToList();
                return lContRemolques;
            }
        }

        public void GuardarRemolque(ContRemolquesCat lRemolque)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlInsert = "Insert into ContRemolquesCat(Marca, Modelo, Serie, Year, Placas, Fecha_Llantas, Fecha_Fisico_SCT, Impermeabilizacion) " +
                    "Values(@Marca, @Modelo, @Serie, @Year, @Placas, @Fecha_Llantas, @Fecha_Fisico_SCT, @Impermeabilizacion)";
                var result = db.Execute(sqlInsert, new
                {
                    Marca = lRemolque.Marca,
                    Modelo = lRemolque.Modelo,
                    Serie = lRemolque.Serie,
                    Year = lRemolque.Year,
                    Placas = lRemolque.Placas,
                    Fecha_Llantas = lRemolque.Fecha_Llantas,
                    Fecha_Fisico_SCT = lRemolque.Fecha_Fisico_SCT,
                    Impermeabilizacion = lRemolque.Impermeabilizacion
                });
            }
        }

        public void ActualizarRemolque(ContRemolquesCat lRemolque)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlEdit = "UPDATE ContRemolquesCat set Marca=@Marca, Modelo=@Modelo, Serie=@Serie, Year=@Year, " +
                    "Placas=@Placas, Fecha_Llantas=@Fecha_Llantas, Fecha_Fisico_SCT=@Fecha_Fisico_SCT, Impermeabilizacion=@Impermeabilizacion " +
                    "WHERE id_Remolque=@id_Remolque";
                var result = db.Execute(sqlEdit, new
                {
                    Marca = lRemolque.Marca,
                    Modelo = lRemolque.Modelo,
                    Serie = lRemolque.Serie,
                    Year = lRemolque.Year,
                    Placas = lRemolque.Placas,
                    Fecha_Llantas = lRemolque.Fecha_Llantas,
                    Fecha_Fisico_SCT = lRemolque.Fecha_Fisico_SCT,
                    Impermeabilizacion = lRemolque.Impermeabilizacion,
                    id_Remolque = lRemolque.id_Remolque
                }); ;
            }
        }
    }
}
