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
using static TransportesSoft_BackOffice.Forms.ContFrmBuscar;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class ContFrmBusquedaViajes : Form
    {
        List<ContViajes> lListViajes;
        Service_ContViajes lServiceContViajes;
        private BindingSource bindingSourceViajes = new BindingSource();
        public ContViajes ViajeSeleccionado { get; private set; }
        public event EventHandler<ContViajes> ViajeSeleccionadoEvent;
        public ContFrmBusquedaViajes()
        {
            InitializeComponent();
            lServiceContViajes = new Service_ContViajes();
            lListViajes = new List<ContViajes>();
            BuscarViajes();
            ConfigurarGridViajes();
        }
        private void BuscarViajes()
        {
            try
            {
                lListViajes = lServiceContViajes.ObtenerTodosLosViajes();
                bindingSourceViajes.DataSource = lListViajes;
                DGV.DataSource = bindingSourceViajes;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ConfigurarGridViajes()
        {
            DGV.ReadOnly = true;
            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;

            DGV.Columns["id_Viaje"].Width = 50;
            DGV.Columns["Factura"].Width = 130;
            DGV.Columns["Destino"].Width = 70;
            DGV.Columns["NumeroTransporte"].Width = 70;
            DGV.Columns["NumeroTransporte"].HeaderText = "Transporte";
            DGV.Columns["Monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV.Columns["id_Client"].Visible = false;
            DGV.Columns["FechaViaje"].Visible = false;
            DGV.Columns["FechaFactura"].Visible = false;
            DGV.Columns["Origen"].Visible = false;
            DGV.Columns["IVA"].Visible = false;
            DGV.Columns["Retenciones"].Visible = false;
            DGV.Columns["Total"].Visible = false;
            DGV.Columns["Comentarios"].Visible = false;
            DGV.Columns["Maniobra"].Visible = false;
            DGV.Columns["id_Operador"].Visible = false;
            DGV.Columns["id_Unidad"].Visible = false;
            DGV.Columns["id_Remolque"].Visible = false;
        }

        private void RegresarInformacion(int rowIndex)
        {
            try
            {
                if (rowIndex < 0) return;

                ContViajes viaje = new ContViajes
                {
                    id_viaje = Convert.ToInt32(DGV.Rows[rowIndex].Cells["id_Viaje"].Value),
                    id_Client = Convert.ToInt32(DGV.Rows[rowIndex].Cells["id_Client"].Value),
                    NombreCliente = DGV.Rows[rowIndex].Cells["NombreCliente"].Value?.ToString(),
                    FechaViaje = Convert.ToDateTime(DGV.Rows[rowIndex].Cells["FechaViaje"].Value),
                    FechaFactura = Convert.ToDateTime(DGV.Rows[rowIndex].Cells["FechaFactura"].Value),
                    Factura = DGV.Rows[rowIndex].Cells["Factura"].Value?.ToString(),
                    NumeroTransporte = Convert.ToInt32(DGV.Rows[rowIndex].Cells["NumeroTransporte"].Value),
                    Origen = DGV.Rows[rowIndex].Cells["Origen"].Value?.ToString(),
                    Destino = DGV.Rows[rowIndex].Cells["Destino"].Value?.ToString(),
                    Monto = Convert.ToDecimal(DGV.Rows[rowIndex].Cells["Monto"].Value),
                    IVA = Convert.ToDecimal(DGV.Rows[rowIndex].Cells["IVA"].Value),
                    Retenciones = Convert.ToDecimal(DGV.Rows[rowIndex].Cells["Retenciones"].Value),
                    Total = Convert.ToDecimal(DGV.Rows[rowIndex].Cells["Total"].Value),
                    Maniobra = Convert.ToDecimal(DGV.Rows[rowIndex].Cells["Maniobra"].Value),
                    id_Operador = Convert.ToInt32(DGV.Rows[rowIndex].Cells["id_Operador"].Value),
                    id_Unidad = Convert.ToInt32(DGV.Rows[rowIndex].Cells["id_Unidad"].Value),
                    id_Remolque = Convert.ToInt32(DGV.Rows[rowIndex].Cells["id_Remolque"].Value),
                    Comentarios = DGV.Rows[rowIndex].Cells["Comentarios"].Value?.ToString()
                };

                ViajeSeleccionadoEvent?.Invoke(this, viaje);


                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            /*CONT UNIDADES*/
            
                if (string.IsNullOrEmpty(filtro))
                {
                    bindingSourceViajes.DataSource = lListViajes;
                }
                else
                {
                    var filtradas = lListViajes
                        .Where(u => u.id_viaje.ToString().Contains(filtro) ||
                                    u.Factura.ToLower().Contains(filtro) ||
                                    u.Destino.ToLower().Contains(filtro) ||
                                    u.Monto.ToString().Contains(filtro) ||
                                    u.NumeroTransporte.ToString().Contains(filtro) ||
                                    u.NombreCliente.ToLower().Contains(filtro)) 
                                    
                        .ToList();

                    bindingSourceViajes.DataSource = filtradas;
                }
            DGV.Refresh();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (DGV.CurrentRow != null)
            {
                int rowIndex = DGV.CurrentRow.Index;
                RegresarInformacion(rowIndex);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila antes de continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RegresarInformacion(e.RowIndex);
        }
    }
}
