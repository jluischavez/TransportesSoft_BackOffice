using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportesSoft_BackOffice.Models;
using TransportesSoft_BackOffice.Services;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class Login : Base
    {
        Service_UsuariosCat lServiceUsuariosCat;
        public UsuariosCat lUsuario = new UsuariosCat();
        public Login()
        {
            InitializeComponent();
            lServiceUsuariosCat = new Service_UsuariosCat();
            TxtContrasena.UseSystemPasswordChar = true;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                // Confirmar si realmente quiere salir
                var confirm = MessageBox.Show("¿Deseas cerrar la aplicación?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = TxtUsuario.Text.Trim();
            string contraseñaIngresada = TxtContrasena.Text;

            if (string.IsNullOrEmpty(nombreUsuario))
            {
                MessageBox.Show("El campo 'Usuario' es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UsuariosCat usuario = lServiceUsuariosCat.ObtenerUsuarioPorNombre(nombreUsuario);

            if (usuario == null)
            {
                MessageBox.Show("El usuario no existe ó está inactivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtUsuario.Clear();
                TxtContrasena.Clear();
                TxtUsuario.Focus();
                return;
            }

            // Si no escribió nada y el usuario no tiene contraseña en BD
            if (string.IsNullOrWhiteSpace(contraseñaIngresada) && string.IsNullOrEmpty(usuario.ContrasenaHash))
            {
                MessageBox.Show("Este usuario no tiene contraseña. Debe establecer una antes de iniciar sesión.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el formulario para establecer contraseña
                var frmEstablecer = new SegFrmUsuariosCat(nombreUsuario, usuario.Id);
                frmEstablecer.StartPosition = FormStartPosition.CenterScreen;
                frmEstablecer.ShowDialog();

                // Después de cerrar, puedes volver a intentar el login o cerrar este formulario
                return;
            }

            // Validar contraseña si existe
            bool esValido = lServiceUsuariosCat.ValidarContraseña(contraseñaIngresada, usuario.ContrasenaHash);
            if (esValido)
            {
                this.DialogResult = DialogResult.OK;
                lUsuario.Id = usuario.Id;
                lUsuario.NombreUsuario = usuario.NombreUsuario;
                this.Close();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtContrasena.Clear();
                TxtContrasena.Focus();
            }
        }

        private void TxtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido de "ding"
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TxtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido de "ding"
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
