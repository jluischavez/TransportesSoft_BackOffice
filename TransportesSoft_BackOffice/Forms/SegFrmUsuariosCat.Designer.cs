namespace TransportesSoft_BackOffice.Forms
{
    partial class SegFrmUsuariosCat
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
            this.TxtNombreUsuario = new System.Windows.Forms.TextBox();
            this.TxtContrasena = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.LblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CBORol = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtNombreUsuario
            // 
            this.TxtNombreUsuario.Location = new System.Drawing.Point(79, 28);
            this.TxtNombreUsuario.Name = "TxtNombreUsuario";
            this.TxtNombreUsuario.Size = new System.Drawing.Size(173, 20);
            this.TxtNombreUsuario.TabIndex = 0;
            // 
            // TxtContrasena
            // 
            this.TxtContrasena.Location = new System.Drawing.Point(79, 58);
            this.TxtContrasena.Name = "TxtContrasena";
            this.TxtContrasena.Size = new System.Drawing.Size(173, 20);
            this.TxtContrasena.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña:";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.BtnEliminar.FlatAppearance.BorderSize = 2;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.ForeColor = System.Drawing.Color.Red;
            this.BtnEliminar.Location = new System.Drawing.Point(15, 162);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 20;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(198, 162);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 19;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(12, 9);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(21, 13);
            this.LblID.TabIndex = 21;
            this.LblID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtID.Location = new System.Drawing.Point(39, 6);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(49, 20);
            this.txtID.TabIndex = 18;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CBORol);
            this.groupBox1.Controls.Add(this.TxtContrasena);
            this.groupBox1.Controls.Add(this.TxtNombreUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 124);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rol:";
            // 
            // CBORol
            // 
            this.CBORol.FormattingEnabled = true;
            this.CBORol.Location = new System.Drawing.Point(79, 84);
            this.CBORol.Name = "CBORol";
            this.CBORol.Size = new System.Drawing.Size(173, 21);
            this.CBORol.TabIndex = 5;
            // 
            // SegFrmUsuariosCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 198);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.txtID);
            this.Name = "SegFrmUsuariosCat";
            this.Text = "Registro de Usuarios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNombreUsuario;
        private System.Windows.Forms.TextBox TxtContrasena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBORol;
    }
}