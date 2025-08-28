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
        Boolean _esConsulta = false;

        /// <summary>
        /// Propiedad que establece un estado al botón eliminar, el cual cambiará dependiendo de si es consulta o no.
        /// </summary>
        private bool EsConsulta
        {
            get => _esConsulta;
            set
            {
                if (_esConsulta != value)
                {
                    _esConsulta = value;
                    BtnEliminar.Enabled = _esConsulta; // Actualiza el botón automáticamente
                }
            }
        }
        public ABCContFrmClientes()
        {
            InitializeComponent();
            this.KeyPreview = true;
            lServiceContClientes = new Service_ContClientes();
            txtID.TextChanged += txtID_TextChanged;
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
                if (e.KeyCode == Keys.Back)
                {
                    txtID.Clear(); // Borra todo el texto
                    e.SuppressKeyPress = true; // Opcional: evita que el sonido de tecla se reproduzca
                }
                else if (e.KeyCode == Keys.F3)
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
            GuardarCliente();
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_esConsulta)
                {
                    DialogResult result = MessageBox.Show($"¿Estás seguro que deseas eliminar el cliente {txtID.Text} - {txtNombre.Text}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        lServiceContClientes.EliminarCliente(Convert.ToInt32(txtID.Text));

                        MessageBox.Show("Se eliminó correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            // Si antes era consulta y ahora el campo está vacío, se interpreta como nuevo registro
            if (_esConsulta && string.IsNullOrWhiteSpace(txtID.Text))
            {
                EsConsulta = false;
                Limpiar(); // Limpia todos los campos
            }
        }

        private void ABCContFrmClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Limpiar();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.G)
            {
                GuardarCliente();
            }
        }

        private void ABCContFrmClientes_Load(object sender, EventArgs e)
        {
            /*Establece estado del btnEliminar*/
            EsConsulta = false;
            BtnEliminar.Enabled = false;
        }
        #endregion
        #region "Private"
        private void GuardarCliente()
        {
            try
            {

                DialogResult result = MessageBox.Show($"¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (lServiceContClientes.ValidarInfoAntesDeGuardar(txtNombre.Text))
                    {
                        lContClientes = new ContClientes();
                        lContClientes.Direccion = txtDireccion.Text.ToUpper();
                        lContClientes.Telefono = txtTelefono.Text;
                        lContClientes.Nombre = txtNombre.Text.ToUpper();
                        lContClientes.Estatus = "A";
                        if (!_esConsulta)
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
                    else
                    {
                        MessageBox.Show("El campo Nombre es obligatorio de capturar.", "Verificar la información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FrmBuscar_ClienteSeleccionado(object sender, ContClientes unidad)
        {
            txtID.Text = unidad.id_Client.ToString();
            txtTelefono.Text = unidad.Telefono.ToString();
            txtNombre.Text = unidad.Nombre;
            txtDireccion.Text = unidad.Direccion.ToString();
            EsConsulta = true;
        }
        private void Limpiar()
        {
            txtID.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            EsConsulta = false;
        }

        #endregion

        

       
    }
}
