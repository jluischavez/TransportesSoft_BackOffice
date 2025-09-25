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
using TransportesSoft_BackOffice.Models;
using TransportesSoft_BackOffice.Services;

namespace TransportesSoft_BackOffice
{
    public partial class Main : Form
    {
        private ConfSucursalLocal lConfSucursalLocal;
        private Service_ConfSucursalLocal lserviceConfSucLocal;
        private UsuariosCat lUsuarioActual = new UsuariosCat();

        public Main()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            
            

            var login = new Login();
            login.StartPosition = FormStartPosition.CenterScreen;

            var resultado = login.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                lUsuarioActual.Id = login.lUsuario.Id;
                lUsuarioActual.NombreUsuario = login.lUsuario.NombreUsuario;
            }
            else
            {
                // Cerrar la app si el login falla o se cancela
                this.Close();
            }
            ConfiguracionMDI();

            this.Text = this.Text + " | Sucursal: " + lConfSucursalLocal.NombreSucursal + " | Versión: " + Application.ProductVersion;
        }

        #region "Eventos"
        private void Main_Load(object sender, EventArgs e)
        {
            //FrmNotificaciones postIt = new FrmNotificaciones();
            //postIt.MdiParent = this; // 'this' es el MDI principal
            //postIt.Location = new Point(this.ClientSize.Width / 2, 0); // esquina superior derecha
            //postIt.Show();
        }
        #endregion

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

            toolStripStatusConexion.Text = $"BD: {baseDatos} | Instancia: {instancia} | Usuario: {lUsuarioActual.NombreUsuario}";
        }

        #endregion
        #region "Formularios"

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
        private void próximosMantenimientosDeUnidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<RptsFrmMantenimientoUnidades>(this);
        }
        private void viajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ContFrmViajes>(this);
        }
        private void aBCDeOperadoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ABCContFrmOperadores>(this);
        }
        private void aBCDeUnidadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ABCContFrmUnidades>(this);
        }
        private void aBCDeRemolquesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ABCContFrmRemolques>(this);
        }
        private void aBCDeMunicipiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ABCFrmMunicipios>(this);
        }
        private void preciosDeDieselToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ContFrmPreciosDiesel>(this);
        }
        private void mantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ContFrmMantenimientos>(this);
        }
        private void kilometrajePorUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ContFrmKilometrajeUnidades>(this);
        }
        private void aBCDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<SegFrmUsuariosCat>(this,"",0);
        }

        #endregion

       
    }

    /// <summary>
    /// CLASE FACTORY PARA CREAR FORMULARIOS
    /// </summary>
    public static class FormFactory
    {
        public static void AbrirFormulario<T>(Form mdiParent, params object[] args) where T : Form
        {
            var formulario = (T)Activator.CreateInstance(typeof(T), args);
            formulario.MdiParent = mdiParent;
            formulario.StartPosition = FormStartPosition.Manual;

            int x = (mdiParent.ClientSize.Width - formulario.Width) / 2;
            int y = (mdiParent.ClientSize.Height - formulario.Height) / 2;
            formulario.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

            formulario.Show();
            formulario.BringToFront();
        }

    }
}
