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
    public partial class FormReporte_Load : Form
    {
        Service_ContUnidades lServiceContUnidades;
        List<ContUnidades> lContUnidades;

        public FormReporte_Load()
        {

            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            InitializeComponent();
            lServiceContUnidades = new Service_ContUnidades();
            lContUnidades = lServiceContUnidades.ObtenerUnidades();


            string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
            string reportPath = Path.Combine(projectRoot, "Reports", "rptContUnidades.rdlc");

            ReportDataSource rds = new ReportDataSource("DSContUnidades", lContUnidades);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.RefreshReport();
        }
    }
}
