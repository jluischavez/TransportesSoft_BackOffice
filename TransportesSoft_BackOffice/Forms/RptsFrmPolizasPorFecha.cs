using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportesSoft_BackOffice.Services;
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class RptsFrmPolizasPorFecha : Base
    {
        Service_ContTiposPolizas Service_ContTiposPolizas;
        List<ContTiposPolizas> ListContTiposPolizas;
        public RptsFrmPolizasPorFecha()
        {
            InitializeComponent();
            ObtenerTiposDePolizas();
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

        private void ObtenerTiposDePolizas()
        {
            try
            {
                Service_ContTiposPolizas = new Service_ContTiposPolizas();
                ListContTiposPolizas = Service_ContTiposPolizas.ObtenerTiposPolizas();
                CboPolizaSeleccionada.DataSource = ListContTiposPolizas;
                CboPolizaSeleccionada.DisplayMember = "TipoPoliza";
                CboPolizaSeleccionada.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.", "Error al consultar: " + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            DateTime fechaInicial = DTFechaInicial.Value.Date;
            DateTime fechaFinal = DTFechaFinal.Value.Date;

            if (ValidarFechas(fechaInicial, fechaFinal))
            {
                int idUnidad = 0;
                if (ChkPolizaSeleccionada.Checked)
                {
                    idUnidad = Convert.ToInt32(CboPolizaSeleccionada.SelectedValue);
                }
                // Ejecutar lógica del reporte
                FormReporte lreport = new FormReporte(FormReporte.TipoReporte.ContabilidadPolizasPorFecha, fechaInicial, fechaFinal, idUnidad);
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

        private void RptsFrmPolizasPorFecha_Load(object sender, EventArgs e)
        {
            CboPolizaSeleccionada.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ChkPolizaSeleccionada_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPolizaSeleccionada.Checked)
            {
                CboPolizaSeleccionada.Enabled = true;
            }
            else
            {
                CboPolizaSeleccionada.Enabled = false;
            }
        }
    }

}
