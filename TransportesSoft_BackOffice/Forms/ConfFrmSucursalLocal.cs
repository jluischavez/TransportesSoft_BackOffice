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
    public partial class ConfFrmSucursalLocal : Base
    {
        Service_ConfSucursalLocal lServiceConfSucursalLocal;
        ConfSucursalLocal conf = new ConfSucursalLocal();
        public ConfFrmSucursalLocal()
        {
            InitializeComponent();
            TraerConfiguracionInicial();
            this.KeyPreview = true;
        }
        #region "Private"
        private void TraerConfiguracionInicial()
        {
            lServiceConfSucursalLocal = new Service_ConfSucursalLocal();
            conf = lServiceConfSucursalLocal.ObtenerConfiguracionSucursalLocal();
            if (conf != null)
            {
                txtNombre.Text = conf.NombreSucursal;
                txtDireccion.Text = conf.Direccion;
                txtImagen.Text = conf.URLImagen;
                txtTelefono.Text = conf.Telefono;
                txtKilometrajeNotificaciones.Text = conf.KilometrajeNotificaciones.ToString();
            }
            else
            {
                txtKilometrajeNotificaciones.Text = "0";
                MessageBox.Show("No se encontró configuración de la sucursal. Favor de guardar una nueva configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Guardar()
        {
            try
            {
                DialogResult result = MessageBox.Show($"¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(txtImagen.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ConfSucursalLocal Sucursal = new ConfSucursalLocal
                    {
                        NombreSucursal = txtNombre.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        URLImagen = txtImagen.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        KilometrajeNotificaciones = txtKilometrajeNotificaciones.Text.Trim() == "" ? 0 : int.Parse(txtKilometrajeNotificaciones.Text.Trim()),
                    };
                    bool exito = false;
                    /*SI NO TIENE ID DE SUCURSAL SIGNIFICA QUE NO EXISTE ENTONCES SE GUARDA UNA NUEVA*/
                    if (conf == null)
                    {
                        exito = lServiceConfSucursalLocal.GuardarConfiguracionSucursalLocal(Sucursal);
                    }
                    else
                    {
                        exito = lServiceConfSucursalLocal.ActualizarConfiguracionSucursalLocal(Sucursal);
                    }

                    if (exito)
                    {
                        MessageBox.Show("Configuración guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la configuración. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar " + ex.Message);
            }
        }
        #endregion
        #region "Eventos"
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {
            Guardar();
        }

        private void BtnExaminar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar imagen";
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImagen.Text = openFileDialog.FileName;
                }
            }
        }


        private void txtKilometrajeNotificaciones_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (decimal.TryParse(txt.Text, out decimal valor))
            {
                txt.Text = valor.ToString();
            }
            else
            {
                txt.Text = "0";
            }
        }

        private void txtKilometrajeNotificaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void ConfFrmSucursalLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                BtnGuardar.Focus();
                Guardar();
            }
        }
        #endregion
    }
}
