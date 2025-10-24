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

        public ContFrmPreciosDiesel()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        #region "Private"
        private void ConfiguracionInicial()
        {
            try
            {
                 ContPreciosDiesel preciosDiesel = new ContPreciosDiesel();
            lServiceContPreciosDiesel = new Service_ContPreciosDiesel();
            preciosDiesel = lServiceContPreciosDiesel.PrecioActualDiesel();

                if (preciosDiesel != null && preciosDiesel.Precio != 0)
                {
                    LblPrecioActual.Text = "Precio Actual: " + preciosDiesel.Precio.ToString("F2");
                }
                else
                {
                    LblPrecioActual.Text = "Precio Actual: 0.00";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
           
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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos (0-9) y teclas de control como Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }
    }
}
