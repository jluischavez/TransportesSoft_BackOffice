using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Services;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class FormReporte : Form
    {
        /*Cont Unidades*/
        Service_ContUnidades lServiceContUnidades;
        List<ContUnidades> lContUnidades;

        /*Cont Consumo Unidades*/
        Service_ContConsumoUnidades lServiceConsumoUnidades;
        List<ContConsumoUnidades> lContConsumoUnidades;

        /*Configuracion Sucursal*/
        Service_ConfSucursalLocal lServcontSucLocal;
        ConfSucursalLocal lConfSucLocal;

        public enum TipoReporte
        {
            ContabilidadUnidades = 1,
            ContabilidadConsumoUnidades = 2
        }
        #region "Constructor"
        public FormReporte(TipoReporte tipoReporte)
        {

            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            InitializeComponent();
        }

        /**CONSTRUCTOR DE CONSUMO DE UNIDADES**/
        public FormReporte(TipoReporte tipoReporte, DateTime FechaInicial, DateTime FechaFinal, int idunidad)
        {

            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            InitializeComponent();
            if (tipoReporte == TipoReporte.ContabilidadConsumoUnidades)
            {
                    RptContConsumoUnidadesPorFecha(FechaInicial, FechaFinal, idunidad);
            }
        }
        #endregion
        private void RptContConsumoUnidadesPorFecha(DateTime FechaInicial, DateTime FechaFinal, int idUnidad)
        {
            try
            {
                lServiceConsumoUnidades = new Service_ContConsumoUnidades();
                if (idUnidad == 0)
                {
                    lContConsumoUnidades = lServiceConsumoUnidades.ObtenerContConsumoUnidadesPorFecha(FechaInicial, FechaFinal);
                }
                else
                {
                    lContConsumoUnidades = lServiceConsumoUnidades.ObtenerContConsumoUnidadPorFecha(FechaInicial, FechaFinal, idUnidad);
                }
                
                lServcontSucLocal = new Service_ConfSucursalLocal();
                lConfSucLocal = lServcontSucLocal.ObtenerConfiguracionSucursalLocal();

                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string reportPath = Path.Combine(projectRoot, "Reports", "RptConsumoUnidadesPorFecha.rdlc");

                ReportDataSource rds = new ReportDataSource("ContConsumoUnidades", lContConsumoUnidades);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.ReportPath = reportPath;

                /*Agrega la sucursal*/
                ReportParameter paramSucursal = new ReportParameter("txtSucursal", lConfSucLocal.NombreSucursal);
                reportViewer1.LocalReport.SetParameters(paramSucursal);

                reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error", "Error al generar reporte. " + ex.Message,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            
        }
    }
}
