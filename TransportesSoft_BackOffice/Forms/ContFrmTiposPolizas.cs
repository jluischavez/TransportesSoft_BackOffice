using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportesSoft_BackOffice.Services;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class ContFrmTiposPolizas : Base
    {
       Service_ContTiposPolizas service_ContTiposPolizas = new Service_ContTiposPolizas();

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
        public ContFrmTiposPolizas()
        {
            InitializeComponent();
            this.KeyPreview = true;
            txtID.TextChanged += txtID_TextChanged;
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

        private void Limpiar()
        {
            txtID.Text = String.Empty;
            txtTipoPoliza.Text = String.Empty;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                /*Validaciones antes de guardar*/
                if (string.IsNullOrWhiteSpace(txtTipoPoliza.Text))
                {
                    MessageBox.Show("El campo Tipo de Póliza es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                /*Lógica de guardado*/
                DialogResult result = MessageBox.Show($"¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    service_ContTiposPolizas = new Service_ContTiposPolizas();
                    ContTiposPolizas nuevoTipoPoliza = new ContTiposPolizas
                    {
                        TipoPoliza = txtTipoPoliza.Text
                    };

                    if (EsConsulta)
                    {
                        int idTipoPoliza = Convert.ToInt32(txtID.Text);
                        nuevoTipoPoliza.Id = idTipoPoliza;
                        service_ContTiposPolizas.ActualizarTipoPoliza(nuevoTipoPoliza);
                        MessageBox.Show("Se actualizó correctamente el ID: " + idTipoPoliza, "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int idTipoPolizaGuardado = service_ContTiposPolizas.GuardarTipoPoliza(nuevoTipoPoliza);
                        MessageBox.Show("Se guardó correctamente con el ID: " + idTipoPolizaGuardado, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                        
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cambios: " + ex.Message);
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
                    ContFrmBuscar frmBuscar = new ContFrmBuscar("Tipos de Pólizas", ContFrmBuscar.TipoBusqueda.TiposPolizas);
                    frmBuscar.MdiParent = this.MdiParent;

                    frmBuscar.FormBorderStyle = FormBorderStyle.FixedDialog;
                    frmBuscar.StartPosition = FormStartPosition.Manual;

                    int x = (this.MdiParent.ClientSize.Width - frmBuscar.Width) / 2;
                    int y = (this.MdiParent.ClientSize.Height - frmBuscar.Height) / 2;
                    frmBuscar.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

                    frmBuscar.TipoPolizaSeleccionadaEvent += FrmBuscar_TipoPolizaSeleccionada;

                    frmBuscar.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FrmBuscar_TipoPolizaSeleccionada(object sender, ContTiposPolizas tipoPolizaSeleccionada)
        {
            try
            {
                if (tipoPolizaSeleccionada != null)
                {
                    txtID.Text = tipoPolizaSeleccionada.Id.ToString();
                    txtTipoPoliza.Text = tipoPolizaSeleccionada.TipoPoliza;
                    EsConsulta = true; // Cambia el estado a consulta
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_esConsulta)
                {
                    DialogResult result = MessageBox.Show($"¿Estás seguro que deseas la póliza {txtID.Text} - {txtTipoPoliza.Text}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        service_ContTiposPolizas.EliminarTipoPoliza(Convert.ToInt32(txtID.Text));

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
    }
}
