using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class RptsFrmMantenimientoUnidades : Form
    {
        public RptsFrmMantenimientoUnidades()
        {
            InitializeComponent();
            LlenarComboKilometrajes();
        }
        private void LlenarComboKilometrajes()
        {
            CBKilometrajes.DataSource = null;
            List<int> ListKilometrajes = new List<int> {0, 3000, 5000, 10000, 15000, 20000 };
            CBKilometrajes.DataSource = ListKilometrajes;
            CBKilometrajes.SelectedIndex = 0;
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            // Ejecutar lógica del reporte
            FormReporte lreport = new FormReporte(FormReporte.TipoReporte.UnidadesPorMantenimiento, Convert.ToInt32(CBKilometrajes.SelectedValue));
            lreport.MdiParent = this.MdiParent;
            lreport.FormBorderStyle = FormBorderStyle.Sizable;
            if (lreport.HayInformacion == false)
            {
                return;
            }
            lreport.Show();
            lreport.BringToFront();
        }

        private void RBTodasLasUnidades_CheckedChanged(object sender, EventArgs e)
        {
            if (RBTodasLasUnidades.Checked)
            {
                BtnImprimir.Enabled = true;
                CBKilometrajes.Enabled = false;
            }
            else
            {
                BtnImprimir.Enabled = false;
                CBKilometrajes.Enabled = true;   
            }
            CBKilometrajes.SelectedIndex = 0;
        }

        private void CBKilometrajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBKilometrajes.SelectedIndex != 0 && RBProximosMantenimientos.Checked)
            {
                BtnImprimir.Enabled = true;
            }
        }
    }
}
