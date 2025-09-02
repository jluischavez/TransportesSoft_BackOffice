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
    public partial class ContFrmConsumosUnidades : Form
    {
        private List<ContConsumoUnidades> lContConsumoUnidades;
        private Service_ContConsumoUnidades lservContConsumoUnidades;
        private Service_ContUnidades lServContUnidades;
        private List<ContUnidades> lContUnidades;
        public ContFrmConsumosUnidades()
        {
            InitializeComponent();
            lservContConsumoUnidades = new Service_ContConsumoUnidades();
            lServContUnidades = new Service_ContUnidades();
            ObtenerUnidades();
            this.KeyPreview = true;
        }

        #region "Private"
        private void ObtenerUnidades()
        {
            try
            {
                lContConsumoUnidades = lservContConsumoUnidades.ObtenerContConsumoUnidades();
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
            txtConsumoEnPesos.Text = String.Empty;
            txtConsumoLitros.Text = String.Empty;
            CBUnidades.DataSource = null;


            ObtenerUnidades();
        }
        #endregion

        #region "Eventos"
        private void BTGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ContConsumoUnidades ObjConsumounidades = new ContConsumoUnidades();
                ObjConsumounidades.id_Unidad = Convert.ToInt32(CBUnidades.SelectedValue);
                ObjConsumounidades.Fecha = DTFecha.Value;
                ObjConsumounidades.ConsumoLitros = Convert.ToInt32(txtConsumoLitros.Text);
                ObjConsumounidades.ConsumoPesos = Convert.ToInt32(txtConsumoEnPesos.Text);
                ObjConsumounidades.Comentarios = txtComentarios.Text;

                lservContConsumoUnidades.GuardarConsumoUnidad(ObjConsumounidades);

                MessageBox.Show("Se guardó la unidad correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
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
        #endregion

    }
}
