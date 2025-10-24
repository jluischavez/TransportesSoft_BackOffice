using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using TransportesSoft_BackOffice.Clases;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class FrmConexion : Base
    {
        public FrmConexion()
        {
            InitializeComponent();
            CargarServidores();
        }

        private void CargarServidores()
        {
            var dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            CBServer.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string servidor = row["ServerName"].ToString();
                string instancia = row["InstanceName"].ToString();

                string nombreCompleto = string.IsNullOrEmpty(instancia) ? servidor : $"{servidor}\\{instancia}";
                CBServer.Items.Add(nombreCompleto);
            }
        }

        private void CargarBasesDatos()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = CBServer.Text,
                InitialCatalog = "master"
            };

            // Autenticación según RadioButton
            if (RBWindowsAuth.Checked)
            {
                builder.IntegratedSecurity = true;
            }
            else if (RBSqlAuth.Checked)
            {
                builder.IntegratedSecurity = false;
                builder.UserID = txtUserSQLAuth.Text;
                builder.Password = txtPasswordSQLAuth.Text;
            }

            try
            {
                using (var conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", conn);
                    var reader = cmd.ExecuteReader();

                    CBDB.Items.Clear();
                    while (reader.Read())
                    {
                        CBDB.Items.Add(reader.GetString(0));
                    }

                    if (CBDB.Items.Count > 0)
                        CBDB.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar bases de datos:\n" + ex.Message, "Conexión fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ProbarConexion()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = CBServer.Text,
                InitialCatalog = CBDB.Text
            };

            // Autenticación según selección
            if (RBWindowsAuth.Checked)
            {
                builder.IntegratedSecurity = true;
            }
            else if (RBSqlAuth.Checked)
            {
                builder.IntegratedSecurity = false;
                builder.UserID = txtUserSQLAuth.Text;
                builder.Password = txtPasswordSQLAuth.Text;
            }

            try
            {
                using (var conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    MessageBox.Show("✅ Conexión exitosa", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error de conexión:\n" + ex.Message, "Conexión fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void GuardarConexion()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = CBServer.Text,
                InitialCatalog = CBDB.Text
            };

            // Autenticación según selección
            if (RBWindowsAuth.Checked)
            {
                builder.IntegratedSecurity = true;
            }
            else if (RBSqlAuth.Checked)
            {
                builder.IntegratedSecurity = false;
                builder.UserID = txtUserSQLAuth.Text;
                builder.Password = txtPasswordSQLAuth.Text;
            }

            var config = new ConfigConexion { CadenaConexion = builder.ConnectionString };
            var json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText("config_conexion.json", json);

            MessageBox.Show("✅ Conexión guardada correctamente", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarConexion();
        }

        private void BtnProbarConexion_Click(object sender, EventArgs e)
        {
            ProbarConexion();
        }

        private void CBServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarBasesDatos();
        }
    }
}
