using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportesSoft_BackOffice.Models;
using TransportesSoft_BackOffice.Services;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class ContFrmPreciosDiesel : Base
    {
        Service_ContPreciosDiesel lServiceContPreciosDiesel;

        private Boolean _esConsulta;

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
        public ContFrmPreciosDiesel()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        #region "Private"
        private void ConfiguracionInicial()
        {
            ContPreciosDiesel preciosDiesel = new ContPreciosDiesel();
            lServiceContPreciosDiesel = new Service_ContPreciosDiesel();
            preciosDiesel = lServiceContPreciosDiesel.PrecioActualDiesel();
            LblPrecioActual.Text = "Precio Actual: " + preciosDiesel.Precio.ToString("F2");
        }

        private void Limpiar()
        {
            txtPrecio.Text = string.Empty;
            ConfiguracionInicial();
        }
        private void GuardarPrecioDiesel()
        {
            try
            {
                DialogResult result = MessageBox.Show($"¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    lServiceContPreciosDiesel = new Service_ContPreciosDiesel();
                    ContPreciosDiesel preciosDiesel = new ContPreciosDiesel();

                    preciosDiesel.Precio = Convert.ToDecimal(txtPrecio.Text);
                    preciosDiesel.FechaExpiro = new DateTime(1900, 1, 1);
                    preciosDiesel.FechaRegistro = DateTime.Now;
                    lServiceContPreciosDiesel.GuardarPrecioDiesel(preciosDiesel);
                    Limpiar();
                    MessageBox.Show("Precio guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.InnerException, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region "Eventos"
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPrecioDiesel();
        }

        private void ContFrmPreciosDiesel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Limpiar();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.G)
            {
                GuardarPrecioDiesel();
            }
        }
        #endregion
    }
}
