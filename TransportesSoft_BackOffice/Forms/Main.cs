using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Forms;
using TransportesSoft_BackOffice.Services;

namespace TransportesSoft_BackOffice
{
    public partial class Main : Form
    {
        ConfSucursalLocal lConfSucursalLocal;
        Service_ConfSucursalLocal lserviceConfSucLocal;

        public Main()
        {
            InitializeComponent();

            this.Resize += Main_Resize;

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            ConfiguracionFondo();
            this.Text = this.Text + " Versión: " + Application.ProductVersion;
            Main_Resize(this, EventArgs.Empty);
        }


        #region "Private"

        private void ConfiguracionFondo()
        {
            lserviceConfSucLocal = new Service_ConfSucursalLocal();
            lConfSucursalLocal = lserviceConfSucLocal.ObtenerConfiguracionSucursalLocal();

            Image fondoImagen = Image.FromFile(lConfSucursalLocal.URLImagen);

            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient mdiClient)
                {
                    mdiClient.Paint += (s, e) =>
                    {
                        e.Graphics.DrawImage(fondoImagen, mdiClient.ClientRectangle);
                    };

                    // Maneja el Resize para redibujar el fondo
                    mdiClient.Resize += (s, e) =>
                    {
                        mdiClient.Invalidate(); // Fuerza repintado
                    };

                    mdiClient.Invalidate(); // Pintado inicial
                    break;
                }
            }



            string rawConnection = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            var builder = new SqlConnectionStringBuilder(rawConnection);

            string instancia = builder.DataSource;       // Ej: "SQLServer\\Instancia"
            string baseDatos = builder.InitialCatalog;   // Ej: "MiBaseDeDatos"

            toolStripStatusConexion.Text = $"BD: {baseDatos} | Instancia: {instancia}";
        }

        //private void BtnReporte_Click(object sender, EventArgs e)
        //{
        //    FormReporte_Load lreport = new FormReporte_Load();
        //    lreport.MdiParent = this;
        //    lreport.FormBorderStyle = FormBorderStyle.Sizable; // o None si quieres sin bordes
        //    lreport.Show();
        //    lreport.BringToFront();

        //}
        private void Main_Resize(object sender, EventArgs e)
        {

        }

        private void aBCDeUnidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABCContFrmUnidades lContUnidades = new ABCContFrmUnidades();
            lContUnidades.MdiParent = this;
            lContUnidades.FormBorderStyle = FormBorderStyle.FixedDialog;

            lContUnidades.StartPosition = FormStartPosition.Manual;
            // Centrar respecto al MDI client
            int x = (this.ClientSize.Width - lContUnidades.Width) / 2;
            int y = (this.ClientSize.Height - lContUnidades.Height) / 2;
            lContUnidades.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));


            lContUnidades.Show();
            lContUnidades.BringToFront();
            
        }

        #endregion

        private void consumoDeUnidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContFrmConsumosUnidades lFrmConsumoUnidades = new ContFrmConsumosUnidades();
            lFrmConsumoUnidades.MdiParent = this;
            lFrmConsumoUnidades.FormBorderStyle = FormBorderStyle.FixedDialog;

            lFrmConsumoUnidades.StartPosition = FormStartPosition.Manual;
            // Centrar respecto al MDI client
            int x = (this.ClientSize.Width - lFrmConsumoUnidades.Width) / 2;
            int y = (this.ClientSize.Height - lFrmConsumoUnidades.Height) / 2;
            lFrmConsumoUnidades.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));


            lFrmConsumoUnidades.Show();
            lFrmConsumoUnidades.BringToFront();
        }

        private void consumoDeUnidadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RptsFrmConsumoUnidadesPorFecha lRptConsumoUnidadesPorFecha = new RptsFrmConsumoUnidadesPorFecha();
            lRptConsumoUnidadesPorFecha.MdiParent = this;
            lRptConsumoUnidadesPorFecha.FormBorderStyle = FormBorderStyle.FixedDialog; // o None si quieres sin bordes

            lRptConsumoUnidadesPorFecha.StartPosition = FormStartPosition.Manual;
            // Centrar respecto al MDI client
            int x = (this.ClientSize.Width - lRptConsumoUnidadesPorFecha.Width) / 2;
            int y = (this.ClientSize.Height - lRptConsumoUnidadesPorFecha.Height) / 2;
            lRptConsumoUnidadesPorFecha.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

            lRptConsumoUnidadesPorFecha.Show();
            lRptConsumoUnidadesPorFecha.BringToFront();
        }
    }
}
