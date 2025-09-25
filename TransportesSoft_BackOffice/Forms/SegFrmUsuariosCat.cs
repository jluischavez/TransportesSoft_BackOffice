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

namespace TransportesSoft_BackOffice.Forms
{
    public partial class SegFrmUsuariosCat : Base
    {
        private string lnombreUsuario;
        private Service_UsuariosCat lService_UsuariosCat;
        private Service_RolesCat lService_RolesCat;
        private Service_UsuarioRoles lService_UsuarioRoles;
        private int lidUsuario;

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
        public SegFrmUsuariosCat(string nombreUsuario = "", int idUsuario = 0)
        {
            InitializeComponent();

            lService_UsuariosCat = new Service_UsuariosCat();
            lService_RolesCat = new Service_RolesCat();
            lService_UsuarioRoles = new Service_UsuarioRoles();
            LlenarComboRoles();
            BtnEliminar.Enabled = false;
            this.KeyPreview = true;
            if (!string.IsNullOrEmpty(nombreUsuario))
            {
                lnombreUsuario = nombreUsuario;
                TxtNombreUsuario.Text = nombreUsuario;
                TxtNombreUsuario.Enabled = false;
                lidUsuario = idUsuario;
                int idRol = lService_UsuarioRoles.ObtenerIDRolPorIDUsuario(idUsuario);
                CBORol.SelectedValue = idRol;
                CBORol.Enabled = false;
                txtID.Enabled = false;
                TxtContrasena.Focus();
                EsConsulta = true;
                BtnEliminar.Enabled = false;
            }
        }
        

        public void LlenarComboRoles()
        {
            /* Traemos Roles y llenamos el ComboBox */
            List<RolesCat> roles = lService_RolesCat.ObtenerRoles();
            CBORol.DataSource = roles;
            CBORol.DisplayMember = "Nombre";
            CBORol.ValueMember = "Id";
            CBORol.SelectedIndex = -1;
            CBORol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(TxtNombreUsuario.Text))
            {
                MessageBox.Show("El campo 'Nombre de Usuario' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtNombreUsuario.Focus();
                return false;
            }
            if (CBORol.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol para el usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBORol.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TxtContrasena.Text))
            {
                DialogResult result = MessageBox.Show($"¿Estás seguro que deseas guardar el usuario sin contraseña?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    return true;
                else
                    return false;
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
                    if (!ValidarCampos())
                        return;

                    UsuariosCat usuariosCat = new UsuariosCat();

                    usuariosCat.NombreUsuario = TxtNombreUsuario.Text.Trim();
                    if(string.IsNullOrEmpty(TxtContrasena.Text.Trim()))
                        usuariosCat.ContrasenaHash = null;
                    else
                        usuariosCat.ContrasenaHash = lService_UsuariosCat.HashContrasena(TxtContrasena.Text.Trim());

                    if (!_esConsulta)
                    {
                        int idUsuario = lService_UsuariosCat.GuardarUsuario(usuariosCat);

                        lService_UsuarioRoles.GuardarUsuarioRol(idUsuario, (int)CBORol.SelectedValue);
                        MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        usuariosCat.Id = lidUsuario;
                        lService_UsuariosCat.ActualizarContrasena(usuariosCat.Id, usuariosCat.ContrasenaHash);
                        MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    txtID.Clear(); // Borra todo el texto
                    e.SuppressKeyPress = true; // Opcional: evita que el sonido de tecla se reproduzca
                }
                else if (e.KeyCode == Keys.F3)
                {
                    ContFrmBuscar frmBuscar = new ContFrmBuscar("Usuarios", ContFrmBuscar.TipoBusqueda.UsuariosCat);
                    frmBuscar.MdiParent = this.MdiParent;

                    frmBuscar.FormBorderStyle = FormBorderStyle.FixedDialog;
                    frmBuscar.StartPosition = FormStartPosition.Manual;

                    int x = (this.MdiParent.ClientSize.Width - frmBuscar.Width) / 2;
                    int y = (this.MdiParent.ClientSize.Height - frmBuscar.Height) / 2;
                    frmBuscar.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

                    frmBuscar.UsuarioSeleccionadoEvent += FrmBuscar_UsuarioSeleccionado;

                    frmBuscar.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmBuscar_UsuarioSeleccionado(object sender, UsuariosCat usuario)
        {
            txtID.Text = usuario.Id.ToString();
            TxtNombreUsuario.Text = usuario.NombreUsuario;
            TxtContrasena.Focus();
            lidUsuario = usuario.Id;
            int idRol = lService_UsuarioRoles.ObtenerIDRolPorIDUsuario(lidUsuario);
            CBORol.SelectedValue = idRol;
            CBORol.Enabled = false;
            TxtNombreUsuario.Enabled = false;
            EsConsulta = true;
        }

        private void Limpiar()
        {
            txtID.Text = "";
            TxtNombreUsuario.Text = "";
            TxtContrasena.Text = "";
            CBORol.SelectedIndex = -1;
            TxtNombreUsuario.Enabled = true;
            CBORol.Enabled = true;
            EsConsulta = false;
            TxtNombreUsuario.Focus();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_esConsulta)
                {
                    DialogResult result = MessageBox.Show($"¿Estás seguro que deseas eliminar el usuario {txtID.Text} - {TxtNombreUsuario.Text}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        lService_UsuariosCat.DesactivarUsuario(Convert.ToInt32(txtID.Text));

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
    }
}
