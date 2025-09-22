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
    public partial class ContFrmKilometrajeUnidades : Base
    {
        private Service_ContUnidadesCat lServiceUnidadesCat = new Service_ContUnidadesCat();
        private Service_ContKilometrajeUnidad lServiceContKilometrajeUnidad = new Service_ContKilometrajeUnidad();
        Label LblNotificacion;
        public ContFrmKilometrajeUnidades()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        #region "Private"
        private void ConfiguracionInicial()
        {
            List<ContUnidadesCat> listaUnidades = lServiceUnidadesCat.ObtenerTodasUnidadesActivas();
            CBUnidades.DisplayMember = "Descripcion";
            CBUnidades.ValueMember = "Id_Unidad";
            CBUnidades.DataSource = listaUnidades;

            CBUnidades.SelectedIndex = -1;
            CBUnidades.DropDownStyle = ComboBoxStyle.DropDownList;
            LblKilometrajeActual.Text = "Kilometraje Actual: ";

        }

        private void Limpiar()
        {
            txtKilometraje.Clear();
            DTFecha.Value = DateTime.Now;
            CBUnidades.SelectedIndex = -1;
            ConfiguracionInicial();
        }
        private bool ValidarInformacion(int idUnidad, int Kilometraje)
        {
            if(idUnidad == 0)
            {
                MessageBox.Show("Debe seleccionar una unidad", "Informacion",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if(Kilometraje == 0)
            {
                MessageBox.Show("El Kilometraje no puede ser 0", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void GuardarKilometraje()
        {
            try
            {
                DialogResult result = MessageBox.Show($"¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes && ValidarInformacion(Convert.ToInt32(CBUnidades.SelectedValue),Convert.ToInt32(txtKilometraje.Text)))
                {

                    ContKilometrajeUnidad objKilometraje = new ContKilometrajeUnidad
                    {
                        Id_Unidad = Convert.ToInt32(CBUnidades.SelectedValue),
                        KilometrajeActual = Convert.ToInt32(txtKilometraje.Text),
                        FechaRegistro = DTFecha.Value
                    };

                    lServiceContKilometrajeUnidad.GuardarKilometrajeUnidad(objKilometraje);

                    Limpiar();
                    MessageBox.Show("Kilometraje guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            GuardarKilometraje();
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
                GuardarKilometraje();
            }
        }
        private void CBUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            int kilometrajeUnidad = lServiceContKilometrajeUnidad.ObtenerKilometrajeActualPorUnidad(Convert.ToInt32(CBUnidades.SelectedValue));
            LblKilometrajeActual.Text = "Kilometraje Actual: " + kilometrajeUnidad.ToString();
        }
        private void txtKilometraje_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos (0-9) y teclas de control como Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }
        #endregion


    }
}
