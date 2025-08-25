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
using TransportesSoft_BackOffice.Services;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class ABCContFrmClientes : Form
    {
        Service_ContClientes lServiceContClientes;
        ContClientes lContClientes;
        Boolean esConsulta = false;

        public ABCContFrmClientes()
        {
            InitializeComponent();
            lServiceContClientes = new Service_ContClientes();
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
            try
            {
                if (e.KeyCode == Keys.F3)
                {
                    ContFrmBuscar frmBuscar = new ContFrmBuscar("Clientes", ContFrmBuscar.TipoBusqueda.ContClientes);
                    frmBuscar.MdiParent = this.MdiParent;

                    frmBuscar.FormBorderStyle = FormBorderStyle.FixedDialog;
                    frmBuscar.StartPosition = FormStartPosition.Manual;

                    int x = (this.MdiParent.ClientSize.Width - frmBuscar.Width) / 2;
                    int y = (this.MdiParent.ClientSize.Height - frmBuscar.Height) / 2;
                    frmBuscar.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

                    frmBuscar.ClienteSeleccionadoEvent += FrmBuscar_ClienteSeleccionado;

                    frmBuscar.Show();
                }
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lContClientes = new ContClientes();
                lContClientes.Direccion = txtDireccion.Text.ToUpper();
                lContClientes.Telefono = txtTelefono.Text;
                lContClientes.Nombre = txtNombre.Text.ToUpper();

                if (!esConsulta)
                {
                    lServiceContClientes.GuardarCliente(lContClientes);
                }
                else
                {
                    lContClientes.id_Client = Convert.ToInt32(txtID.Text);
                    lServiceContClientes.ActualizarCliente(lContClientes);
                }

                MessageBox.Show("Se guardó correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            esConsulta = true;
        }
        private void Limpiar()
        {
            txtID.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            esConsulta = false;
        }

        #endregion

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
