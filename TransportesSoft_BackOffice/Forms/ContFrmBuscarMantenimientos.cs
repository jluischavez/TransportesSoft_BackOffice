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
using TransportesSoft_BackOffice.Models;
using TransportesSoft_BackOffice.Services;
using static TransportesSoft_BackOffice.Forms.ContFrmBuscar;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class ContFrmBuscarMantenimientos : Base
    {
        Service_ContMantenimientosCab lServiceContMantenimientosCab = new Service_ContMantenimientosCab();
        List<ContMantenimientosCab> lListContMantenimientosCabRemolques;
        List<ContMantenimientosCab> lListContMantenimientosCabUnidades;
        private TipoBusqueda TipoFormulario;

        private BindingSource bindingSourceUnidades = new BindingSource();
        private BindingSource bindingSourceRemolques = new BindingSource();
        public ContMantenimientosCab MantenimientoSeleccionado { get; private set; }
        public event EventHandler<ContMantenimientosCab> MantenimientoSeleccionadoEvent;
        public ContFrmBuscarMantenimientos()
        {
            InitializeComponent();
            Buscar();
        }

        private void Buscar()
        {
            lListContMantenimientosCabUnidades = new List<ContMantenimientosCab>();
            lListContMantenimientosCabUnidades = lServiceContMantenimientosCab.ObtenerMantenimientosUnidades();
            bindingSourceUnidades.DataSource = lListContMantenimientosCabUnidades;
            DGV_Unidades.DataSource = bindingSourceUnidades;
            ConfigurarGridUnidades();

            lListContMantenimientosCabRemolques = new List<ContMantenimientosCab>();
            lListContMantenimientosCabRemolques = lServiceContMantenimientosCab.ObtenerMantenimientosRemolques();
            bindingSourceRemolques.DataSource = lListContMantenimientosCabRemolques;
            DGVRemolques.DataSource = bindingSourceRemolques;
            ConfigurarGridRemolques();
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
            DGV_Unidades.Columns["IdMantenimiento"].Width = 60;
            DGV_Unidades.Columns["IdMantenimiento"].HeaderText = "ID Mantenimiento";
            DGV_Unidades.Columns["id_Unidad"].Width = 50;
            DGV_Unidades.Columns["id_Unidad"].HeaderText = "ID";
            DGV_Unidades.Columns["FechaMantenimiento"].HeaderText = "Fecha";
            DGV_Unidades.Columns["FechaMantenimiento"].Width = 80;
            DGV_Unidades.Columns["Kilometraje"].Width = 70;
            DGV_Unidades.Columns["Kilometraje"].DefaultCellStyle.Format = "N0";
            DGV_Unidades.Columns["Proveedor"].Width = 70;
            DGV_Unidades.Columns["CostoTotal"].Width = 70;
            DGV_Unidades.Columns["CostoTotal"].DefaultCellStyle.Format = "N2"; // ← Esta línea formatea a 2 
            DGV_Unidades.Columns["id_Remolque"].Visible = false;
        }
        private void ConfigurarGridRemolques()
        {
            DGVRemolques.ReadOnly = true;
            DGVRemolques.AllowUserToAddRows = false;
            DGVRemolques.AllowUserToDeleteRows = false;
            DGVRemolques.AllowUserToOrderColumns = false;
            DGVRemolques.AllowUserToResizeColumns = false;
            DGVRemolques.AllowUserToResizeRows = false;
            DGVRemolques.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVRemolques.MultiSelect = false;
            DGVRemolques.Columns["IdMantenimiento"].Width = 60;
            DGVRemolques.Columns["IdMantenimiento"].HeaderText = "ID Mantenimiento";
            DGVRemolques.Columns["id_Remolque"].Width = 50;
            DGVRemolques.Columns["id_Remolque"].HeaderText = "ID";
            DGVRemolques.Columns["FechaMantenimiento"].HeaderText = "Fecha";
            DGVRemolques.Columns["FechaMantenimiento"].Width = 80;
            DGVRemolques.Columns["Kilometraje"].Width = 70;
            DGVRemolques.Columns["Kilometraje"].DefaultCellStyle.Format = "N0";
            DGVRemolques.Columns["Proveedor"].Width = 70;
            DGVRemolques.Columns["CostoTotal"].Width = 70;
            DGVRemolques.Columns["CostoTotal"].DefaultCellStyle.Format = "N2"; // ← Esta línea formatea a 2 decimales
            DGVRemolques.Columns["id_Unidad"].Visible = false;
        }

        private void RegresarInformacion(int rowIndex)
        {
            if (rowIndex < 0) return;

            if (TipoFormulario == TipoBusqueda.MantenimientoUnidades)
            {
                ContMantenimientosCab unidad = new ContMantenimientosCab
                {
                    IdMantenimiento = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["IdMantenimiento"].Value),
                    FechaMantenimiento = Convert.ToDateTime(DGV_Unidades.Rows[rowIndex].Cells["FechaMantenimiento"].Value),
                    Kilometraje = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["Kilometraje"].Value),
                    Proveedor = DGV_Unidades.Rows[rowIndex].Cells["Proveedor"].Value?.ToString(),
                    CostoTotal = Convert.ToDecimal(DGV_Unidades.Rows[rowIndex].Cells["CostoTotal"].Value),
                    id_Remolque = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["id_Remolque"].Value),
                    id_Unidad = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["id_Unidad"].Value),
                };

                MantenimientoSeleccionadoEvent?.Invoke(this, unidad);
            }
            else if (TipoFormulario == TipoBusqueda.MantenimientoRemolques)
            {
                ContMantenimientosCab remolque = new ContMantenimientosCab
                {
                    IdMantenimiento = Convert.ToInt32(DGVRemolques.Rows[rowIndex].Cells["IdMantenimiento"].Value),
                    FechaMantenimiento = Convert.ToDateTime(DGVRemolques.Rows[rowIndex].Cells["FechaMantenimiento"].Value),
                    Kilometraje = Convert.ToInt32(DGVRemolques.Rows[rowIndex].Cells["Kilometraje"].Value),
                    Proveedor = DGVRemolques.Rows[rowIndex].Cells["Proveedor"].Value?.ToString(),
                    CostoTotal = Convert.ToDecimal(DGVRemolques.Rows[rowIndex].Cells["CostoTotal"].Value),
                    id_Remolque = Convert.ToInt32(DGVRemolques.Rows[rowIndex].Cells["id_Remolque"].Value),
                    id_Unidad = Convert.ToInt32(DGVRemolques.Rows[rowIndex].Cells["id_Unidad"].Value),
                };

                MantenimientoSeleccionadoEvent?.Invoke(this, remolque);
            }

            this.Close();
        }

        private void BtnAceptarUnidad_Click(object sender, EventArgs e)
        {
            TipoFormulario = TipoBusqueda.MantenimientoUnidades;

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

        private void BtnAceptarRemolque_Click(object sender, EventArgs e)
        {
            TipoFormulario = TipoBusqueda.MantenimientoRemolques;

            if (DGVRemolques.CurrentRow != null)
            {
                int rowIndex = DGVRemolques.CurrentRow.Index;
                RegresarInformacion(rowIndex);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila antes de continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscarUnidad_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarUnidad.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                bindingSourceUnidades.DataSource = lListContMantenimientosCabUnidades;
            }
            else
            {
                var filtradas = lListContMantenimientosCabUnidades
                    .Where(u => u.Proveedor.ToLower().Contains(filtro) ||
                                u.IdMantenimiento.ToString().Contains(filtro) ||
                                u.id_Unidad.ToString().Contains(filtro) || 
                                u.CostoTotal.ToString().Contains(filtro) ||
                                u.Kilometraje.ToString().Contains(filtro) ||
                                u.FechaMantenimiento.ToString().Contains(filtro))
                    .ToList();

                bindingSourceUnidades.DataSource = filtradas;
            }

            DGV_Unidades.Refresh();
        }

        private void txtBuscarRemolque_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarRemolque.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                bindingSourceRemolques.DataSource = lListContMantenimientosCabRemolques;
            }
            else
            {
                var filtradas = lListContMantenimientosCabRemolques
                    .Where(u => u.Proveedor.ToLower().Contains(filtro) ||
                                u.IdMantenimiento.ToString().Contains(filtro) ||
                                u.id_Remolque.ToString().Contains(filtro) ||
                                u.CostoTotal.ToString().Contains(filtro) ||
                                u.Kilometraje.ToString().Contains(filtro) ||
                                u.FechaMantenimiento.ToString().Contains(filtro))
                    .ToList();

                bindingSourceRemolques.DataSource = filtradas;
            }

            DGVRemolques.Refresh();
        }

        private void DGV_Unidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TipoFormulario = TipoBusqueda.MantenimientoUnidades;
            RegresarInformacion(e.RowIndex);
        }

        private void DGVRemolques_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TipoFormulario = TipoBusqueda.MantenimientoRemolques;
            RegresarInformacion(e.RowIndex);
        }
    }
}
