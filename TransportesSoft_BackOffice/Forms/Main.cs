using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            try
            {
                InitializeComponent();

                this.IsMdiContainer = true;
                this.WindowState = FormWindowState.Maximized;

                // 🔍 Verificar si hay conexión configurada
                //if (!ConexionConfigurada())
                //{
                //    var frmConfig = new FrmConexion(); // Tu formulario de configuración
                //    frmConfig.StartPosition = FormStartPosition.CenterScreen;

                //    var resultadoConfigg = frmConfig.ShowDialog();

                //    if (resultadoConfigg != DialogResult.OK)
                //    {
                //        MessageBox.Show("No se configuró la conexión. La aplicación se cerrará.", "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        this.Close();
                //        return;
                //    }
                //}


                var login = new Login();
                login.StartPosition = FormStartPosition.CenterScreen;

                var resultadoLogin = login.ShowDialog();

                if (resultadoLogin == DialogResult.OK)
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
            catch(Exception ex)
            {
                MessageBox.Show("Error al iniciar la aplicación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #region "Eventos"
        private void Main_Load(object sender, EventArgs e)
        {
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
                frmMantenimientos.ReubicarPanelNotificaciones();
            }
            
        }
        #endregion

        #region "Private"
        private bool ConexionConfigurada()
        {
            string ruta = "config_conexion.json"; // O usa AppData si lo moviste

            if (!File.Exists(ruta))
                return false;

            var json = File.ReadAllText(ruta);
            var config = JsonConvert.DeserializeObject<ConfigConexion>(json);

            return !string.IsNullOrWhiteSpace(config?.CadenaConexion);
        }

        private void PanelNotificaciones()
        {
            /*NOTIFICACIONES DE MANTENIMIENTOS URGENTES*/
            
            if (lConfSucursalLocal.KilometrajeNotificaciones != 0){
                lListProximoMantenimientoUnidadDTO = lServiceContKilometraje.ObtenerProximosMantenimientosPorKilometraje(lConfSucursalLocal.KilometrajeNotificaciones);
            }

            

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
            try
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
            catch(Exception ex)
            {
                MessageBox.Show("Error al traer la configuración: " + ex.Message);
            } 
           
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
        private void registroDePólizasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ContFrmPolizasReg>(this, lUsuarioActual.Id);
        }
        private void registroTiposDePólizasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<ContFrmTiposPolizas>(this);
        }
        private void pólizasPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<RptsFrmPolizasPorFecha>(this);
        }

        private void ingresosPorUnidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactory.AbrirFormulario<RptsFrmIngresosPorUnidad>(this);
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

    /// <summary>
    /// Clase de Panel de notificaciones de Mantenimientos
    /// </summary>
    public class FrmPanelMantenimientos : Form
    {
        private Button btnMinimizar;
        private Button btnContador;
        private FlowLayoutPanel flpContenido;
        private List<ProximoMantenimientoUnidades> mantenimientos;
        private bool estaMinimizado = false;
        public FrmPanelMantenimientos(List<ProximoMantenimientoUnidades> mantenimientos)
        {
            this.mantenimientos = mantenimientos;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = 300;
            this.Height = 120;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;

            btnMinimizar = new Button
            {
                Text = "—",
                Width = 25,
                Height = 25,
                Location = new Point(this.Width - 38, 5),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };
            btnMinimizar.Click += BtnMinimizar_Click;
            this.Controls.Add(btnMinimizar);

            btnMinimizar.BringToFront();

            btnContador = new Button
            {
                Text = mantenimientos.Count.ToString(),
                ForeColor = Color.White,
                BackColor = Color.Red,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Width = 40,
                Height = 40,
                Visible = false
            };
            btnContador.Click += BtnContador_Click;
            this.Controls.Add(btnContador);

            flpContenido = new FlowLayoutPanel
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

                flpContenido.Controls.Add(tarjeta);
            }

            this.Controls.Add(flpContenido);
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            estaMinimizado = true;
            flpContenido.Visible = false;
            btnMinimizar.Visible = false;

            this.Width = 50;
            this.Height = 50;
            ReubicarPanelNotificaciones();
            btnContador.Location = new Point(5, 5);
            btnContador.Visible = true;
        }

        private void BtnContador_Click(object sender, EventArgs e)
        {
            estaMinimizado = false;
            flpContenido.Visible = true;
            btnMinimizar.Visible = true;
            btnContador.Visible = false;

            this.Width = 300;
            this.Height = 120;

            ReubicarPanelNotificaciones();
        }
        public void ReubicarPanelNotificaciones()
        {
            if (this.MdiParent == null) return;

            int margenDerecho = 10;
            int margenInferior = 30;
            int alturaStatusStrip = 0;

            foreach (Control ctl in this.MdiParent.Controls)
            {
                if (ctl is StatusStrip strip)
                {
                    alturaStatusStrip = strip.Height;
                    break;
                }
            }

            int x = this.MdiParent.ClientSize.Width - this.Width - margenDerecho;
            int y = this.MdiParent.ClientSize.Height - this.Height - alturaStatusStrip - margenInferior;

            this.Location = new Point(x, y);
        }
    }
}
