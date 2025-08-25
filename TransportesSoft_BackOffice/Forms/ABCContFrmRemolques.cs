using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportesSoft_BackOffice.Clases;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class ABCContFrmRemolques : Form
    {
        public ABCContFrmRemolques()
        {
            InitializeComponent();
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F3)
                {
                    ContFrmBuscar frmBuscar = new ContFrmBuscar("Remolques", ContFrmBuscar.TipoBusqueda.ContRemolques);
                    frmBuscar.MdiParent = this.MdiParent;

                    frmBuscar.FormBorderStyle = FormBorderStyle.FixedDialog;
                    frmBuscar.StartPosition = FormStartPosition.Manual;

                    int x = (this.MdiParent.ClientSize.Width - frmBuscar.Width) / 2;
                    int y = (this.MdiParent.ClientSize.Height - frmBuscar.Height) / 2;
                    frmBuscar.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

                    frmBuscar.RemolqueSeleccionadoEvent += FrmBuscar_RemolqueSeleccionado;

                    frmBuscar.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmBuscar_RemolqueSeleccionado(object sender, ContRemolques remolque)
        {
            //txtID.Text = unidad.id_Client.ToString();
            //txtTelefono.Text = unidad.Telefono.ToString();
            //txtNombre.Text = unidad.Nombre;
            //txtDireccion.Text = unidad.Direccion.ToString();
            //esConsulta = true;
        }
    }
}
