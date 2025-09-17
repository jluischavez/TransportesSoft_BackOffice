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
        Service_ContUnidadesCat lServiceContUnidades;
        Service_ContOperadoresCat lServContOperadores;
        List<ContOperadores> lContOperadores;
        Service_ContRemolquesCat lServiceContRemolques;
        List<ContRemolquesCat> lContRemolques;


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
                }
            }
        }
        public ABCContFrmUnidades()
        {
            InitializeComponent();
            lServiceContUnidades = new Service_ContUnidadesCat();
            this.KeyPreview = true;
            this.StartPosition = FormStartPosition.Manual;
            ObtenerDatos();
            
        }
        #region "Private"
        private void ConfigucionFormulario()
        {
            EsConsulta = false;
            BtnEliminar.Enabled = false;
        }
        private void ObtenerDatos()
        {
            /* Traemos Operadores y llenamos el ComboBox */
            lServContOperadores = new Service_ContOperadoresCat();
            lContOperadores = lServContOperadores.ObtenerOperadores();
            CBOperadores.DataSource = lContOperadores;
            CBOperadores.DisplayMember = "Descripcion";
            CBOperadores.ValueMember = "id_Operador";
            CBOperadores.SelectedIndex = -1;

            /* Traemos Remolques y llenamos el ComboBox*/
            lServiceContRemolques = new Service_ContRemolquesCat();
            lContRemolques = lServiceContRemolques.ObtenerRemolques();
            CBRemolques.DataSource = lContRemolques;
            CBRemolques.DisplayMember = "Descripcion";
            CBRemolques.ValueMember = "id_Remolque";
            CBRemolques.SelectedIndex = -1;
        }
        
    

        private void GuardarUnidad()
        {
            try
            {
                DialogResult result = MessageBox.Show($"¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                        if (lServiceContUnidades.ValidarDatosObligatoriosGuardado(txtMarca.Text, txtSerie.Text))
                        {
                            ContUnidadesCat unidad = new ContUnidadesCat();
                            unidad.Marca = txtMarca.Text.ToUpper();
                            unidad.Serie = txtSerie.Text.ToUpper();
                            unidad.id_Operador = Convert.ToInt32(CBOperadores.SelectedValue);
                            unidad.Estatus = "A";
                            unidad.id_Remolque = Convert.ToInt32(CBRemolques.SelectedValue);

                            if (_esConsulta == false)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Limpiar()
        {
            txtID.Text = String.Empty;
            txtMarca.Text = String.Empty;
            txtSerie.Text = String.Empty;
            EsConsulta = false;
            CBOperadores.DataSource = null;
            CBRemolques.DataSource = null;
            ObtenerDatos();
        }
        private void FrmBuscar_UnidadSeleccionada(object sender, ContUnidadesCat unidad)
        {
            txtID.Text = unidad.id_Unidad.ToString();
            txtMarca.Text = unidad.Marca;
            CBOperadores.SelectedValue = unidad.id_Operador;
            txtSerie.Text = unidad.Serie;
            CBRemolques.SelectedValue = unidad.id_Remolque;
            EsConsulta = true;
        }
        #endregion
        #region "Eventos"
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarUnidad();
        }
        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txtID.Clear(); // Borra todo el texto
                e.SuppressKeyPress = true; // Opcional: evita que el sonido de tecla se reproduzca
            }
            else if (e.KeyCode == Keys.F3)
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

        private void ABCContFrmUnidades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Limpiar(); 
                e.SuppressKeyPress = true; 
            }
            else if (e.Control && e.KeyCode == Keys.G) 
            {
                GuardarUnidad();
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
            ConfigucionFormulario();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_esConsulta)
                {
                    DialogResult result = MessageBox.Show($"¿Estás seguro que deseas eliminar la unidad {txtID.Text} {txtSerie.Text}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        lServiceContUnidades.EliminarUnidad(Convert.ToInt32(txtID.Text));
                        MessageBox.Show("Se eliminó correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Limpiar();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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
        #endregion
    }
}
