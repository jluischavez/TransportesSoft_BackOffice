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
    public class Repo_ContRemolques
    {

        private string ConnectionString;
        List<ContRemolques> lContRemolques;

        public Repo_ContRemolques()
        {
            lContRemolques = new List<ContRemolques>();
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public List<ContRemolques> ObtenerRemolques()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM ContRemolques";
                lContRemolques = db.Query<ContRemolques>(sql).ToList();
                return lContRemolques;
            }
        }

        public void GuardarRemolque(ContRemolques lRemolque)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlInsert = "Insert into ContRemolques(Marca, Modelo, Serie, Year, Placas, Fecha_Llantas, Fecha_Fisico_SCT, Impermeabilizacion) " +
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

        public void ActualizarRemolque(ContRemolques lRemolque)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlEdit = "UPDATE ContRemolques set Marca=@Marca, Modelo=@Modelo, Serie=@Serie, Year=@Year, " +
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
