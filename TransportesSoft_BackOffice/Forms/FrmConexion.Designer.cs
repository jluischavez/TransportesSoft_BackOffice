namespace TransportesSoft_BackOffice.Forms
{
    partial class FrmConexion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBSqlAuth = new System.Windows.Forms.RadioButton();
            this.RBWindowsAuth = new System.Windows.Forms.RadioButton();
            this.txtUserSQLAuth = new System.Windows.Forms.TextBox();
            this.txtPasswordSQLAuth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CBServer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CBDB = new System.Windows.Forms.ComboBox();
            this.BtnProbarConexion = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBSqlAuth);
            this.groupBox1.Controls.Add(this.RBWindowsAuth);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Conexión:";
            // 
            // RBSqlAuth
            // 
            this.RBSqlAuth.AutoSize = true;
            this.RBSqlAuth.Location = new System.Drawing.Point(252, 25);
            this.RBSqlAuth.Name = "RBSqlAuth";
            this.RBSqlAuth.Size = new System.Drawing.Size(71, 17);
            this.RBSqlAuth.TabIndex = 1;
            this.RBSqlAuth.TabStop = true;
            this.RBSqlAuth.Text = "SQL Auth";
            this.RBSqlAuth.UseVisualStyleBackColor = true;
            // 
            // RBWindowsAuth
            // 
            this.RBWindowsAuth.AutoSize = true;
            this.RBWindowsAuth.Location = new System.Drawing.Point(20, 25);
            this.RBWindowsAuth.Name = "RBWindowsAuth";
            this.RBWindowsAuth.Size = new System.Drawing.Size(94, 17);
            this.RBWindowsAuth.TabIndex = 0;
            this.RBWindowsAuth.TabStop = true;
            this.RBWindowsAuth.Text = "Windows Auth";
            this.RBWindowsAuth.UseVisualStyleBackColor = true;
            // 
            // txtUserSQLAuth
            // 
            this.txtUserSQLAuth.Location = new System.Drawing.Point(65, 106);
            this.txtUserSQLAuth.Name = "txtUserSQLAuth";
            this.txtUserSQLAuth.Size = new System.Drawing.Size(100, 20);
            this.txtUserSQLAuth.TabIndex = 1;
            // 
            // txtPasswordSQLAuth
            // 
            this.txtPasswordSQLAuth.Location = new System.Drawing.Point(257, 106);
            this.txtPasswordSQLAuth.Name = "txtPasswordSQLAuth";
            this.txtPasswordSQLAuth.Size = new System.Drawing.Size(100, 20);
            this.txtPasswordSQLAuth.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña:";
            // 
            // CBServer
            // 
            this.CBServer.FormattingEnabled = true;
            this.CBServer.Location = new System.Drawing.Point(186, 171);
            this.CBServer.Name = "CBServer";
            this.CBServer.Size = new System.Drawing.Size(121, 21);
            this.CBServer.TabIndex = 5;
            this.CBServer.SelectedIndexChanged += new System.EventHandler(this.CBServer_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Servidor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Base de Datos:";
            // 
            // CBDB
            // 
            this.CBDB.FormattingEnabled = true;
            this.CBDB.Location = new System.Drawing.Point(186, 221);
            this.CBDB.Name = "CBDB";
            this.CBDB.Size = new System.Drawing.Size(121, 21);
            this.CBDB.TabIndex = 7;
            // 
            // BtnProbarConexion
            // 
            this.BtnProbarConexion.Location = new System.Drawing.Point(16, 290);
            this.BtnProbarConexion.Name = "BtnProbarConexion";
            this.BtnProbarConexion.Size = new System.Drawing.Size(102, 23);
            this.BtnProbarConexion.TabIndex = 9;
            this.BtnProbarConexion.Text = "Verificar Conexión";
            this.BtnProbarConexion.UseVisualStyleBackColor = true;
            this.BtnProbarConexion.Click += new System.EventHandler(this.BtnProbarConexion_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(257, 290);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 10;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // FrmConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 329);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnProbarConexion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CBDB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CBServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPasswordSQLAuth);
            this.Controls.Add(this.txtUserSQLAuth);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmConexion";
            this.Text = "Establecer Conexión";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBSqlAuth;
        private System.Windows.Forms.RadioButton RBWindowsAuth;
        private System.Windows.Forms.TextBox txtUserSQLAuth;
        private System.Windows.Forms.TextBox txtPasswordSQLAuth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBDB;
        private System.Windows.Forms.Button BtnProbarConexion;
        private System.Windows.Forms.Button BtnGuardar;
    }
}