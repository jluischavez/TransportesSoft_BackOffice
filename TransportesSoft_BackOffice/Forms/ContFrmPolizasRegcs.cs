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
using TransportesSoft_BackOffice.Models;
using TransportesSoft_BackOffice.Services;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class ContFrmPolizasRegcs : Base
    {
        Service_ContFrmPolizas service_ContFrmPolizas = new Service_ContFrmPolizas();
        List<ContTiposPolizas> lListTiposPolizas = new List<ContTiposPolizas>();
        int idUsuario = 0;

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

        public ContFrmPolizasRegcs(int Usuario)
        {
            idUsuario = Usuario;
            InitializeComponent();
            this.KeyPreview = true;
            txtID.TextChanged += txtID_TextChanged;
            CargarInformacionInicial();
        }
        private void CargarInformacionInicial()
        {
            try
            {
                lListTiposPolizas = service_ContFrmPolizas.ObtenerContTiposPolizas();
                CBTipoPoliza.Items.Clear();
                CBTipoPoliza.DataSource = lListTiposPolizas;
                CBTipoPoliza.DisplayMember = "TipoPoliza";
                CBTipoPoliza.ValueMember = "id";
                CBTipoPoliza.SelectedIndex = -1;
                CBTipoPoliza.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                DialogResult result = MessageBox.Show($"¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (CBTipoPoliza.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar un tipo de póliza.");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtFolioPoliza.Text))
                    {
                        MessageBox.Show("Debe ingresar un folio de Póliza.");
                        return;
                    }
                    if (DTFechaReg.Value >= DTFechaExp.Value)
                    {
                        MessageBox.Show("La fecha de registro no puede ser mayor a la fecha de expiración.");
                        return;
                    }
                    ContPolizasReg nuevaPoliza = new ContPolizasReg
                    {
                        FolioPoliza = txtFolioPoliza.Text.Trim(),
                        FechaRegistro = DTFechaReg.Value,
                        FechaExpira = DTFechaExp.Value,
                        idTipoPoliza = Convert.ToInt32(CBTipoPoliza.SelectedValue),
                        idUsuario = idUsuario
                    };
                    int idPoliza = 0;
                    if (EsConsulta)
                    {
                        nuevaPoliza.Id = Convert.ToInt32(txtID.Text);
                        // Aquí se llamaría al servicio para actualizar la póliza existente
                        service_ContFrmPolizas.ActualizarPoliza(nuevaPoliza);
                        MessageBox.Show($"La Póliza se actualizó exitosamente el ID: {nuevaPoliza.Id}.");
                    }
                    else
                    {
                        // Aquí se llamaría al servicio para guardar la nueva póliza
                        idPoliza = service_ContFrmPolizas.GuardarPoliza(nuevaPoliza);
                        MessageBox.Show($"La Póliza se guardó exitosamente el ID: {idPoliza}.");
                    }
                      
                    
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la póliza" + ex.Message);
            }
        }

        private void Limpiar()
        {
            txtFolioPoliza.Text = String.Empty;
            DTFechaReg.Value = DateTime.Now;
            DTFechaExp.Value = DateTime.Now;
            CBTipoPoliza.SelectedIndex = -1;
            txtID.Text = String.Empty;
            EsConsulta = false;
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
                    ContFrmBuscar frmBuscar = new ContFrmBuscar("Pólizas", ContFrmBuscar.TipoBusqueda.Polizas);
                    frmBuscar.MdiParent = this.MdiParent;

                    frmBuscar.FormBorderStyle = FormBorderStyle.FixedDialog;
                    frmBuscar.StartPosition = FormStartPosition.Manual;

                    int x = (this.MdiParent.ClientSize.Width - frmBuscar.Width) / 2;
                    int y = (this.MdiParent.ClientSize.Height - frmBuscar.Height) / 2;
                    frmBuscar.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

                    frmBuscar.PolizaSeleccionadaEvent += FrmBuscar_PolizaSeleccionada;

                    frmBuscar.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void FrmBuscar_PolizaSeleccionada(object sender, ContPolizasReg poliza)
        {
            txtID.Text = poliza.Id.ToString();
            txtFolioPoliza.Text = poliza.FolioPoliza;
            DTFechaReg.Value = poliza.FechaRegistro;
            DTFechaExp.Value = poliza.FechaExpira;
            CBTipoPoliza.SelectedValue = poliza.idTipoPoliza;

            EsConsulta = true;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_esConsulta)
                {
                    DialogResult result = MessageBox.Show($"¿Estás seguro que deseas eliminar la póliza {txtID.Text} - {txtFolioPoliza.Text}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        service_ContFrmPolizas.EliminarPoliza(Convert.ToInt32(txtID.Text));

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
