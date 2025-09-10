using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TransportesSoft_BackOffice.Clases;
using Dapper;

namespace TransportesSoft_BackOffice.Repositories
{
    public class Repo_MunicipiosCat
    {
        List<MunicipiosCat> lMunicipios;
        private string ConnectionString;
        public Repo_MunicipiosCat()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }
        public List<MunicipiosCat> ObtenerMunicipios()
        {
            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM MunicipiosCat";
                lMunicipios = db.Query<MunicipiosCat>(sql).ToList();
            }

                return lMunicipios;
        }

        public List<MunicipiosCatYEstado> ObtenerMunicipiosYEstado()
        {
            List<MunicipiosCatYEstado> lMunicipiosYEstado = new List<MunicipiosCatYEstado>();
            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                var sql = " SELECT MC.IdMunicipio,MC.IdEstado,EC.Nombre as estado,MC.Nombre,MC.ClaveInegi,MC.Activo From MunicipiosCat MC " +
                    "LEFT JOIN EstadosCat EC ON ec.IdEstado = MC.IdEstado";
                lMunicipiosYEstado = db.Query<MunicipiosCatYEstado>(sql).ToList();
            }

            return lMunicipiosYEstado;
        }

        public void GuadarMunicipio(MunicipiosCat municipio)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlInsert = "Insert into MunicipiosCat(IdEstado, Nombre, ClaveInegi, Activo) " +
                    "Values(@idEstado, @Nombre, @ClaveInegi, @Activo)";
                var result = db.Execute(sqlInsert, new
                {
                    IdEstado = municipio.IdEstado,
                    Nombre = municipio.Nombre,
                    ClaveInegi = municipio.ClaveInegi,
                    Activo = municipio.Activo
                });
            }
        }
        public void ActualizarMunicipio(MunicipiosCat lmunicipio)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlEdit = "UPDATE MunicipiosCat set IdEstado=@IdEstado,Nombre=@Nombre,ClaveInegi=@ClaveInegi " +
                    "WHERE IdMunicipio=@IdMunicipio";
                var result = db.Execute(sqlEdit, new
                {
                    IdEstado = lmunicipio.IdEstado,
                    Nombre = lmunicipio.Nombre,
                    ClaveInegi = lmunicipio.ClaveInegi,
                    idMunicipio = lmunicipio.IdMunicipio
                }); ;
            }
        }
        public void EliminarMunicipio(int idMunicipio)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sqlDelete = "DELETE FROM MunicipiosCat WHERE IdMunicipio=@IdMunicipio";
                var result = db.Execute(sqlDelete, new
                {
                    IdMunicipio = idMunicipio
                });
            }
        }
    }
}
