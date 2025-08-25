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

            ConfiguracionMDI();
            this.Text = this.Text + " Versión: " + Application.ProductVersion;
            Main_Resize(this, EventArgs.Empty);
        }


        #region "Private"
        private void ConfiguracionMDI()
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
        private void Main_Resize(object sender, EventArgs e)
        {

        }

        #endregion
        #region "Formularios"
        private void aBCDeUnidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ABCContFrmUnidades>(this);
        }

        private void consumoDeUnidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ContFrmConsumosUnidades>(this);
        }

        private void consumoDeUnidadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<RptsFrmConsumoUnidadesPorFecha>(this);
        }

        private void aBCDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ABCContFrmClientes>(this);
        }

        private void aBCDeRemolquesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ABCContFrmRemolques>(this);
        }
        #endregion


    }



    /*CLASE FACTORY PARA CREAR FORMULARIOS*/
    public static class FormFactory
    {
        public static void AbrirFormulario<T>(Form mdiParent) where T : Form, new()
        {
            var formulario = new T();
            formulario.MdiParent = mdiParent;
            formulario.FormBorderStyle = FormBorderStyle.FixedDialog;
            formulario.StartPosition = FormStartPosition.Manual;

            int x = (mdiParent.ClientSize.Width - formulario.Width) / 2;
            int y = (mdiParent.ClientSize.Height - formulario.Height) / 2;
            formulario.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

            formulario.Show();
            formulario.BringToFront();
        }
    }
}
