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
    public partial class ABCContFrmOperadores : Form
    {
        private Service_ContOperadores lServContOperadores;
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

        public ABCContFrmOperadores()
        {
            InitializeComponent();
            ConfiguracionFormulario();
            
        }
        #region "Private"
        private void ConfiguracionFormulario()
        {
            lServContOperadores = new Service_ContOperadores();
            this.KeyPreview = true;
            DTFechaIngreso.Value = new DateTime(1900, 1, 1);
            DTFechaEgreso.Value = new DateTime(1900, 1, 1);
            BtnEliminar.Enabled = false;
            EsConsulta = false;
        }
        private void FrmBuscar_OperadorSeleccionado(object sender, ContOperadores operador)
        {
            txtID.Text = operador.id_Operador.ToString();
            txtNombre.Text = operador.Nombre;
            DTFechaIngreso.Text = operador.FechaIngreso.ToString();
            DTFechaEgreso.Text = operador.FechaEgreso.ToString();
            EsConsulta = true;
        }
        private void Limpiar()
        {
            txtNombre.Text = String.Empty;
            txtID.Text = String.Empty;
            ConfiguracionFormulario();
        }
        private void GuardarOperador()
        {
            try
            {
                DialogResult result = MessageBox.Show($"¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (lServContOperadores.ValidarOperador(txtNombre.Text))
                    {
                        ContOperadores operador = new ContOperadores();
                        operador.Nombre = txtNombre.Text.ToUpper();
                        operador.FechaIngreso = DTFechaIngreso.Value;
                        operador.FechaEgreso = DTFechaEgreso.Value;
                        operador.Estatus = "A";

                        if (_esConsulta == false)
                        {
                            lServContOperadores.GuardarOperador(operador);
                        }
                        else
                        {
                            operador.id_Operador = Convert.ToInt32(txtID.Text);
                            lServContOperadores.ActualizarOperador(operador);
                        }
                        MessageBox.Show("Se guardó el operador correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpiar();
                       
                    }
                    else
                    {
                        MessageBox.Show($"El valor 'Nombre' es obligatorio.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region "Eventos"
        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    txtID.Clear(); 
                    e.SuppressKeyPress = true; 
                }
                else if (e.KeyCode == Keys.F3)
                {
                    ContFrmBuscar frmBuscar = new ContFrmBuscar("Operadores", ContFrmBuscar.TipoBusqueda.ContOperadores);
                    frmBuscar.MdiParent = this.MdiParent;

                    frmBuscar.FormBorderStyle = FormBorderStyle.FixedDialog;
                    frmBuscar.StartPosition = FormStartPosition.Manual;

                    int x = (this.MdiParent.ClientSize.Width - frmBuscar.Width) / 2;
                    int y = (this.MdiParent.ClientSize.Height - frmBuscar.Height) / 2;
                    frmBuscar.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

                    frmBuscar.OperadorSeleccionadoEvent += FrmBuscar_OperadorSeleccionado;

                    frmBuscar.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_esConsulta)
                {
                    DialogResult result = MessageBox.Show($"¿Estás seguro que deseas eliminar el operador {txtID.Text} - {txtNombre.Text}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        lServContOperadores.EliminarOperador(Convert.ToInt32(txtID.Text));
                        MessageBox.Show("Se eliminó correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarOperador();
        }
        private void ABCContFrmOperadores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Limpiar();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.G)
            {
                GuardarOperador();
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
