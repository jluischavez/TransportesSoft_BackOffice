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
    public partial class ContFrmViajes : Form
    {
        private Service_ContClientes lServiceClientes;
        private Service_Municipios lServiceMunicipios;
        private Service_ContOperadores lServiceOperadores;
        private Service_ContUnidades lServiceUnidades;
        private Service_ContViajes lServiceViajes;

        private List<ContClientes> lListContClientes;
        private List<Municipios> lListMunicipios;
        private List<ContOperadores> lListOperadores;

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
                    txtFolioFactura.Enabled = !_esConsulta;
                    txtNumeroTransporte.Enabled = !_esConsulta;
                }
            }
        }

        public ContFrmViajes()
        {
            InitializeComponent();
            Limpiar();
            this.KeyPreview = true;
        }
        #region "Private"
        private void Limpiar()
        {
            ConfiguracionFormulario();
            DTFechaFactura.Value = DateTime.Now;
            DTFechaViaje.Value = DateTime.Now;
            txtFolioFactura.Text = String.Empty;
            txtID.Text = string.Empty;

            txtNumeroTransporte.Text = String.Empty;
            txtMonto.Text = "0.00";
            txtIVA.Text = "0.00";
            txtManiobra.Text = "0.00";
            txtRetenciones.Text = "0.00";
            txtTotal.Text = "0.00";

            txtComentarios.Text = String.Empty;
            lServiceViajes = new Service_ContViajes();

            EsConsulta = false;
        }
        private void ConfiguracionFormulario()
        {
            try
            {
                /*Llenar Combo Clientes*/
                lServiceClientes = new Service_ContClientes();
                lListContClientes = new List<ContClientes>();
                lListContClientes = lServiceClientes.ObtenerClientesActivos();
                CBClientes.DataSource = lListContClientes;
                CBClientes.DisplayMember = "Descripcion";
                CBClientes.ValueMember = "id_Client";
                CBClientes.SelectedIndex = -1;
                CBClientes.DropDownStyle = ComboBoxStyle.DropDownList;

                /*Llenar Combos Origen y Destino*/
                lServiceMunicipios = new Service_Municipios();
                lListMunicipios = new List<Municipios>();
                lListMunicipios = lServiceMunicipios.ObtenerMunicipios();
                CBOrigen.DataSource = lListMunicipios;
                CBOrigen.DisplayMember = "Nombre";
                CBOrigen.ValueMember = "idMunicipio";
                CBOrigen.SelectedIndex = -1;
                CBOrigen.DropDownStyle = ComboBoxStyle.DropDownList;

                CBDestino.DataSource = new List<Municipios>(lListMunicipios);
                CBDestino.DisplayMember = "Nombre";
                CBDestino.ValueMember = "idMunicipio";
                CBDestino.SelectedIndex = -1;
                CBDestino.DropDownStyle = ComboBoxStyle.DropDownList;

                /*Llenar ComboOperadores*/
                lServiceOperadores = new Service_ContOperadores();
                lListOperadores = new List<ContOperadores>();
                lListOperadores = lServiceOperadores.ObtenerOperadoresActivos();
                CBOperadores.DataSource = lListOperadores;
                CBOperadores.DisplayMember = "Descripcion";
                CBOperadores.ValueMember = "id_Operador";
                CBOperadores.SelectedIndex = -1;
                CBOperadores.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CalcularTotales()
        {
            decimal Monto = Convert.ToDecimal(txtMonto.Text);
            decimal IVA = Convert.ToDecimal(txtIVA.Text);
            decimal Retenciones = Convert.ToDecimal(txtRetenciones.Text);
            decimal Maniobra = Convert.ToDecimal(txtManiobra.Text);
            decimal total = Monto + IVA - Retenciones - Maniobra;

            txtTotal.Text = total.ToString();
        }
        private bool GuardarViaje()
        {
            try
            {
                DialogResult result = MessageBox.Show($"¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ContViajes objViaje = new ContViajes();

                    objViaje.id_Client = Convert.ToInt32(CBClientes.SelectedValue);

                    // Buscar el cliente en la lista original
                    ContClientes clienteSeleccionado = lListContClientes
                        .FirstOrDefault(c => c.id_Client == Convert.ToInt32(CBClientes.SelectedValue));
                    objViaje.NombreCliente = clienteSeleccionado?.Nombre ?? string.Empty;

                    objViaje.FechaViaje = DTFechaViaje.Value;
                    objViaje.FechaFactura = DTFechaFactura.Value;
                    if (!lServiceViajes.ValidarFolioFactura(txtFolioFactura.Text) && !_esConsulta)
                    {
                        MessageBox.Show($"El FolioFactura {txtFolioFactura.Text} ya fue registrado anteriormente.","Error al guardar.", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                        return false;
                    }
                    objViaje.Factura = txtFolioFactura.Text;

                    if (!lServiceViajes.ValidarNumeroTransporte(Convert.ToInt32(txtNumeroTransporte.Text)) && !_esConsulta)
                    {
                        MessageBox.Show($"El NumeroTransporte {txtNumeroTransporte.Text} ya fue registrado anteriormente.", "Error al guardar.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                        objViaje.NumeroTransporte = Convert.ToInt32(txtNumeroTransporte.Text);

                    /*DESTINO Y ORIGEN*/
                    Municipios OrigenSeleccionado = lListMunicipios
                        .FirstOrDefault(c => c.idMunicipio == Convert.ToInt32(CBOrigen.SelectedValue));
                    objViaje.Origen = OrigenSeleccionado?.Nombre ?? String.Empty;
                    Municipios DestinoSeleccionado = lListMunicipios
                        .FirstOrDefault(c => c.idMunicipio == Convert.ToInt32(CBDestino.SelectedValue));
                    objViaje.Destino = DestinoSeleccionado?.Nombre ?? String.Empty;

                    /* COSTOS $$ */
                    objViaje.Monto = Convert.ToDecimal(txtMonto.Text);
                    objViaje.IVA = Convert.ToDecimal(txtIVA.Text);
                    objViaje.Retenciones = Convert.ToDecimal(txtRetenciones.Text);
                    objViaje.Maniobra = Convert.ToDecimal(txtManiobra.Text);
                    objViaje.Total = Convert.ToDecimal(txtTotal.Text);

                    objViaje.id_Operador = Convert.ToInt32(CBOperadores.SelectedValue);

                    objViaje.Comentarios = txtComentarios.Text;

                    /*Consulta datos de unidad y remolque*/
                    lServiceUnidades = new Service_ContUnidades();
                    ContUnidades objUnidad = lServiceUnidades.UnidadPorID(objViaje.id_Operador);
                    objViaje.id_Unidad = objUnidad.id_Unidad;
                    objViaje.id_Remolque = objUnidad.id_Remolque;

                    if (ValidarInfoGuardado(objViaje))
                    {
                        if (!_esConsulta)
                        {
                            lServiceViajes.GuardarViaje(objViaje);
                        }
                        else
                        {
                            objViaje.id_viaje = Convert.ToInt32(txtID.Text);
                            lServiceViajes.ActualizarViaje(objViaje);
                        }
                        MessageBox.Show("Se guardó el viaje correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private bool ValidarInfoGuardado(ContViajes objViaje)
        {
            if (objViaje.id_Client == 0)
                return false;

            if (string.IsNullOrEmpty(objViaje.NombreCliente))
                return false;

            if (DTFechaViaje.Value.Date == new DateTime(1900-1-1) || DTFechaFactura.Value.Date == new DateTime(1900 - 1 - 1))
                return false;
            if (string.IsNullOrEmpty(objViaje.Factura))
                return false;
            if (objViaje.NumeroTransporte == 0)
                return false;
            if (string.IsNullOrEmpty(objViaje.Origen) || string.IsNullOrEmpty(objViaje.Destino))
                return false;
            if (objViaje.Monto <=0 || objViaje.Total <= 0)
                return false;
            if (objViaje.id_Operador == 0)
                return false;
            if (objViaje.id_Unidad == 0 || objViaje.id_Remolque == 0)
            {
                MessageBox.Show($"El operador debe tener una unidad y un remolque asignados.", "Error al guardar.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void FrmBuscar_ViajeSeleccionado(object sender, ContViajes viaje)
        {
            txtID.Text = viaje.id_viaje.ToString();
            CBClientes.SelectedValue = viaje.id_Client;
            DTFechaViaje.Value = viaje.FechaViaje;
            DTFechaFactura.Value = viaje.FechaFactura;
            txtFolioFactura.Text = viaje.Factura;
            txtNumeroTransporte.Text = viaje.NumeroTransporte.ToString();
            CBOrigen.SelectedIndex = CBOrigen.FindStringExact(viaje.Origen);
            CBDestino.SelectedIndex = CBDestino.FindStringExact(viaje.Destino);
            txtMonto.Text = viaje.Monto.ToString("N2");
            txtIVA.Text = viaje.IVA.ToString("N2");
            txtRetenciones.Text = viaje.Retenciones.ToString("N2");
            txtManiobra.Text = viaje.Maniobra.ToString("N2");
            txtTotal.Text = viaje.Total.ToString("N2");
            CBOperadores.SelectedValue = viaje.id_Operador;
            txtComentarios.Text = viaje.Comentarios;
            EsConsulta = true;
        }
        #endregion
        #region "Eventos"
        private void txtNumeroTransporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtNumeroTransporte_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (decimal.TryParse(txt.Text, out decimal valor))
            {
                txt.Text = valor.ToString("N2");
            }
            else
            {
                txt.Text = "0.00";
            }
        }

        private void ContFrmViajes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Limpiar();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.G)
            {
                BtnGuardar.Focus();
                GuardarViaje();
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarViaje();
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_esConsulta)
                {
                    DialogResult result = MessageBox.Show($"¿Estás seguro que deseas eliminar el viaje {txtID.Text}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        lServiceViajes.EliminarViaje(Convert.ToInt32(txtID.Text));

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

        private void ContFrmViajes_Load(object sender, EventArgs e)
        {
            /*Establece estado del btnEliminar*/
            EsConsulta = false;
            BtnEliminar.Enabled = false;
        }
        private void txtMonto_Validating(object sender, CancelEventArgs e)
        {
            CalcularTotales();
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
                    ContFrmBusquedaViajes frmBuscar = new ContFrmBusquedaViajes();
                    frmBuscar.MdiParent = this.MdiParent;

                    frmBuscar.FormBorderStyle = FormBorderStyle.FixedDialog;
                    frmBuscar.StartPosition = FormStartPosition.Manual;

                    int x = (this.MdiParent.ClientSize.Width - frmBuscar.Width) / 2;
                    int y = (this.MdiParent.ClientSize.Height - frmBuscar.Height) / 2;
                    frmBuscar.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

                    frmBuscar.ViajeSeleccionadoEvent += FrmBuscar_ViajeSeleccionado;

                    frmBuscar.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

    }
}
