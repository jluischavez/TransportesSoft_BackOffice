using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportesSoft_BackOffice.Clases;
using TransportesSoft_BackOffice.Models;
using TransportesSoft_BackOffice.Services;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class ContFrmMantenimientos : Base
    {
        Service_ContMantenimientosCab lServiceMantenimientosCab = new Service_ContMantenimientosCab();
        Service_ContMantenimientosDet lServiceMantenimientosDet = new Service_ContMantenimientosDet();
        Service_ContRemolquesCat lServiceRemolquesCat = new Service_ContRemolquesCat();
        Service_ContUnidadesCat lServiceUnidadesCat = new Service_ContUnidadesCat();

        BindingList<ContMantenimientosDet> listaMantenimientos = new BindingList<ContMantenimientosDet>();

        Boolean _esConsulta = false;

        /// <summary>
        /// Propiedad que establece un estado al botón eliminar, el cual cambiará dependiendo de si es consulta o no.
        /// </summary>
        private bool EsConsulta
        {
            get => _esConsulta;
            set
            {
                if (_esConsulta != value)
                {
                    _esConsulta = value;
                    BtnEliminar.Enabled = _esConsulta; // Actualiza el botón automáticamente
                }
            }
        }
        public ContFrmMantenimientos()
        {
            InitializeComponent();
            ConfiguracionInicial();
            ConfiguracionGrid();
            this.KeyPreview = true;
        }

        #region "Private"
        private void ConfiguracionInicial()
        {
            try
            {
                DTFechaMantenimiento.Value = DateTime.Now;
                DGVMantenimientosDet.DataSource = listaMantenimientos;
                TxtCostoTotal.ReadOnly = true;
                RBUnidad.Checked = true;
                CBRemolque.DropDownStyle = ComboBoxStyle.DropDownList;
                CBUnidad.DropDownStyle = ComboBoxStyle.DropDownList;

                List<ContUnidadesCat> listaUnidades = lServiceUnidadesCat.ObtenerTodasUnidadesActivas();
                List<ContRemolquesCat> listaRemolques = lServiceRemolquesCat.ObtenerRemolques();

                CBUnidad.DataSource = listaUnidades;
                CBUnidad.DisplayMember = "Descripcion";
                CBUnidad.ValueMember = "Id_Unidad";
                CBUnidad.SelectedIndex = -1;

                CBRemolque.DataSource = listaRemolques;
                CBRemolque.DisplayMember = "Descripcion";
                CBRemolque.ValueMember = "Id_Remolque";
                CBRemolque.SelectedIndex = -1;

                this.TxtKilometraje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKilometraje_KeyPress);
                TxtKilometraje.Text = "0";

                EsConsulta = false;
                BtnEliminar.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar la configuración inicial: " + ex.Message);
                this.Close();
            }
            
        }
        private void ActualizarCostoTotal()
        {
            decimal total = 0;

            foreach (var item in listaMantenimientos)
            {
                total += item.PrecioRefaccion;
            }

            TxtCostoTotal.Text = total.ToString("C2");
        }
        private void ConfiguracionGrid()
        {
            // Suponiendo que tienes un DataGridView llamado DGVMantenimientosDet
            DGVMantenimientosDet.AutoGenerateColumns = false;
            DGVMantenimientosDet.Columns.Clear();

            // IdMantenimiento (oculto si lo manejas internamente)
            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdMantenimiento",
                HeaderText = "ID",
                Name = "IdMantenimiento",
                Visible = false // Oculto si no lo editas directamente
            };
            DGVMantenimientosDet.Columns.Add(colId);

            // Refacción
            var colRefaccion = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Refaccion",
                HeaderText = "Refacción",
                Name = "Refaccion",
                Width = 150
            };
            DGVMantenimientosDet.Columns.Add(colRefaccion);

            // Proveedor
            var colProveedor = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Proveedor",
                HeaderText = "Proveedor",
                Name = "Proveedor",
                Width = 150
            };
            DGVMantenimientosDet.Columns.Add(colProveedor);

            // PrecioRefaccion
            var colPrecio = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioRefaccion",
                HeaderText = "Precio",
                Name = "PrecioRefaccion",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            };
            DGVMantenimientosDet.Columns.Add(colPrecio);

            // Comentarios
            var colComentarios = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Comentarios",
                HeaderText = "Comentarios",
                Name = "Comentarios",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DGVMantenimientosDet.Columns.Add(colComentarios);

            DGVMantenimientosDet.Columns["Proveedor"].Visible = false; // Ocultar columna Proveedor
        }
        private Boolean ValidarInformacionGuardado()
        {
            if (listaMantenimientos.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos una refacción o servicio al mantenimiento.");
                return false;
            }
            if (TxtCostoTotal.Text == "0")
            {
                MessageBox.Show("El Costo Total no puede ser 0.");
                return false;
            }

            int kilometraje = int.Parse(TxtKilometraje.Text, NumberStyles.AllowThousands, CultureInfo.CurrentCulture);

            if (kilometraje == 0)
            {
                MessageBox.Show("El kilometraje no puede ser 0.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtProveedor.Text))
            {
                MessageBox.Show("El proveedor no puede estar vacío.");
                return false;
            }

            if (RBUnidad.Checked && Convert.ToInt32(CBUnidad.SelectedValue) == 0 | Convert.ToInt32(CBUnidad.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar una unidad.");
                return false;
            }

            if (RBRemolque.Checked && Convert.ToInt32(CBRemolque.SelectedValue) == 0 | Convert.ToInt32(CBRemolque.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar un remolque.");
                return false;
            }

            // Crear for each que itere en listamantenimientos, agregue en columna proveedor con lo que hay en TxtProveedor.Text y valide que ningun campo este vacío.
            foreach (var item in listaMantenimientos)
            {
                if (string.IsNullOrWhiteSpace(item.Refaccion))
                {
                    MessageBox.Show("La refacción no puede estar vacía.");
                    return false;
                }
                if (item.PrecioRefaccion <= 0)
                {
                    MessageBox.Show("El precio de la refacción debe ser mayor a cero.");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(item.Comentarios))
                {
                    item.Comentarios = string.Empty;
                }
            }

            return true;
        }
        private void Guardar()
        {
            try
            {
                DialogResult result = MessageBox.Show($"¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (!ValidarInformacionGuardado()) return;

                    
                    ContMantenimientosCab objMantenimientosCab = new ContMantenimientosCab
                    {
                        FechaMantenimiento = DTFechaMantenimiento.Value,
                        CostoTotal = decimal.Parse(TxtCostoTotal.Text, System.Globalization.NumberStyles.Currency),
                        Kilometraje = int.Parse(TxtKilometraje.Text, NumberStyles.AllowThousands, CultureInfo.CurrentCulture),
                        Proveedor = TxtProveedor.Text.ToUpper().Trim()
                    };

                    if (RBUnidad.Checked)
                    {
                        objMantenimientosCab.id_Unidad = Convert.ToInt32(CBUnidad.SelectedValue);
                        objMantenimientosCab.id_Remolque = 0;
                    }
                    else
                    {
                        objMantenimientosCab.id_Unidad = 0;
                        objMantenimientosCab.id_Remolque = Convert.ToInt32(CBRemolque.SelectedValue);
                    }


                    if (!EsConsulta)
                    {
                        /*Guarda Normal*/
                        int IdMantenimientio = lServiceMantenimientosCab.GuardarMantenimientoCab(objMantenimientosCab);

                        foreach (var item in listaMantenimientos)
                        {
                            item.IdMantenimiento = IdMantenimientio;
                            item.Refaccion = item.Refaccion?.ToUpper().Trim();
                            item.Comentarios = item.Comentarios?.ToUpper().Trim();
                            item.Proveedor = TxtProveedor.Text.ToUpper().Trim(); // Asignar proveedor desde el TextBox
                            lServiceMantenimientosDet.GuardarMantenimientoDet(item);
                        }
                    }
                    else
                    {
                        /*Actualiza*/
                        objMantenimientosCab.IdMantenimiento = Convert.ToInt32(txtID.Text);
                        lServiceMantenimientosCab.ActualizarMantenimientoCab(objMantenimientosCab);

                        // Elimina los detalles existentes antes de guardar los nuevos
                        lServiceMantenimientosDet.EliminarMantenimientoDetPorId(objMantenimientosCab.IdMantenimiento);
                        foreach (var item in listaMantenimientos)
                        {
                            item.IdMantenimiento = objMantenimientosCab.IdMantenimiento;
                            item.Refaccion = item.Refaccion?.ToUpper().Trim();
                            item.Comentarios = item.Comentarios?.ToUpper().Trim();
                            item.Proveedor = TxtProveedor.Text.ToUpper().Trim(); // Asignar proveedor desde el TextBox
                            lServiceMantenimientosDet.GuardarMantenimientoDet(item);
                        }
                    }


                    MessageBox.Show("Se guardó correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }
        private void Limpiar()
        {
            TxtKilometraje.Text = string.Empty;
            TxtProveedor.Text = string.Empty;
            txtID.Text = string.Empty;
            listaMantenimientos.Clear();
            DGVMantenimientosDet.AllowUserToAddRows = true;
            DGVMantenimientosDet.AllowUserToDeleteRows = true;
            ConfiguracionInicial();
        }
        private void FrmBuscar_MantenimientoSeleccionado(object sender, ContMantenimientosCab Mantenimiento)
        {
            try
            {
                /*Llena información del cabecero.*/
                txtID.Text = Mantenimiento.IdMantenimiento.ToString();
                TxtCostoTotal.Text = Mantenimiento.CostoTotal.ToString("N2");
                TxtKilometraje.Text = Mantenimiento.Kilometraje.ToString("N0");
                TxtProveedor.Text = Mantenimiento.Proveedor.ToString();
                CBUnidad.SelectedValue = Mantenimiento.id_Unidad;
                CBRemolque.SelectedValue = Mantenimiento.id_Remolque;

                if (Convert.ToInt32(CBUnidad.SelectedValue) == 0 || Convert.ToInt32(CBUnidad.SelectedValue) == 1)
                    RBRemolque.Checked = true;
                else
                    RBUnidad.Checked = true;

                    listaMantenimientos = new BindingList<ContMantenimientosDet>(lServiceMantenimientosDet.ObtenerMantenimientoDetPorId(Mantenimiento.IdMantenimiento));
                DGVMantenimientosDet.DataSource = listaMantenimientos;

                EsConsulta = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar el mantenimiento: " + ex.Message);
            }

        }

        #endregion
        #region "Eventos"
        private void RBUnidad_CheckedChanged(object sender, EventArgs e)
        {
            if (RBUnidad.Checked)
            {
                CBUnidad.Enabled = true;
                CBRemolque.Enabled = false;
                CBRemolque.SelectedIndex = -1;
            }
            else
            {
                CBUnidad.Enabled = false;
                CBUnidad.SelectedIndex = -1;
                CBRemolque.Enabled = true;
            }
        }
        private void ContFrmMantenimientos_Load(object sender, EventArgs e)
        {
            DGVMantenimientosDet.CellValueChanged += DGVMantenimientosDet_CellValueChanged;
            DGVMantenimientosDet.RowsAdded += DGVMantenimientosDet_RowsAdded;
            DGVMantenimientosDet.RowsRemoved += DGVMantenimientosDet_RowsRemoved;
            DGVMantenimientosDet.EditingControlShowing += DGVMantenimientosDet_EditingControlShowing;

        }

        private void DGVMantenimientosDet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarCostoTotal();
        }

        private void DGVMantenimientosDet_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ActualizarCostoTotal();
        }

        private void DGVMantenimientosDet_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ActualizarCostoTotal();
        }
        private void Txt_KeyPressSoloNumeros(object sender, KeyPressEventArgs e)
        {
            // Permitir dígitos, punto decimal y control (como backspace)
            if (!char .IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            TextBox txt = sender as TextBox;
            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
        private void DGVMantenimientosDet_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;
            if (txt == null) return;

            // Siempre removemos el handler primero
            txt.KeyPress -= Txt_KeyPressSoloNumeros;

            // Solo lo agregamos si estamos en la columna PrecioRefaccion
            if (DGVMantenimientosDet.CurrentCell.OwningColumn.Name == "PrecioRefaccion")
            {
                txt.KeyPress += Txt_KeyPressSoloNumeros;
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void TxtKilometraje_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos (0-9) y teclas de control como Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void TxtKilometraje_Leave(object sender, EventArgs e)
        {
            // Si está vacío, asigna "0"
            if (string.IsNullOrWhiteSpace(TxtKilometraje.Text))
            {
                TxtKilometraje.Text = "0";
                return;
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    txtID.Clear(); // Borra todo el texto
                    Limpiar();
                    e.SuppressKeyPress = true; // Opcional: evita que el sonido de tecla se reproduzca
                }
                else if (e.KeyCode == Keys.F3)
                {
                    Limpiar();
                    ContFrmBuscarMantenimientos frmBuscar = new ContFrmBuscarMantenimientos();
                    frmBuscar.MdiParent = this.MdiParent;

                    frmBuscar.FormBorderStyle = FormBorderStyle.FixedDialog;
                    frmBuscar.StartPosition = FormStartPosition.Manual;

                    int x = (this.MdiParent.ClientSize.Width - frmBuscar.Width) / 2;
                    int y = (this.MdiParent.ClientSize.Height - frmBuscar.Height) / 2;
                    frmBuscar.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

                    frmBuscar.MantenimientoSeleccionadoEvent += FrmBuscar_MantenimientoSeleccionado;

                    frmBuscar.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_esConsulta)
                {
                    DialogResult result = MessageBox.Show($"¿Estás seguro que deseas eliminar el mantenimiento {txtID.Text}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        lServiceMantenimientosCab.EliminarMantenimientoCab(Convert.ToInt32(txtID.Text));

                        lServiceMantenimientosDet.EliminarMantenimientoDetPorId(Convert.ToInt32(txtID.Text));
                        MessageBox.Show("Se eliminó correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ContFrmMantenimientos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Limpiar();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.G)
            {
                Guardar();
            }
        }
        #endregion


    }
}
