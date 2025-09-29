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
        private Service_ContKilometrajeUnidad lServiceContKilometraje = new Service_ContKilometrajeUnidad();
        private List<ProximoMantenimientoUnidades> lListProximoMantenimientoUnidadDTO = new List<ProximoMantenimientoUnidades>();
        private FrmPanelMantenimientos frmMantenimientos;

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

            this.Text = this.Text + " | Sucursal: " + (lConfSucursalLocal?.NombreSucursal ?? "") + " | Versión: " + Application.ProductVersion;
        }

        #region "Eventos"
        private void Main_Load(object sender, EventArgs e)
        {
            //FrmNotificaciones postIt = new FrmNotificaciones();
            //postIt.MdiParent = this; // 'this' es el MDI principal
            //postIt.Location = new Point(this.ClientSize.Width / 2, 0); // esquina superior derecha
            //postIt.Show();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (frmMantenimientos != null && !frmMantenimientos.IsDisposed)
            {
                int margenDerecho = 10;
                int margenInferior = 30;
                int alturaStatusStrip = statusStrip1.Height;

                int x = this.ClientSize.Width - frmMantenimientos.Width - margenDerecho;
                int y = this.ClientSize.Height - frmMantenimientos.Height - alturaStatusStrip - margenInferior;

                frmMantenimientos.Location = new Point(x, y);
            }
        }
        #endregion

        #region "Private"
        private void PanelNotificaciones()
        {
            /*NOTIFICACIONES DE MANTENIMIENTOS URGENTES*/
            //flpMantenimientos.Controls.Clear();
            //lListProximoMantenimientoUnidadDTO = lServiceContKilometraje.ObtenerProximosMantenimientosPorKilometraje(3000);
            //foreach (var m in lListProximoMantenimientoUnidadDTO)
            //{
            //    var tarjeta = new Panel();
            //    tarjeta.Width = 250;
            //    tarjeta.Height = 100;
            //    tarjeta.Margin = new Padding(10);
            //    tarjeta.BorderStyle = BorderStyle.FixedSingle;

            //    // Color según urgencia
            //    if (m.ProximoMantenimiento <= 0)
            //        tarjeta.BackColor = Color.Red; // Vencido
            //    else if (m.ProximoMantenimiento <= 1000)
            //        tarjeta.BackColor = Color.Yellow; // Próximo
            //    else
            //        tarjeta.BackColor = Color.YellowGreen; // Lejano

            //    // Contenido visual
            //    var lblUnidad = new Label { Text = $"🚛 Unidad: {m.Id_Unidad}", AutoSize = true };
            //    var lblTipo = new Label { Text = $"🛠️ Tipo: Mantenimiento", AutoSize = true };
            //    var lblKm = new Label { Text = $"📍 Faltan: {m.ProximoMantenimiento} km", AutoSize = true };

            //    tarjeta.Controls.Add(lblUnidad);
            //    tarjeta.Controls.Add(lblTipo);
            //    tarjeta.Controls.Add(lblKm);

            //    // Posiciona verticalmente
            //    lblUnidad.Location = new Point(10, 10);
            //    lblTipo.Location = new Point(10, 35);
            //    lblKm.Location = new Point(10, 60);

            //    flpMantenimientos.Controls.Add(tarjeta);

            //    flpMantenimientos.Width = 300;
            //    flpMantenimientos.Height = 200;
            //    flpMantenimientos.Anchor = AnchorStyles.None;
            //}
            //if (lListProximoMantenimientoUnidadDTO.Count == 0)
            //{
            //    flpMantenimientos.Visible = false;
            //}

            lListProximoMantenimientoUnidadDTO = lServiceContKilometraje.ObtenerProximosMantenimientosPorKilometraje(3000);

            if (lListProximoMantenimientoUnidadDTO.Count == 0)
            {
                frmMantenimientos?.Close();
                return;
            }

            frmMantenimientos?.Close(); // Cierra si ya existe

            frmMantenimientos = new FrmPanelMantenimientos(lListProximoMantenimientoUnidadDTO);
            frmMantenimientos.MdiParent = this;

            int margenDerecho = 10;
            int margenInferior = 30;
            int alturaStatusStrip = statusStrip1.Height;

            int x = this.ClientSize.Width - frmMantenimientos.Width - margenDerecho;
            int y = this.ClientSize.Height - frmMantenimientos.Height - statusStrip1.Height - margenInferior;

            frmMantenimientos.Location = new Point(x, y);
            frmMantenimientos.Show();
            frmMantenimientos.BringToFront();
        }
        private void ConfiguracionMDI()
        {
            lserviceConfSucLocal = new Service_ConfSucursalLocal();
            lConfSucursalLocal = lserviceConfSucLocal.ObtenerConfiguracionSucursalLocal();
            
            if (lConfSucursalLocal == null)
            {
                MessageBox.Show("No se encontró configuración de sucursal local. Favor de configurarla.");
            }
            else
            {
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
            }

            string rawConnection = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            var builder = new SqlConnectionStringBuilder(rawConnection);

            string instancia = builder.DataSource;
            string baseDatos = builder.InitialCatalog;

            toolStripStatusConexion.Text = $"BD: {baseDatos} | Instancia: {instancia} | Usuario: {lUsuarioActual.NombreUsuario}";

            PanelNotificaciones();
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

        private void configuraciónDeSucursalLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ConfFrmSucursalLocal>(this);
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
            formulario.Activate();
        }

    }

    public class FrmPanelMantenimientos : Form
    {
        public FrmPanelMantenimientos(List<ProximoMantenimientoUnidades> mantenimientos)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = 300;
            this.Height = 200;
            this.StartPosition = FormStartPosition.Manual;
            //this.BackColor = Color.Transparent;
            this.ShowInTaskbar = false;

            var flp = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.Transparent
            };

            foreach (var m in mantenimientos)
            {
                var tarjeta = new Panel
                {
                    Width = 250,
                    Height = 100,
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = m.ProximoMantenimiento <= 0 ? Color.Red :
                                m.ProximoMantenimiento <= 1000 ? Color.Yellow : Color.YellowGreen
                };

                tarjeta.Controls.Add(new Label { Text = $"🚛 Unidad: {m.Id_Unidad}", Location = new Point(10, 10), AutoSize = true });
                tarjeta.Controls.Add(new Label { Text = $"🛠️ Tipo: Mantenimiento", Location = new Point(10, 35), AutoSize = true });
                tarjeta.Controls.Add(new Label { Text = $"📍 Faltan: {m.ProximoMantenimiento} km", Location = new Point(10, 60), AutoSize = true });

                flp.Controls.Add(tarjeta);
            }

            this.Controls.Add(flp);
        }
    }
}
