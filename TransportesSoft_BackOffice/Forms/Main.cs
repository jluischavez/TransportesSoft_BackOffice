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
            lContUnidades.FormBorderStyle = FormBorderStyle.Sizable;
            lContUnidades.Show();
            lContUnidades.BringToFront();
        }
        #endregion


    }
}
