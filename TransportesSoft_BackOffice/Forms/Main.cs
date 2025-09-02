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
        private ConfSucursalLocal lConfSucursalLocal;
        private Service_ConfSucursalLocal lserviceConfSucLocal;

        public Main()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            ConfiguracionMDI();
            this.Text = this.Text + " Versión: " + Application.ProductVersion;
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
                    // Activar DoubleBuffered por reflexión
                    typeof(Control).InvokeMember("DoubleBuffered",
                        System.Reflection.BindingFlags.SetProperty |
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.NonPublic,
                        null, mdiClient, new object[] { true });

                    // Eliminar cualquier imagen de fondo previa
                    mdiClient.BackgroundImage = null;

                    // Dibujar imagen manualmente sin repetir
                    mdiClient.Paint += (s, e) =>
                    {
                        e.Graphics.Clear(mdiClient.BackColor); // Limpia fondo
                        e.Graphics.DrawImage(fondoImagen, new Rectangle(0, 0, mdiClient.Width, mdiClient.Height));
                    };

                    mdiClient.Resize += (s, e) => mdiClient.Invalidate(); // Redibuja al cambiar tamaño
                    mdiClient.Invalidate(); // Pintado inicial
                    break;
                }
            }

            string rawConnection = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            var builder = new SqlConnectionStringBuilder(rawConnection);

            string instancia = builder.DataSource;
            string baseDatos = builder.InitialCatalog;

            toolStripStatusConexion.Text = $"BD: {baseDatos} | Instancia: {instancia}";
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
        private void viajesPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<RptsFrmViajesPorFecha>(this);
        }
        private void aBCDeOperadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ABCContFrmOperadores>(this);
        }

        private void próximosMantenimientosDeUnidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<RptsFrmMantenimientoUnidades>(this);
        }
        #endregion


    }



    /// <summary>
    /// CLASE FACTORY PARA CREAR FORMULARIOS
    /// </summary>
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
