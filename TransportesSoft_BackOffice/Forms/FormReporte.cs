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
using TransportesSoft_BackOffice.Models;
using TransportesSoft_BackOffice.Services;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class FormReporte : Base
    {
        /*Cont Unidades*/
        private Service_ContKilometrajeUnidad lServiceContKilometraje;
        private List<ProximoMantenimientoUnidades> lListProximoMantenimientoUnidadDTO;

        /*Cont Consumo Unidades*/
        private Service_ContConsumoUnidades lServiceConsumoUnidades;
        private List<ContConsumoUnidades> lContConsumoUnidades;

        /*Configuracion Sucursal*/
        private Service_ConfSucursalLocal lServcontSucLocal;
        private ConfSucursalLocal lConfSucLocal;

        /*Cont Viajes*/
        private Service_ContViajes lServContViajes;
        private List<ContViajesYOperador> lListContViajesYOperador;
        private List<ContViajes> lListContViajes;

        /*Cont Polizas Reg*/
        private Service_ContFrmPolizas lServcontFrmPolizas;
        private List<ContPolizasReg> lListContFrmPolizas;

        public Boolean HayInformacion = false;
        public enum TipoReporte
        {
            ContabilidadUnidades = 1,
            ContabilidadConsumoUnidades = 2,
            ContabilidadViajesPorFecha = 3,
            UnidadesPorMantenimiento = 4,
            ContabilidadPolizasPorFecha = 5,
            IngresosPorUnidad = 6,
        }
        #region "Constructor"
        public FormReporte(TipoReporte tipoReporte)
        {
            InitializeComponent();
        }

        /**CONSTRUCTOR DE CONSUMO DE UNIDADES, DE VIAJES Y DE PÓLIZAS, INGRESOS Y EGRESOS POR UNIDAD**/
        public FormReporte(TipoReporte tipoReporte, DateTime FechaInicial, DateTime FechaFinal, int ID)
        {

            //SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            InitializeComponent();
            if (tipoReporte == TipoReporte.ContabilidadConsumoUnidades)
            {
                RptContConsumoUnidadesPorFecha(FechaInicial, FechaFinal, ID);
                this.Text = "Reporte de Consumo de Unidades por fecha.";
            }
            else if (tipoReporte == TipoReporte.ContabilidadViajesPorFecha)
            {
                RptContViajesPorFecha(FechaInicial, FechaFinal, ID);
                this.Text = "Reporte de viajes por fecha.";
            }
            else if (tipoReporte == TipoReporte.ContabilidadPolizasPorFecha)
            {
                RptContPolizasPorFecha(FechaInicial, FechaFinal, ID);
            }
            else if (tipoReporte == TipoReporte.IngresosPorUnidad)
            {
                RptIngresosPorUnidad(FechaInicial, FechaFinal, ID);
            }
        }
        /*CONSTRUCTOR DE REPORTE DE MANTENIMIENTO DE UNIDADES*/
        public FormReporte(TipoReporte tipoReporte, int kilometrajeMantenimiento)
        {
            InitializeComponent();

            if(tipoReporte == TipoReporte.UnidadesPorMantenimiento)
            {
                RptMantenimientoUnidades(kilometrajeMantenimiento);
                this.Text = "Reporte de mantenimiento de unidades.";
            }
        }
        #endregion
        private void RptIngresosPorUnidad(DateTime FechaInicial, DateTime FechaFinal, int idUnidad)
        {
            try
            {
                //Implementar reporte de ingresos por unidad
                lServContViajes = new Service_ContViajes();
                if (idUnidad == 0)
                {
                    lListContViajes = lServContViajes.ObtenerIngresosUnidades(FechaInicial, FechaFinal);
                }
                else
                {
                    lListContViajes = lServContViajes.ObtenerIngresosUnidades(FechaInicial, FechaFinal, idUnidad);
                }
                if (lListContViajes.Count == 0)
                {
                    MessageBox.Show("No hay información para las fechas seleccionadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HayInformacion = false;
                    return;
                }

                HayInformacion = true;

                lServcontSucLocal = new Service_ConfSucursalLocal();
                lConfSucLocal = lServcontSucLocal.ObtenerConfiguracionSucursalLocal();
                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string reportPath = Path.Combine(projectRoot, "Reports", "RptIngresosPorUnidades.rdlc");

                ReportDataSource rds = new ReportDataSource("DSIngresosPorUnidades", lListContViajes);
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
                MessageBox.Show("Error." + ex.Message,"Error al generar reporte.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RptContPolizasPorFecha(DateTime FechaInicial, DateTime FechaFinal, int idTipoPoliza)
        {
            try
            {
                //Implementar reporte de pólizas por fecha
                lServcontFrmPolizas = new Service_ContFrmPolizas();
                if (idTipoPoliza == 0)
                {
                    lListContFrmPolizas = lServcontFrmPolizas.ObtenerPolizasPorFechaAExpirar(FechaInicial, FechaFinal);
                }
                else
                {
                    lListContFrmPolizas = lServcontFrmPolizas.ObtenerPolizasPorTipoYFecha(FechaInicial, FechaFinal, idTipoPoliza);
                }
                if (lListContFrmPolizas.Count == 0)
                {
                    MessageBox.Show("No hay información para las fechas seleccionadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HayInformacion = false;
                    return;
                }
                HayInformacion = true;
                lServcontSucLocal = new Service_ConfSucursalLocal();
                lConfSucLocal = lServcontSucLocal.ObtenerConfiguracionSucursalLocal();
                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string reportPath = Path.Combine(projectRoot, "Reports", "RptPolizasPorFecha.rdlc");
               
                ReportDataSource rds = new ReportDataSource("DSContPolizasReg", lListContFrmPolizas);
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
                    HayInformacion = false;
                    return;
                }
                HayInformacion = true;

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
                    HayInformacion = false;
                    return;
                }
                HayInformacion = true;

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
        private void RptMantenimientoUnidades(int kilometrajeMantenimiento)
        {
            try
            {
                lServiceContKilometraje = new Service_ContKilometrajeUnidad();
                lListProximoMantenimientoUnidadDTO = new List<ProximoMantenimientoUnidades>();
                if (kilometrajeMantenimiento == 0)
                {
                    lListProximoMantenimientoUnidadDTO = lServiceContKilometraje.ObtenerProximosMantenimientos();
                }
                else
                {
                    lListProximoMantenimientoUnidadDTO = lServiceContKilometraje.ObtenerProximosMantenimientosPorKilometraje(kilometrajeMantenimiento);
                }


                if (lListProximoMantenimientoUnidadDTO.Count == 0)
                {
                    MessageBox.Show("No hay información de mantenimientos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HayInformacion = false;
                    return;
                }
                HayInformacion = true;

                lServcontSucLocal = new Service_ConfSucursalLocal();
                lConfSucLocal = lServcontSucLocal.ObtenerConfiguracionSucursalLocal();

                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string reportPath = Path.Combine(projectRoot, "Reports", "RptMantenimientoUnidades.rdlc");

                ReportDataSource rds = new ReportDataSource("DSProximoMantenimientoUnidadesDTO", lListProximoMantenimientoUnidadDTO);
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
