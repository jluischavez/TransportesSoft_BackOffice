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
    public partial class ABCContFrmUnidades : Form
    {
        Service_ContUnidades lServiceContUnidades;
        Boolean esConsulta = false;
        Service_ContOperadores lServContOperadores;
        List<ContOperadores> lContOperadores;
        Service_ContRemolques lServiceContRemolques;
        List<ContRemolques> lContRemolques;
        public ABCContFrmUnidades()
        {
            InitializeComponent();
            lServiceContUnidades = new Service_ContUnidades();
            this.KeyPreview = true;
            this.StartPosition = FormStartPosition.Manual;
            ObtenerDatos();
            
        }
        private void ConfigurarFormulario()
        {
            txtKilometraje.Text = "0";
            txtProxMantenimiento.Text = "0";
        }
        private void ObtenerDatos()
        {
            /* Traemos Operadores y llenamos el ComboBox */
            lServContOperadores = new Service_ContOperadores();
            lContOperadores = lServContOperadores.ObtenerOperadores();
            CBOperadores.DataSource = lContOperadores;
            CBOperadores.DisplayMember = "Descripcion";
            CBOperadores.ValueMember = "id_Operador";
            CBOperadores.SelectedIndex = -1;

            /* Traemos Remolsques y llenamos el ComboBox*/
            lServiceContRemolques = new Service_ContRemolques();
            lContRemolques = lServiceContRemolques.ObtenerRemolques();
            CBRemolques.DataSource = lContRemolques;
            CBRemolques.DisplayMember = "Descripcion";
            CBRemolques.ValueMember = "id_Remolque";
            CBRemolques.SelectedIndex = -1;
        }
        
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (lServiceContUnidades.ValidarKilometraje(Convert.ToInt32(txtKilometraje.Text), Convert.ToInt32(txtProxMantenimiento.Text)))
                {
                    if (lServiceContUnidades.ValidarDatosObligatoriosGuardado(txtMarca.Text, txtSerie.Text))
                    {
                        ContUnidades unidad = new ContUnidades();
                        unidad.Marca = txtMarca.Text.ToUpper();
                        unidad.Kilometraje = Convert.ToInt32(txtKilometraje.Text);
                        unidad.Serie = txtSerie.Text.ToUpper();
                        unidad.ProximoMantenimiento = Convert.ToInt32(txtProxMantenimiento.Text);
                        unidad.id_Operador = Convert.ToInt32(CBOperadores.SelectedValue);
                        unidad.Estatus = "A";
                        unidad.id_Remolque = Convert.ToInt32(CBRemolques.SelectedValue);

                        if (esConsulta == false)
                        {
                            lServiceContUnidades.GuardarUnidad(unidad);
                        }
                        else
                        {
                            unidad.id_Unidad = Convert.ToInt32(txtID.Text);
                            lServiceContUnidades.ActualizarUnidad(unidad);
                        }
                        MessageBox.Show("Se guardó la unidad correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show($"Los valores Marca y Serie con obligatorios.");
                    }
                   
                }
                else
                {
                    MessageBox.Show($"Kilometraje actual: {txtKilometraje.Text}\nPróximo mantenimiento: {txtProxMantenimiento.Text}\n\nVerifica los valores ingresados.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Limpiar()
        {
            txtID.Text = String.Empty;
            txtKilometraje.Text = "0";
            txtMarca.Text = String.Empty;
            txtProxMantenimiento.Text = "0";
            txtSerie.Text = String.Empty;
            esConsulta = false;
            CBOperadores.DataSource = null;
            ObtenerDatos();
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                ContFrmBuscar frmBuscar = new ContFrmBuscar("Unidades", ContFrmBuscar.TipoBusqueda.ContUnidades);
                frmBuscar.MdiParent = this.MdiParent;

                frmBuscar.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmBuscar.StartPosition = FormStartPosition.Manual;

                int x = (this.MdiParent.ClientSize.Width - frmBuscar.Width) / 2;
                int y = (this.MdiParent.ClientSize.Height - frmBuscar.Height) / 2;
                frmBuscar.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

                frmBuscar.UnidadSeleccionadaEvent += FrmBuscar_UnidadSeleccionada;

                frmBuscar.Show();
            }
        }

        private void FrmBuscar_UnidadSeleccionada(object sender, ContUnidades unidad)
        {
            txtID.Text = unidad.id_Unidad.ToString();
            txtKilometraje.Text = unidad.Kilometraje.ToString();
            txtMarca.Text = unidad.Marca;
            CBOperadores.SelectedValue = unidad.id_Operador;
            txtProxMantenimiento.Text = unidad.ProximoMantenimiento.ToString();
            txtSerie.Text = unidad.Serie;
            esConsulta = true;
        }

        private void ABCContFrmUnidades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Limpiar(); 
                e.SuppressKeyPress = true; 
            }
        }

        private void txtKilometraje_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void ABCContFrmUnidades_Load(object sender, EventArgs e)
        {
            CBOperadores.DropDownStyle = ComboBoxStyle.DropDownList;
            CBRemolques.DropDownStyle = ComboBoxStyle.DropDownList;
            ConfigurarFormulario();
        }

        

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (esConsulta)
                {
                    DialogResult result = MessageBox.Show($"¿Estás seguro que deseas eliminar la unidad {txtID.Text} {txtSerie.Text}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        lServiceContUnidades.EliminarUnidad(Convert.ToInt32(txtID.Text));
                    }
                    Limpiar();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txtKilometraje_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKilometraje.Text))
                txtKilometraje.Text = "0";
        }

        private void txtProxMantenimiento_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProxMantenimiento.Text))
                txtProxMantenimiento.Text = "0";
        }
    }
}
