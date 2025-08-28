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
        #region "Declaraciones"
        /*CONTABILIDAD UNIDADES*/
        private List<ContUnidades> lContUnidades;
        private Service_ContUnidades lServiceContUnidades;
        private BindingSource bindingSourceUnidades = new BindingSource();
        public ContUnidades UnidadSeleccionada { get; private set; }
        public event EventHandler<ContUnidades> UnidadSeleccionadaEvent;

        /*CONTABILIDAD CLIENTES*/
        private List<ContClientes> lContClientes;
        private Service_ContClientes lServiceContClientes;
        private BindingSource bindingSourceClientes = new BindingSource();
        public ContClientes ClienteSeleccionado { get; private set; }
        public event EventHandler<ContClientes> ClienteSeleccionadoEvent;

        /*CONTABILIDAD REMOLQUES*/
        private List<ContRemolques> lContRemolques;
        private Service_ContRemolques lServiceContRemolques;
        private BindingSource bindingSourceRemolques = new BindingSource();
        public ContClientes RemolqueSeleccionado { get; private set; }
        public event EventHandler<ContRemolques> RemolqueSeleccionadoEvent;
        
        private TipoBusqueda TipoFormulario;
        #endregion
        public enum TipoBusqueda
        {
            ContUnidades = 1,
            ContClientes = 2,
            ContRemolques = 3
        }
        #region "Constructor"
        public ContFrmBuscar(string titulo, TipoBusqueda tipobusqueda)
        {
            InitializeComponent();

            TipoFormulario = tipobusqueda;

            this.Text = this.Text + " " + titulo;
            if (TipoFormulario == TipoBusqueda.ContUnidades)
            {
                lContUnidades = new List<ContUnidades>();
                lServiceContUnidades = new Service_ContUnidades();
                BuscarUnidades();
            }
            else if (TipoFormulario == TipoBusqueda.ContClientes)
            {
                lContClientes = new List<ContClientes>();
                lServiceContClientes = new Service_ContClientes();
                BuscarClientes();
            }
            else if (TipoFormulario == TipoBusqueda.ContRemolques)
            {
                lContRemolques = new List<ContRemolques>();
                lServiceContRemolques = new Service_ContRemolques();
                BuscarRemolques();
            }
        }
        #endregion
        #region "Private"
        private void BuscarUnidades()
        {
            try
            {
                lContUnidades = lServiceContUnidades.ObtenerUnidades();
                bindingSourceUnidades.DataSource = lContUnidades;
                DGV_Unidades.DataSource = bindingSourceUnidades;
                ConfigurarGridUnidades();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error", "Error al consultar las unidades: " + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BuscarClientes()
        {
            try
            {
                lContClientes = lServiceContClientes.ObtenerClientes();
                bindingSourceClientes.DataSource = lContClientes;
                DGV_Unidades.DataSource = bindingSourceClientes;
                ConfigurarGridClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error al consultar los clientes: " + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarRemolques()
        {
            try
            {
                lContRemolques = lServiceContRemolques.ObtenerRemolques();
                bindingSourceRemolques.DataSource = lContRemolques;
                DGV_Unidades.DataSource = bindingSourceRemolques;
                ConfigurarGridRemolques();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error al consultar los remolques: " + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGridUnidades()
        {
            DGV_Unidades.ReadOnly = true;                      
            DGV_Unidades.AllowUserToAddRows = false;           
            DGV_Unidades.AllowUserToDeleteRows = false;        
            DGV_Unidades.AllowUserToOrderColumns = false;      
            DGV_Unidades.AllowUserToResizeColumns = false;     
            DGV_Unidades.AllowUserToResizeRows = false;        
            DGV_Unidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            DGV_Unidades.MultiSelect = false;

            DGV_Unidades.Columns["id_Unidad"].Width = 50;
            DGV_Unidades.Columns["Serie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV_Unidades.Columns["Kilometraje"].Visible = false;
            DGV_Unidades.Columns["FechaActualizacion"].Visible = false;
            DGV_Unidades.Columns["id_Operador"].Visible = false;
            DGV_Unidades.Columns["ProximoMantenimiento"].Visible = false;
            DGV_Unidades.Columns["Descripcion"].Visible = false;
            DGV_Unidades.Columns["Estatus"].Visible = false;
            DGV_Unidades.Columns["id_Remolque"].Visible = false;
        }
        private void ConfigurarGridClientes()
        {
            DGV_Unidades.ReadOnly = true;
            DGV_Unidades.AllowUserToAddRows = false;
            DGV_Unidades.AllowUserToDeleteRows = false;
            DGV_Unidades.AllowUserToOrderColumns = false;
            DGV_Unidades.AllowUserToResizeColumns = false;
            DGV_Unidades.AllowUserToResizeRows = false;
            DGV_Unidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Unidades.MultiSelect = false;

            DGV_Unidades.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV_Unidades.Columns["Direccion"].Visible = false;
            DGV_Unidades.Columns["Telefono"].Visible = false;
            DGV_Unidades.Columns["Estatus"].Visible = false;
        }

        private void ConfigurarGridRemolques()
        {
            DGV_Unidades.ReadOnly = true;
            DGV_Unidades.AllowUserToAddRows = false;
            DGV_Unidades.AllowUserToDeleteRows = false;
            DGV_Unidades.AllowUserToOrderColumns = false;
            DGV_Unidades.AllowUserToResizeColumns = false;
            DGV_Unidades.AllowUserToResizeRows = false;
            DGV_Unidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Unidades.MultiSelect = false;

            // Cambiar encabezado de "Year" a "Año"
            DGV_Unidades.Columns["Year"].HeaderText = "Año";
            DGV_Unidades.Columns["id_Remolque"].HeaderText = "ID";

            // Ordenar columnas
            DGV_Unidades.Columns["id_Remolque"].DisplayIndex = 0;
            DGV_Unidades.Columns["Year"].DisplayIndex = 1;
            DGV_Unidades.Columns["Placas"].DisplayIndex = 2;
            DGV_Unidades.Columns["Modelo"].DisplayIndex = 3;

            // Ajustar ancho fijo para columnas pequeñas
            DGV_Unidades.Columns["id_Remolque"].Width = 40;
            DGV_Unidades.Columns["Year"].Width = 60;
            DGV_Unidades.Columns["Placas"].Width = 70;

            // Que "Modelo" llene el espacio restante
            DGV_Unidades.Columns["Modelo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Ocultar columnas innecesarias
            DGV_Unidades.Columns["Marca"].Visible = false;
            DGV_Unidades.Columns["Serie"].Visible = false;
            DGV_Unidades.Columns["Fecha_Llantas"].Visible = false;
            DGV_Unidades.Columns["Fecha_Fisico_SCT"].Visible = false;
            DGV_Unidades.Columns["Impermeabilizacion"].Visible = false;
            DGV_Unidades.Columns["Descripcion"].Visible = false;
        }

        /// <summary>
        /// Se ejecuta al dar doble click en un row del grid o al dar click en aceptar
        /// </summary>
        /// <param name="rowIndex"></param>
        private void RegresarInformacion(int rowIndex)
        {
            if (rowIndex < 0) return;

            if (TipoFormulario == TipoBusqueda.ContUnidades)
            {
                ContUnidades unidad = new ContUnidades
                {
                    id_Unidad = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["id_Unidad"].Value),
                    Marca = DGV_Unidades.Rows[rowIndex].Cells["Marca"].Value?.ToString(),
                    Serie = DGV_Unidades.Rows[rowIndex].Cells["Serie"].Value?.ToString(),
                    Kilometraje = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["Kilometraje"].Value),
                    FechaActualizacion = Convert.ToDateTime(DGV_Unidades.Rows[rowIndex].Cells["FechaActualizacion"].Value),
                    id_Operador = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["id_Operador"].Value),
                    ProximoMantenimiento = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["ProximoMantenimiento"].Value)
                };

                UnidadSeleccionadaEvent?.Invoke(this, unidad);
            }
            else if (TipoFormulario == TipoBusqueda.ContClientes)
            {
                ContClientes unidad = new ContClientes
                {
                    id_Client = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["id_Client"].Value),
                    Nombre = DGV_Unidades.Rows[rowIndex].Cells["Nombre"].Value?.ToString(),
                    Direccion = DGV_Unidades.Rows[rowIndex].Cells["Direccion"].Value?.ToString(),
                    Telefono = DGV_Unidades.Rows[rowIndex].Cells["Telefono"].Value?.ToString()
                };

                ClienteSeleccionadoEvent?.Invoke(this, unidad);
            }
            else if(TipoFormulario == TipoBusqueda.ContRemolques)
            {
                ContRemolques Remolque = new ContRemolques
                {
                    id_Remolque = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["id_Remolque"].Value),
                    Marca = DGV_Unidades.Rows[rowIndex].Cells["Marca"].Value?.ToString(),
                    Modelo = DGV_Unidades.Rows[rowIndex].Cells["Modelo"].Value?.ToString(),
                    Serie = DGV_Unidades.Rows[rowIndex].Cells["Serie"].Value?.ToString(),
                    Year = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["Year"].Value),
                    Placas = DGV_Unidades.Rows[rowIndex].Cells["Placas"].Value?.ToString(),
                    Fecha_Llantas = Convert.ToDateTime(DGV_Unidades.Rows[rowIndex].Cells["Fecha_Llantas"].Value),
                    Fecha_Fisico_SCT = Convert.ToDateTime(DGV_Unidades.Rows[rowIndex].Cells["Fecha_Fisico_SCT"].Value),
                    Impermeabilizacion = Convert.ToDateTime(DGV_Unidades.Rows[rowIndex].Cells["Impermeabilizacion"].Value),
                };
                RemolqueSeleccionadoEvent?.Invoke(this, Remolque);
            }

            this.Close();
        }
        #endregion
        #region "Eventos"
        private void DGV_Unidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RegresarInformacion(e.RowIndex);
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            /*CONT UNIDADES*/
            if (TipoFormulario == TipoBusqueda.ContUnidades)
            {
                if (string.IsNullOrEmpty(filtro))
                {
                    bindingSourceUnidades.DataSource = lContUnidades;
                }
                else
                {
                    var filtradas = lContUnidades
                        .Where(u => u.Marca.ToLower().Contains(filtro) ||
                                    u.Serie.ToLower().Contains(filtro) ||
                                    u.id_Unidad.ToString().Contains(filtro))
                        .ToList();

                    bindingSourceUnidades.DataSource = filtradas;
                }
            }
            /*CONT CLIENTES*/
            else if (TipoFormulario == TipoBusqueda.ContClientes)
            {

                if (string.IsNullOrEmpty(filtro))
                {
                    bindingSourceClientes.DataSource = lContClientes;
                }
                else
                {
                    var filtradas = lContClientes
                        .Where(u => u.id_Client.ToString().Contains(filtro) ||
                                    u.Nombre.ToLower().Contains(filtro))
                        .ToList();

                    bindingSourceClientes.DataSource = filtradas;
                }
            }
            /*CONT REMOLQUES*/
            else if(TipoFormulario == TipoBusqueda.ContRemolques)
            {
                if (string.IsNullOrEmpty(filtro))
                {
                    bindingSourceRemolques.DataSource = lContRemolques;
                }
                else
                {
                    var filtradas = lContRemolques
                        .Where(u => u.id_Remolque.ToString().Contains(filtro) ||
                                    u.Placas.ToLower().Contains(filtro) ||
                                    u.Modelo.ToLower().Contains(filtro) ||
                                    u.Year.ToString().Contains(filtro))
                        .ToList();

                    bindingSourceRemolques.DataSource = filtradas;
                }
            }

            DGV_Unidades.Refresh();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (DGV_Unidades.CurrentRow != null)
            {
                int rowIndex = DGV_Unidades.CurrentRow.Index;
                RegresarInformacion(rowIndex);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila antes de continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        private void DGV_Unidades_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (TipoFormulario == TipoBusqueda.ContClientes)
            {
                if (DGV_Unidades.Columns["Estatus"] != null && e.RowIndex >= 0)
                {
                    var estatusValue = DGV_Unidades.Rows[e.RowIndex].Cells["Estatus"].Value?.ToString();
                    if (estatusValue == "C")
                    {
                        DGV_Unidades.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(234, 171, 56);
                    }
                }
            }
            else if (TipoFormulario == TipoBusqueda.ContUnidades)
            {
                if (DGV_Unidades.Columns["Estatus"] != null && e.RowIndex >= 0)
                {
                    var estatusValue = DGV_Unidades.Rows[e.RowIndex].Cells["Estatus"].Value?.ToString();
                    if (estatusValue == "C")
                    {
                        DGV_Unidades.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(234, 171, 56);
                    }
                }
            }
        }
    }
}
