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
    public partial class RptsFrmViajesPorFecha : Base
    {
        Service_ContClientesCat lServiceContClientes;
        List<ContClientesCat> lListContClientes;
        public RptsFrmViajesPorFecha()
        {
            InitializeComponent();
            ObtenerClientes();
            CboClienteSeleccionado.Enabled = false;
        }

        #region "Private"
        private bool ValidarFechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            DateTime hoy = DateTime.Today;

            // Validación básica
            if (fechaFinal < fechaInicial)
            {
                MessageBox.Show("La fecha final no puede ser menor que la fecha inicial.", "Validación de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (fechaFinal > hoy)
            {
                MessageBox.Show("La fecha final no puede ser mayor que la fecha actual.", "Validación de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (fechaInicial > hoy)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha actual.", "Validación de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ObtenerClientes()
        {
            try
            {
                lServiceContClientes = new Service_ContClientesCat();
                lListContClientes = lServiceContClientes.ObtenerClientes();
                CboClienteSeleccionado.DataSource = lListContClientes;
                CboClienteSeleccionado.DisplayMember = "Descripcion";
                CboClienteSeleccionado.ValueMember = "id_Client";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.", "Error al consultar: " + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (ChkClienteSeleccionado.Checked)
            {
                idUnidad = Convert.ToInt32(CboClienteSeleccionado.SelectedValue);
            }
            // Ejecutar lógica del reporte
            FormReporte lreport = new FormReporte(FormReporte.TipoReporte.ContabilidadViajesPorFecha,fechaInicial, fechaFinal, idUnidad);
                lreport.MdiParent = this.MdiParent;
                lreport.FormBorderStyle = FormBorderStyle.Sizable;
                lreport.StartPosition = FormStartPosition.Manual;

                int x = (this.MdiParent.ClientSize.Width - lreport.Width) / 2;
                int y = (this.MdiParent.ClientSize.Height - lreport.Height) / 2;
                lreport.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));
                if (lreport.HayInformacion == false)
                {
                    return;
                }
                lreport.Show();
                lreport.BringToFront();
            }
        }

        private void RptsFrmViajesPorFecha_Load(object sender, EventArgs e)
        {
            CboClienteSeleccionado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ChkClienteSeleccionado_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkClienteSeleccionado.Checked)
            {
                CboClienteSeleccionado.Enabled = true;
            }
            else
            {
                CboClienteSeleccionado.Enabled = false;
            }
        }
        #endregion
    }
}
