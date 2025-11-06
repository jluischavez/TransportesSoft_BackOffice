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
    public partial class RptsFrmIngresosPorUnidad : Base
    {
        private List<ContUnidadesCat> lContUnidades;
        private Service_ContUnidadesCat lServContUnidades;
        public RptsFrmIngresosPorUnidad()
        {
            InitializeComponent();
            ObtenerUnidades();
            CboUnidades.Enabled = false;
        }

        #region "Private"
        private void ObtenerUnidades()
        {
            try
            {
                lServContUnidades = new Service_ContUnidadesCat();
                lContUnidades = lServContUnidades.ObtenerUnidades();
                CboUnidades.DataSource = lContUnidades;
                CboUnidades.DisplayMember = "Descripcion";
                CboUnidades.ValueMember = "id_Unidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.", "Error al consultar: " + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ValidarFechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            DateTime hoy = DateTime.Today;

            // Validación básica
            if (fechaFinal < fechaInicial)
            {
                MessageBox.Show("La fecha final no puede ser menor que la fecha inicial.", "Validación de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (fechaInicial > hoy)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha actual.", "Validación de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion
        #region "Eventos"
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            DateTime fechaInicial = DTFechaInicial.Value.Date;
            DateTime fechaFinal = DTFechaFinal.Value.Date;

            if (ValidarFechas(fechaInicial, fechaFinal))
            {
                int idUnidad = 0;
                if (CBUnidadSeleccionada.Checked)
                {
                    idUnidad = Convert.ToInt32(CboUnidades.SelectedValue);
                }
                // Ejecutar lógica del reporte
                FormReporte lreport = new FormReporte(FormReporte.TipoReporte.IngresosPorUnidad, fechaInicial, fechaFinal, idUnidad);
                lreport.MdiParent = this.MdiParent;
                lreport.FormBorderStyle = FormBorderStyle.Sizable;
                if (lreport.HayInformacion == false)
                    return;
                lreport.Show();
                lreport.BringToFront();
            }
        }
        private void CBUnidadSeleccionada_CheckedChanged(object sender, EventArgs e)
        {
            if (CBUnidadSeleccionada.Checked)
            {
                CboUnidades.Enabled = true;
            }
            else
            {
                CboUnidades.Enabled = false;
            }
        }
        private void RptsFrmConsumoUnidadesPorFecha_Load(object sender, EventArgs e)
        {
            CboUnidades.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion

        
    }
}
