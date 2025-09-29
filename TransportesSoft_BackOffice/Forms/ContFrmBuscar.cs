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
using TransportesSoft_BackOffice.Models;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class ContFrmBuscar : Base
    {
        #region "Declaraciones"
        /*CONTABILIDAD UNIDADES*/
        private List<ContUnidadesCat> lContUnidades;
        private Service_ContUnidadesCat lServiceContUnidades;
        private BindingSource bindingSourceUnidades = new BindingSource();
        public ContUnidadesCat UnidadSeleccionada { get; private set; }
        public event EventHandler<ContUnidadesCat> UnidadSeleccionadaEvent;

        /*CONTABILIDAD CLIENTES*/
        private List<ContClientesCat> lContClientes;
        private Service_ContClientesCat lServiceContClientes;
        private BindingSource bindingSourceClientes = new BindingSource();
        public ContClientesCat ClienteSeleccionado { get; private set; }
        public event EventHandler<ContClientesCat> ClienteSeleccionadoEvent;

        /*CONTABILIDAD REMOLQUES*/
        private List<ContRemolquesCat> lContRemolques;
        private Service_ContRemolquesCat lServiceContRemolques;
        private BindingSource bindingSourceRemolques = new BindingSource();
        public ContRemolquesCat RemolqueSeleccionado { get; private set; }
        public event EventHandler<ContRemolquesCat> RemolqueSeleccionadoEvent;

        /*CONTABILIDAD OPERADORES*/
        private List<ContOperadores> lContOperadores;
        private Service_ContOperadoresCat lServiceContOperadores;
        private BindingSource bindingSourceOperadores = new BindingSource();
        public ContOperadores OperadorSeleccionado { get; private set; }
        public event EventHandler<ContOperadores> OperadorSeleccionadoEvent;

        /*Municipios Cat*/
        private List<MunicipiosCatYEstado> lMunicipiosCat;
        private Service_MunicipiosCat lServiceMunicipiosCat;
        private BindingSource bindingSourceMunicipiosCat = new BindingSource();
        public MunicipiosCat MunicipioSeleccionado { get; private set; }
        public event EventHandler<MunicipiosCat> MunicipioSeleccionadoEvent;

        /*Usuarios Cat*/
        private List<UsuariosCat> lUsuariosCat;
        private Service_UsuariosCat lServiceUsuariosCat;
        private BindingSource bindingSourceUsuariosCat = new BindingSource();
        public UsuariosCat UsuarioSeleccionado { get; private set; }
        public event EventHandler<UsuariosCat> UsuarioSeleccionadoEvent;

        private TipoBusqueda TipoFormulario;
        #endregion
        public enum TipoBusqueda
        {
            ContUnidades = 1,
            ContClientes = 2,
            ContRemolques = 3,
            ContOperadores = 4,
            MunicipiosCat = 5,
            MantenimientoUnidades = 6,
            MantenimientoRemolques = 8,
            UsuariosCat = 9
        }
        #region "Constructor"
        public ContFrmBuscar(string titulo, TipoBusqueda tipobusqueda)
        {
            InitializeComponent();

            TipoFormulario = tipobusqueda;

            this.Text = this.Text + " " + titulo;
            if (TipoFormulario == TipoBusqueda.ContUnidades)
            {
                lContUnidades = new List<ContUnidadesCat>();
                lServiceContUnidades = new Service_ContUnidadesCat();
                BuscarUnidades();
            }
            else if (TipoFormulario == TipoBusqueda.ContClientes)
            {
                lContClientes = new List<ContClientesCat>();
                lServiceContClientes = new Service_ContClientesCat();
                BuscarClientes();
            }
            else if (TipoFormulario == TipoBusqueda.ContRemolques)
            {
                lContRemolques = new List<ContRemolquesCat>();
                lServiceContRemolques = new Service_ContRemolquesCat();
                BuscarRemolques();
            }
            else if (TipoFormulario == TipoBusqueda.ContOperadores)
            {
                lContOperadores = new List<ContOperadores>();
                lServiceContOperadores = new Service_ContOperadoresCat();
                BuscarOperadores();
            }
            else if(TipoFormulario == TipoBusqueda.MunicipiosCat)
            {
                lMunicipiosCat = new List<MunicipiosCatYEstado>();
                lServiceMunicipiosCat = new Service_MunicipiosCat();
                BuscarMunicipios();
            }
            else if (TipoFormulario == TipoBusqueda.UsuariosCat)
            {
                lUsuariosCat = new List<UsuariosCat>();
                lServiceUsuariosCat = new Service_UsuariosCat();
                BuscarUsuarios();
            }
        }
        #endregion
        #region "Private"
        private void BuscarUsuarios()
        {
            try
            {
                lUsuariosCat = lServiceUsuariosCat.ObtenerUsuarios();
                bindingSourceUsuariosCat.DataSource = lUsuariosCat;
                DGV_Unidades.DataSource = bindingSourceUsuariosCat;
                ConfigurarGridUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error al consultar los usuarios: " + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
        private void BuscarOperadores()
        {
            try
            {
                lContOperadores = lServiceContOperadores.ObtenerOperadores();
                bindingSourceOperadores.DataSource = lContOperadores;
                DGV_Unidades.DataSource = bindingSourceOperadores;
                ConfigurarGridOperadores();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error", "Error al consultar los operadores: " + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BuscarMunicipios()
        {
            try
            {
                lMunicipiosCat = lServiceMunicipiosCat.ObtenerMunicipiosYEstado();
                bindingSourceMunicipiosCat.DataSource = lMunicipiosCat;
                DGV_Unidades.DataSource = bindingSourceMunicipiosCat;
                ConfigurarGridMunicipios();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error", "Error al consultar los municipios: " + ex.InnerException, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGridUsuarios()
        {
            DGV_Unidades.ReadOnly = true;
            DGV_Unidades.AllowUserToAddRows = false;
            DGV_Unidades.AllowUserToDeleteRows = false;
            DGV_Unidades.AllowUserToOrderColumns = false;
            DGV_Unidades.AllowUserToResizeColumns = false;
            DGV_Unidades.AllowUserToResizeRows = false;
            DGV_Unidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Unidades.MultiSelect = false;
            DGV_Unidades.Columns["Id"].Width = 50;
            DGV_Unidades.Columns["NombreUsuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_Unidades.Columns["ContrasenaHash"].Visible = false;
            DGV_Unidades.Columns["FechaRegistro"].Visible = false;
            DGV_Unidades.Columns["Activo"].Visible = false;
        }
        private void ConfigurarGridMunicipios()
        {
            DGV_Unidades.ReadOnly = true;
            DGV_Unidades.AllowUserToAddRows = false;
            DGV_Unidades.AllowUserToDeleteRows = false;
            DGV_Unidades.AllowUserToOrderColumns = false;
            DGV_Unidades.AllowUserToResizeColumns = false;
            DGV_Unidades.AllowUserToResizeRows = false;
            DGV_Unidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Unidades.MultiSelect = false;
            DGV_Unidades.Columns["idMunicipio"].Width = 50;
            DGV_Unidades.Columns["Estado"].Width = 120;
            DGV_Unidades.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_Unidades.Columns["idEstado"].Visible = false;
            DGV_Unidades.Columns["ClaveInegi"].Visible = false;
            DGV_Unidades.Columns["Activo"].Visible = false;
        }
        private void ConfigurarGridOperadores()
        {
            DGV_Unidades.ReadOnly = true;
            DGV_Unidades.AllowUserToAddRows = false;
            DGV_Unidades.AllowUserToDeleteRows = false;
            DGV_Unidades.AllowUserToOrderColumns = false;
            DGV_Unidades.AllowUserToResizeColumns = false;
            DGV_Unidades.AllowUserToResizeRows = false;
            DGV_Unidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Unidades.MultiSelect = false;

            DGV_Unidades.Columns["id_Operador"].Width = 50;
            DGV_Unidades.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV_Unidades.Columns["FechaIngreso"].Visible = false;
            DGV_Unidades.Columns["FechaEgreso"].Visible = false;
            DGV_Unidades.Columns["Estatus"].Visible = false;
            DGV_Unidades.Columns["Descripcion"].Visible = false;
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

            DGV_Unidades.Columns["FechaActualizacion"].Visible = false;
            DGV_Unidades.Columns["id_Operador"].Visible = false;
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
            DGV_Unidades.Columns["Descripcion"].Visible = false;
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
                ContUnidadesCat unidad = new ContUnidadesCat
                {
                    id_Unidad = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["id_Unidad"].Value),
                    Marca = DGV_Unidades.Rows[rowIndex].Cells["Marca"].Value?.ToString(),
                    Serie = DGV_Unidades.Rows[rowIndex].Cells["Serie"].Value?.ToString(),
                    FechaActualizacion = Convert.ToDateTime(DGV_Unidades.Rows[rowIndex].Cells["FechaActualizacion"].Value),
                    id_Operador = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["id_Operador"].Value),
                    id_Remolque = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["id_Remolque"].Value)
                };

                UnidadSeleccionadaEvent?.Invoke(this, unidad);
            }
            else if (TipoFormulario == TipoBusqueda.ContClientes)
            {
                ContClientesCat unidad = new ContClientesCat
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
                ContRemolquesCat Remolque = new ContRemolquesCat
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
            else if(TipoFormulario == TipoBusqueda.ContOperadores)
            {
                ContOperadores Operador = new ContOperadores()
                {
                    id_Operador = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["id_Operador"].Value),
                    Nombre = DGV_Unidades.Rows[rowIndex].Cells["Nombre"].Value?.ToString(),
                    FechaIngreso = Convert.ToDateTime(DGV_Unidades.Rows[rowIndex].Cells["FechaIngreso"].Value),
                    FechaEgreso = Convert.ToDateTime(DGV_Unidades.Rows[rowIndex].Cells["FechaEgreso"].Value)
                };

                OperadorSeleccionadoEvent?.Invoke(this, Operador);
            }
            else if(TipoFormulario == TipoBusqueda.MunicipiosCat)
            {
                MunicipiosCat Municipio = new MunicipiosCat()
                {
                    IdMunicipio = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["IdMunicipio"].Value),
                    Nombre = DGV_Unidades.Rows[rowIndex].Cells["Nombre"].Value?.ToString(),
                    IdEstado = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["IdEstado"].Value),
                    ClaveInegi = DGV_Unidades.Rows[rowIndex].Cells["ClaveInegi"].Value?.ToString(),
                };
                MunicipioSeleccionadoEvent.Invoke(this, Municipio);
            }
            else if(TipoFormulario == TipoBusqueda.UsuariosCat)
            {
                UsuariosCat usuario = new UsuariosCat()
                {
                    Id = Convert.ToInt32(DGV_Unidades.Rows[rowIndex].Cells["Id"].Value),
                    NombreUsuario = DGV_Unidades.Rows[rowIndex].Cells["NombreUsuario"].Value?.ToString(),
                    ContrasenaHash = DGV_Unidades.Rows[rowIndex].Cells["ContrasenaHash"].Value?.ToString(),
                    FechaRegistro = Convert.ToDateTime(DGV_Unidades.Rows[rowIndex].Cells["FechaRegistro"].Value),
                    Activo = Convert.ToBoolean(DGV_Unidades.Rows[rowIndex].Cells["Activo"].Value)
                };
                UsuarioSeleccionadoEvent?.Invoke(this, usuario);
            }

                this.Close();
        }
        #endregion
        #region "Eventos"
        private void DGV_Unidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RegresarInformacion(e.RowIndex);
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
            /*CONT OPERADORES*/
            else if (TipoFormulario == TipoBusqueda.ContOperadores)
            {
                if (string.IsNullOrEmpty(filtro))
                {
                    bindingSourceOperadores.DataSource = lContOperadores;
                }
                else
                {
                    var filtradas = lContOperadores
                        .Where(u => u.Nombre.ToLower().Contains(filtro))
                        .ToList();

                    bindingSourceOperadores.DataSource = filtradas;
                }
            }
            /*MUNICIPIOS*/
            else if(TipoFormulario == TipoBusqueda.MunicipiosCat)
            {
                if (string.IsNullOrEmpty(filtro))
                {
                    bindingSourceMunicipiosCat.DataSource = lMunicipiosCat;
                }
                else
                {
                    var filtradas = lMunicipiosCat
                        .Where(u => u.Nombre.ToLower().Contains(filtro) ||
                        u.Estado.ToLower().Contains(filtro) ||
                        u.idMunicipio.ToString().Contains(filtro) ||
                        u.ClaveInegi.ToString().Contains(filtro))
                        .ToList();

                    bindingSourceMunicipiosCat.DataSource = filtradas;
                }
            }
            /*Usuarios Cat*/
            else if(TipoFormulario == TipoBusqueda.UsuariosCat)
            {
                if (string.IsNullOrEmpty(filtro))
                {
                    bindingSourceUsuariosCat.DataSource = lUsuariosCat;
                }
                else
                {
                    var filtradas = lUsuariosCat
                        .Where(u => u.Id.ToString().Contains(filtro) ||
                                    u.NombreUsuario.ToLower().Contains(filtro))
                        .ToList();
                    bindingSourceUsuariosCat.DataSource = filtradas;
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
            else if (TipoFormulario == TipoBusqueda.ContOperadores)
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
            else if (TipoFormulario == TipoBusqueda.UsuariosCat)
            {
                if (DGV_Unidades.Columns["Activo"] != null && e.RowIndex >= 0)
                {
                    bool activoValue = Convert.ToBoolean(DGV_Unidades.Rows[e.RowIndex].Cells["Activo"].Value);
                    if (!activoValue)
                    {
                        DGV_Unidades.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(234, 171, 56);
                    }
                }
            }
        }
        #endregion
    }
}
