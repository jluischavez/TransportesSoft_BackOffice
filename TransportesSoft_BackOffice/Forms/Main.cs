using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Services;

namespace TransportesSoft_BackOffice
{
    public partial class Main : Form
    {
        List<ContUnidades> lContUnidades;
        Service_ContUnidades lServiceContUnidades;

        public Main()
        {
            InitializeComponent();

            lServiceContUnidades = new Service_ContUnidades();

            //string connection =
            //    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Transportes_Barcelo;Integrated Security=True;";


            lContUnidades = lServiceContUnidades.ObtenerUnidades();
            DGV_Unidades.DataSource = lContUnidades;
            
        }
    }
}
