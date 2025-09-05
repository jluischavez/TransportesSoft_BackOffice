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

            txtNumeroTransporte.Text = String.Empty;
            txtMonto.Text = "0.00";
            txtIVA.Text = "0.00";
            txtManiobra.Text = "0.00";
            txtRetenciones.Text = "0.00";
            txtTotal.Text = "0.00";

            txtComentarios.Text = String.Empty;
            lServiceViajes = new Service_ContViajes();
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
            decimal total = Monto - IVA - Retenciones - Maniobra;

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
                    if (!lServiceViajes.ValidarFolioFactura(txtFolioFactura.Text))
                    {
                        MessageBox.Show($"El FolioFactura {txtFolioFactura.Text} ya fue registrado anteriormente.","Error al guardar.", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                        return false;
                    }
                    objViaje.Factura = txtFolioFactura.Text;

                    if (!lServiceViajes.ValidarNumeroTransporte(Convert.ToInt32(txtNumeroTransporte.Text)))
                    {
                        MessageBox.Show($"El NumeroTransporte {txtNumeroTransporte.Text} ya fue registrado anteriormente.", "Error al guardar.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                        objViaje.NumeroTansporte = Convert.ToInt32(txtNumeroTransporte.Text);

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
                        lServiceViajes.GuardarViaje(objViaje);
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
            if (objViaje.NumeroTansporte == 0)
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
        #endregion

        private void txtMonto_Validating(object sender, CancelEventArgs e)
        {
            CalcularTotales();
        }
    }
}
