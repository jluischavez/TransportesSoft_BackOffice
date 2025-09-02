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

        /*Cont Viajes*/
        Service_ContViajes lServContViajes;
        List<ContViajesYOperador> lListContViajesYOperador;
        public enum TipoReporte
        {
            ContabilidadUnidades = 1,
            ContabilidadConsumoUnidades = 2,
            ContavilidadViajesPorFecha = 3
        }
        #region "Constructor"
        public FormReporte(TipoReporte tipoReporte)
        {

            //SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            InitializeComponent();
        }

        /**CONSTRUCTOR DE CONSUMO DE UNIDADES Y DE VIAJES**/
        public FormReporte(TipoReporte tipoReporte, DateTime FechaInicial, DateTime FechaFinal, int ID)
        {

            //SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            InitializeComponent();
            if (tipoReporte == TipoReporte.ContabilidadConsumoUnidades)
            {
                RptContConsumoUnidadesPorFecha(FechaInicial, FechaFinal, ID);
                this.Text = "Reporte de Consumo de Unidades por fecha.";
            }
            else if (tipoReporte == TipoReporte.ContavilidadViajesPorFecha)
            {
                RptContViajesPorFecha(FechaInicial, FechaFinal, ID);
                this.Text = "Reporte de viajes por fecha.";
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
                
                if (lContConsumoUnidades.Count == 0)
                {
                    MessageBox.Show("No hay información para las fechas seleccionadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
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
                MessageBox.Show("Error al generar reporte.", "Error." + ex.Message,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        private void RptContViajesPorFecha(DateTime FechaInicial, DateTime FechaFinal, int idCliente)
        {
            try
            {
                lServContViajes = new Service_ContViajes();
                if (idCliente == 0)
                {
                    lListContViajesYOperador = lServContViajes.ObtenerViajesPorFecha(FechaInicial, FechaFinal);
                }
                else
                {
                    lListContViajesYOperador = lServContViajes.ObtenerViajesPorFechaPorCliente(FechaInicial, FechaFinal, idCliente);
                }

                if (lListContViajesYOperador.Count == 0)
                {
                    MessageBox.Show("No hay información para las fechas seleccionadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                lServcontSucLocal = new Service_ConfSucursalLocal();
                lConfSucLocal = lServcontSucLocal.ObtenerConfiguracionSucursalLocal();

                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string reportPath = Path.Combine(projectRoot, "Reports", "RptViajesPorFecha.rdlc");

                ReportDataSource rds = new ReportDataSource("DSContViajesYOperador", lListContViajesYOperador);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.ReportPath = reportPath;

                /*Agrega la sucursal*/
                ReportParameter paramSucursal = new ReportParameter("txtSucursal", lConfSucLocal.NombreSucursal);
                reportViewer1.LocalReport.SetParameters(paramSucursal);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte.", "Error." + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region "Eventos"
        private void FormReporte_Load(object sender, EventArgs e)
        {
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }
        #endregion
    }
}
