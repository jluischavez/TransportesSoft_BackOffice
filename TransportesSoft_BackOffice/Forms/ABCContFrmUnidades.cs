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
        public ABCContFrmUnidades()
        {
            InitializeComponent();
            lServiceContUnidades = new Service_ContUnidades();
            this.KeyPreview = true;
            this.StartPosition = FormStartPosition.Manual;
            ObtenerDatos();
        }
        private void ObtenerDatos()
        {
            /* Traemos Operadores y llenamos el ComboBox */
            lServContOperadores = new Service_ContOperadores();
            lContOperadores = lServContOperadores.ObtenerOperadores();
            CBOperadores.DataSource = lContOperadores;
            CBOperadores.DisplayMember = "Descripcion";
            CBOperadores.ValueMember = "id_Operador";
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!ValidarKilometraje(Convert.ToInt32(txtKilometraje.Text), Convert.ToInt32(txtProxMantenimiento.Text)))
                {
                    ContUnidades unidad = new ContUnidades();
                    unidad.Marca = txtMarca.Text.ToUpper();
                    unidad.Kilometraje = Convert.ToInt32(txtKilometraje.Text);
                    unidad.Serie = txtSerie.Text.ToUpper();
                    unidad.ProximoMantenimiento = Convert.ToInt32(txtProxMantenimiento.Text);
                    unidad.id_Operador = Convert.ToInt32(CBOperadores.SelectedValue);
                    unidad.id_Unidad = Convert.ToInt32(txtID.Text);

                    if (esConsulta == false)
                    {
                        lServiceContUnidades.GuardarUnidad(unidad);
                    }
                    else
                    {
                        lServiceContUnidades.ActualizarUnidad(unidad);
                    }
                    MessageBox.Show("Se guardó la unidad correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiar();
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
            txtKilometraje.Text = String.Empty;
            txtMarca.Text = String.Empty;
            txtProxMantenimiento.Text = String.Empty;
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
                frmBuscar.FormBorderStyle = FormBorderStyle.Sizable;

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
        }

        private bool ValidarKilometraje(int kilometraje, int proximomantenimiento)
        {
            // Si ProximoMantenimiento es 0, se permite cualquier kilometraje
            if (proximomantenimiento == 0)
                return true;

            // Si no, el kilometraje debe ser mayor o igual
            return kilometraje >= proximomantenimiento;
        }
    }
}
