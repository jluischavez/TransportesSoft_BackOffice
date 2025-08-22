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
    public partial class ABCContFrmClientes : Form
    {
        public ABCContFrmClientes()
        {
            InitializeComponent();
        }


        #region "Eventos"
        private void txtKilometraje_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                ContFrmBuscar frmBuscar = new ContFrmBuscar("Clientes", ContFrmBuscar.TipoBusqueda.ContClientes);
                frmBuscar.MdiParent = this.MdiParent;
                frmBuscar.FormBorderStyle = FormBorderStyle.Sizable;

                frmBuscar.ClienteSeleccionadoEvent += FrmBuscar_ClienteSeleccionado;

                frmBuscar.Show();
            }
        }
        #endregion
        #region "Private"
        private void FrmBuscar_ClienteSeleccionado(object sender, ContClientes unidad)
        {
            txtID.Text = unidad.id_Client.ToString();
            txtTelefono.Text = unidad.Telefono.ToString();
            txtNombre.Text = unidad.Nombre;
            txtDireccion.Text = unidad.Direccion.ToString();
        }
        private void Limpiar()
        {
            txtID.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtTelefono.Text = String.Empty;
        }
        #endregion
    }
}
