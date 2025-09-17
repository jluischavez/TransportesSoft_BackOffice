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
    public partial class ContFrmConsumosUnidades : Form
    {
        //private List<ContConsumoUnidades> lContConsumoUnidades;
        private Service_ContConsumoUnidades lservContConsumoUnidades;
        private Service_ContUnidadesCat lServContUnidades;
        private Service_ContPreciosDiesel lServiceContPreciosDiesel;

        private List<ContUnidadesCat> lContUnidades;

        private ContPreciosDiesel lPrecioDiesel;
        public ContFrmConsumosUnidades()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        #region "Private"
        private void CalcularPrecioDiesel()
        {
            Decimal litros = Convert.ToDecimal(txtConsumoLitros.Text);
            Decimal precio = lPrecioDiesel.Precio;
            txtConsumoEnPesos.Text = (litros * precio).ToString("F2");
        }
        private void ConfiguracionInicial()
        {
            try
            {
                lservContConsumoUnidades = new Service_ContConsumoUnidades();
                lServContUnidades = new Service_ContUnidadesCat();
                lServiceContPreciosDiesel = new Service_ContPreciosDiesel();
                lPrecioDiesel = lServiceContPreciosDiesel.PrecioActualDiesel();
                if (lPrecioDiesel == null)
                {
                    MessageBox.Show("No se ha encontrado un precio de diesel registrado, por favor registre uno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                LblPrecioActual.Text = "Precio Actual: " + lPrecioDiesel.Precio.ToString("F2");
                txtConsumoLitros.Text = "0";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al consultar: ", "Error" + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ObtenerUnidades()
        {
            try
            {
                //lContConsumoUnidades = lservContConsumoUnidades.ObtenerContConsumoUnidades();
                lContUnidades = lServContUnidades.ObtenerUnidades();
                CBUnidades.DataSource = lContUnidades;
                CBUnidades.DisplayMember = "Descripcion";
                CBUnidades.ValueMember = "id_Unidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar: ", "Error" + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Limpiar()
        {
            DTFecha.Value = DateTime.Now;
            txtComentarios.Text = String.Empty;
            txtConsumoEnPesos.Text = "0";
            txtConsumoLitros.Text = "0";
            CBUnidades.DataSource = null;


            ObtenerUnidades();
        }
        private Boolean validarConsumo(ContConsumoUnidades consumo)
        {
            if (consumo.id_Unidad == 0)
                return false;
            else if (consumo.ConsumoLitros == 0)
                return false;
            else if (consumo.ConsumoPesos == 0)
                return false;

                return true;
        }
        #endregion

        #region "Eventos"
        private void BTGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show($"¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ContConsumoUnidades ObjConsumounidades = new ContConsumoUnidades();
                    ObjConsumounidades.id_Unidad = Convert.ToInt32(CBUnidades.SelectedValue);
                    ObjConsumounidades.Fecha = DTFecha.Value;
                    ObjConsumounidades.ConsumoLitros = Convert.ToInt32(txtConsumoLitros.Text);
                    ObjConsumounidades.ConsumoPesos = Convert.ToDecimal(txtConsumoEnPesos.Text);
                    ObjConsumounidades.Comentarios = txtComentarios.Text;

                    if (validarConsumo(ObjConsumounidades))
                        lservContConsumoUnidades.GuardarConsumoUnidad(ObjConsumounidades);
                    else
                    {
                        MessageBox.Show("Verificar información antes de guardar.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    MessageBox.Show("Se guardó correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al guardar: ", "Error" + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void ContFrmConsumosUnidades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Limpiar();
            }
        }

        private void txtConsumoLitros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void txtConsumoEnPesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void ContFrmConsumosUnidades_Load(object sender, EventArgs e)
        {
            CBUnidades.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void txtConsumoLitros_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void ContFrmConsumosUnidades_Shown(object sender, EventArgs e)
        {
            ConfiguracionInicial();
            ObtenerUnidades();
        }

        #endregion

        private void txtConsumoLitros_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtConsumoLitros.Text, out decimal litros))
            {
                if (litros < 0)
                {
                    txtConsumoLitros.Text = "0";
                    MessageBox.Show("El consumo no puede ser negativo. Se ha ajustado a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                txtConsumoLitros.Text = "0";
                MessageBox.Show("Por favor ingresa un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CalcularPrecioDiesel(); // Se ejecuta solo cuando el campo ya está validado
        }
    }
}
