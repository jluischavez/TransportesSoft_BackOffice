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
    public partial class ABCContFrmRemolques : Base
    {
        private Service_ContRemolquesCat lServiceContRemolques;
        private ContRemolquesCat lContRemolques;
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

        public ABCContFrmRemolques()
        {
            InitializeComponent();
            this.KeyPreview = true;
            lServiceContRemolques = new Service_ContRemolquesCat();
            ConfiguraFormulario();
        }
        #region "Private"
        private void ConfiguraFormulario()
        {
            /*Llena el combo años*/
            int AnioActual = DateTime.Now.Year;
            List<int> listAnios = new List<int>();
            for (int i = 1990; i <= AnioActual; i++)
            {
                listAnios.Add(i);
            }
            CBOYear.DataSource = listAnios;

            /*Establece estado del btnEliminar*/
            EsConsulta = false;
            BtnEliminar.Enabled = false;
        }

        private void Limpiar()
        {
            txtID.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtSerie.Text = string.Empty;
            CBOYear.Text = "1990";
            txtPlacas.Text = string.Empty;
            DTFechaLlantas.Text = DateTime.Now.ToString();
            DTFechaFisicoSCT.Text = DateTime.Now.ToString();
            DTImpermeabilizacion.Text = DateTime.Now.ToString();
            EsConsulta = false;
        }
        private void FrmBuscar_RemolqueSeleccionado(object sender, ContRemolquesCat remolque)
        {
            txtID.Text = remolque.id_Remolque.ToString();
            txtMarca.Text = remolque.Marca;
            txtModelo.Text = remolque.Modelo;
            txtSerie.Text = remolque.Serie;
            CBOYear.Text = remolque.Year.ToString();
            txtPlacas.Text = remolque.Placas;
            DTFechaLlantas.Text = remolque.Fecha_Llantas.ToString();
            DTFechaFisicoSCT.Text = remolque.Fecha_Fisico_SCT.ToString();
            DTImpermeabilizacion.Text = remolque.Impermeabilizacion.ToString();
            EsConsulta = true;
        }
        #endregion
        #region "Eventos"
        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F3)
                {
                    ContFrmBuscar frmBuscar = new ContFrmBuscar("Remolques", ContFrmBuscar.TipoBusqueda.ContRemolques);
                    frmBuscar.MdiParent = this.MdiParent;

                    frmBuscar.FormBorderStyle = FormBorderStyle.FixedDialog;
                    frmBuscar.StartPosition = FormStartPosition.Manual;

                    int x = (this.MdiParent.ClientSize.Width - frmBuscar.Width) / 2;
                    int y = (this.MdiParent.ClientSize.Height - frmBuscar.Height) / 2;
                    frmBuscar.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

                    frmBuscar.RemolqueSeleccionadoEvent += FrmBuscar_RemolqueSeleccionado;

                    frmBuscar.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lContRemolques = new ContRemolquesCat();
                lContRemolques.Marca = txtMarca.Text.ToUpper();
                lContRemolques.Modelo = txtModelo.Text.ToUpper();
                lContRemolques.Serie = txtSerie.Text.ToUpper();
                lContRemolques.Year = Convert.ToInt32(CBOYear.Text);
                lContRemolques.Placas = txtPlacas.Text.ToUpper();
                lContRemolques.Fecha_Llantas = DTFechaLlantas.Value;
                lContRemolques.Fecha_Fisico_SCT = DTFechaFisicoSCT.Value;
                lContRemolques.Impermeabilizacion = DTImpermeabilizacion.Value;

                if (!_esConsulta)
                {
                    lServiceContRemolques.GuardarRemolque(lContRemolques);
                }
                else
                {
                    lContRemolques.id_Remolque = Convert.ToInt32(txtID.Text);
                    lServiceContRemolques.ActualizarRemolque(lContRemolques);
                }

                MessageBox.Show("Se guardó correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ABCContFrmRemolques_Load(object sender, EventArgs e)
        {
            CBOYear.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ABCContFrmRemolques_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Limpiar();
                e.SuppressKeyPress = true;
            }
        }
        #endregion
    }
}
