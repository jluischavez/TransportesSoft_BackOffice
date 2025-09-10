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
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class ABCFrmMunicipios : Base
    {
        Service_MunicipiosCat lServiceMunicipios;
        List<EstadosCat> lEstados;

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
        public ABCFrmMunicipios()
        {
            InitializeComponent();
            lServiceMunicipios = new Service_MunicipiosCat();
            ConfiguracionInicial();
        }
        public void ConfiguracionInicial()
        {
            Service_EstadosCat lServiceEstados = new Service_EstadosCat();
            lEstados = lServiceEstados.ObtenerEstados();
            CBEstados.DataSource = lEstados;
            CBEstados.DisplayMember = "Nombre";
            CBEstados.ValueMember = "idEstado";
            CBEstados.SelectedIndex = -1;

            EsConsulta = false;
            BtnEliminar.Enabled = false;
            this.KeyPreview = true;
        }
        private void FrmBuscar_MunicipioSeleccionado(object sender, MunicipiosCat municipio)
        {
            txtID.Text = municipio.IdMunicipio.ToString();
            txtNombreMunicipio.Text = municipio.Nombre.ToString();
            TxtClaveInegi.Text = municipio.ClaveInegi;
            CBEstados.SelectedValue = municipio.IdEstado;
            EsConsulta = true;
        }

        private void GuadarMunicipio()
        {
            DialogResult result = MessageBox.Show($"¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MunicipiosCat municipio = new MunicipiosCat();

                municipio.Nombre = txtNombreMunicipio.Text.Trim();
                municipio.IdEstado = (int)CBEstados.SelectedValue;
                municipio.ClaveInegi = TxtClaveInegi.Text.Trim();
                municipio.Activo = true;
                

                if (_esConsulta == false)
                {
                    lServiceMunicipios.GuardarMunicipio(municipio);
                }
                else
                {
                    municipio.IdMunicipio = Convert.ToInt32(txtID.Text);
                    lServiceMunicipios.ActualizarMunicipio(municipio);
                }
                MessageBox.Show("Se guardó el municipio correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Limpiar();
            }
        }

        private void Limpiar()
        {
            txtID.Text = String.Empty;
            TxtClaveInegi.Text = string.Empty;
            txtNombreMunicipio.Text = String.Empty;
            EsConsulta = false;
            CBEstados.DataSource = null;
            ConfiguracionInicial();
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuadarMunicipio();
        }

        private void ABCFrmMunicipios_Load(object sender, EventArgs e)
        {
            CBEstados.DropDownStyle = ComboBoxStyle.DropDownList;
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
                ContFrmBuscar frmBuscar = new ContFrmBuscar("Municipios", ContFrmBuscar.TipoBusqueda.MunicipiosCat);
                frmBuscar.MdiParent = this.MdiParent;

                frmBuscar.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmBuscar.StartPosition = FormStartPosition.Manual;

                int x = (this.MdiParent.ClientSize.Width - frmBuscar.Width) / 2;
                int y = (this.MdiParent.ClientSize.Height - frmBuscar.Height) / 2;
                frmBuscar.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

                frmBuscar.MunicipioSeleccionadoEvent += FrmBuscar_MunicipioSeleccionado;

                frmBuscar.Show();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_esConsulta)
                {
                    DialogResult result = MessageBox.Show($"¿Estás seguro que deseas eliminar el municipio {txtID.Text} {txtNombreMunicipio.Text}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        lServiceMunicipios.EliminarMunicipio(Convert.ToInt32(txtID.Text));
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

        private void ABCFrmMunicipios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Limpiar();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.G)
            {
                GuadarMunicipio();
            }
        }

        private void TxtClaveInegi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }
    }
}
