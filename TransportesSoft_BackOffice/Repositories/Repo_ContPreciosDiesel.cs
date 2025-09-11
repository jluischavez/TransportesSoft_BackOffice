using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Repositories
{
    
    public class Repo_ContPreciosDiesel
    {
        private string ConnectionString;
        public Repo_ContPreciosDiesel() 
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public void GuadarPrecioDiesel(ContPreciosDiesel PrecioDiesel)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlInsert = "INSERT INTO ContPreciosDiesel(Precio, FechaRegistro, FechaExpiro) " +
                    "Values(@Precio, @FechaRegistro, @FechaExpiro)";
                var result = db.Execute(sqlInsert, new
                {
                    Precio = PrecioDiesel.Precio,
                    FechaRegistro = PrecioDiesel.FechaRegistro,
                    FechaExpiro = PrecioDiesel.FechaExpiro
                });
            }
        }

        public ContPreciosDiesel PrecioActualDiesel()
        {
            ContPreciosDiesel preciosDiesel = new ContPreciosDiesel();
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT TOP 1 IdDiesel, ROUND(Precio,2) As Precio, FechaRegistro, FechaExpiro FROM ContPreciosDiesel " +
                    "ORDER BY IdDiesel DESC";
                preciosDiesel = db.QueryFirstOrDefault<ContPreciosDiesel>(sql);
                return preciosDiesel;
            }
        }

        public void ActualizarUltimoPrecioDiesel()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlEdit = "UPDATE ContPreciosDiesel SET FechaExpiro = GETDATE() " +
                   
                    "WHERE IdDiesel = ( SELECT MAX(IdDiesel) FROM ContPreciosDiesel) ";
                db.Execute(sqlEdit); ;
            }
        }
    }
}
