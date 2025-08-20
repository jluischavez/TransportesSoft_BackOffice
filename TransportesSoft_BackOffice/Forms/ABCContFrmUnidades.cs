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

        public ABCContFrmUnidades()
        {
            InitializeComponent();
            lServiceContUnidades = new Service_ContUnidades();
            this.KeyPreview = true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ContUnidades unidad = new ContUnidades();
                unidad.Marca = txtMarca.Text;
                unidad.Kilometraje = Convert.ToInt32(txtKilometraje.Text);
                unidad.Serie = txtSerie.Text;
                unidad.ProximoMantenimiento = Convert.ToInt32(txtProxMantenimiento.Text);
                unidad.id_Operador = 1;

                if (esConsulta == false)
                {
                    lServiceContUnidades.GuardarUnidad(unidad);
                }
                else
                {

                }
                
                MessageBox.Show("Se guardó la unidad correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
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
            txtOperador.Text = String.Empty;
            txtProxMantenimiento.Text = String.Empty;
            txtSerie.Text = String.Empty;
            esConsulta = false;
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                ContFrmBuscar frmBuscar = new ContFrmBuscar("Unidades");
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
            txtOperador.Text = unidad.id_Operador.ToString();
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
    }
}
