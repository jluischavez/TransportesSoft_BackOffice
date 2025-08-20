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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Xml.Linq;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class ContFrmBuscar : Form
    {
        List<ContUnidades> lContUnidades;
        Service_ContUnidades lServiceContUnidades;

        public ContUnidades UnidadSeleccionada { get; private set; }

        public event EventHandler<ContUnidades> UnidadSeleccionadaEvent;
        public ContFrmBuscar(string titulo)
        {
            InitializeComponent();

            this.Text = this.Text + " " + titulo;
            if (titulo == "Unidades")
            {
                lContUnidades = new List<ContUnidades>();
                lServiceContUnidades = new Service_ContUnidades();
                BuscarUnidades();
            }
        }

        private void BuscarUnidades()
        {
            try
            {
                lContUnidades = lServiceContUnidades.ObtenerUnidades();
                DGV_Unidades.DataSource = lContUnidades;
                ConfigurarGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error", "Error al consultar las unidades: " + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ConfigurarGrid()
        {
            DGV_Unidades.ReadOnly = true;                      
            DGV_Unidades.AllowUserToAddRows = false;           
            DGV_Unidades.AllowUserToDeleteRows = false;        
            DGV_Unidades.AllowUserToOrderColumns = false;      
            DGV_Unidades.AllowUserToResizeColumns = false;     
            DGV_Unidades.AllowUserToResizeRows = false;        
            DGV_Unidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            DGV_Unidades.MultiSelect = false;                  

            DGV_Unidades.Columns["Kilometraje"].Visible = false;
            DGV_Unidades.Columns["FechaActualizacion"].Visible = false;
            DGV_Unidades.Columns["id_Operador"].Visible = false;
            DGV_Unidades.Columns["ProximoMantenimiento"].Visible = false;
        }

        private void DGV_Unidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var unidad = new ContUnidades
                {
                    id_Unidad = Convert.ToInt32(DGV_Unidades.Rows[e.RowIndex].Cells["id_Unidad"].Value),
                    Marca = DGV_Unidades.Rows[e.RowIndex].Cells["Marca"].Value?.ToString(),
                    Serie = DGV_Unidades.Rows[e.RowIndex].Cells["Serie"].Value?.ToString(),
                    Kilometraje = Convert.ToInt32(DGV_Unidades.Rows[e.RowIndex].Cells["Kilometraje"].Value),
                    FechaActualizacion = Convert.ToDateTime(DGV_Unidades.Rows[e.RowIndex].Cells["FechaActualizacion"].Value),
                    id_Operador = Convert.ToInt32(DGV_Unidades.Rows[e.RowIndex].Cells["id_Operador"].Value),
                    ProximoMantenimiento = Convert.ToInt32(DGV_Unidades.Rows[e.RowIndex].Cells["ProximoMantenimiento"].Value)
                };

                UnidadSeleccionadaEvent?.Invoke(this, unidad);
                this.Close(); // Cierra el formulario MDI hijo
            }
        }

        private void BntReporte_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("Unidades.pdf", FileMode.Create));
            doc.Open();

            foreach (var unidad in lContUnidades)
            {
                doc.Add(new Paragraph($"ID: {unidad.id_Unidad} - Marca: {unidad.Marca} - Serie: {unidad.Serie} - Kilometraje: {unidad.Kilometraje} - Operador: {unidad.id_Operador} - Proximo Mantenimiento: {unidad.ProximoMantenimiento}"));
            }

            doc.Close();
        }
    }
}
