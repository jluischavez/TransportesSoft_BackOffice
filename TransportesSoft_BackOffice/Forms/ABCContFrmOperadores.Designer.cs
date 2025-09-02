namespace TransportesSoft_BackOffice.Forms
{
    partial class ABCContFrmOperadores
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
            this.DTFechaEgreso = new System.Windows.Forms.DateTimePicker();
            this.DTFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.LblFechaEgreso = new System.Windows.Forms.Label();
            this.LblFechaIngreso = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.LblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DTFechaEgreso);
            this.groupBox1.Controls.Add(this.DTFechaIngreso);
            this.groupBox1.Controls.Add(this.LblFechaEgreso);
            this.groupBox1.Controls.Add(this.LblFechaIngreso);
            this.groupBox1.Controls.Add(this.LblNombre);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(8, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 121);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // DTFechaEgreso
            // 
            this.DTFechaEgreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFechaEgreso.Location = new System.Drawing.Point(140, 86);
            this.DTFechaEgreso.Name = "DTFechaEgreso";
            this.DTFechaEgreso.Size = new System.Drawing.Size(195, 20);
            this.DTFechaEgreso.TabIndex = 3;
            // 
            // DTFechaIngreso
            // 
            this.DTFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFechaIngreso.Location = new System.Drawing.Point(140, 60);
            this.DTFechaIngreso.Name = "DTFechaIngreso";
            this.DTFechaIngreso.Size = new System.Drawing.Size(195, 20);
            this.DTFechaIngreso.TabIndex = 2;
            // 
            // LblFechaEgreso
            // 
            this.LblFechaEgreso.AutoSize = true;
            this.LblFechaEgreso.Location = new System.Drawing.Point(15, 89);
            this.LblFechaEgreso.Name = "LblFechaEgreso";
            this.LblFechaEgreso.Size = new System.Drawing.Size(76, 13);
            this.LblFechaEgreso.TabIndex = 9;
            this.LblFechaEgreso.Text = "Fecha Egreso:";
            // 
            // LblFechaIngreso
            // 
            this.LblFechaIngreso.AutoSize = true;
            this.LblFechaIngreso.Location = new System.Drawing.Point(15, 63);
            this.LblFechaIngreso.Name = "LblFechaIngreso";
            this.LblFechaIngreso.Size = new System.Drawing.Size(78, 13);
            this.LblFechaIngreso.TabIndex = 7;
            this.LblFechaIngreso.Text = "Fecha Ingreso:";
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(15, 37);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(47, 13);
            this.LblNombre.TabIndex = 0;
            this.LblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(140, 34);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(195, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(12, 9);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(21, 13);
            this.LblID.TabIndex = 20;
            this.LblID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtID.Location = new System.Drawing.Point(39, 6);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(49, 20);
            this.txtID.TabIndex = 1;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.BtnEliminar.FlatAppearance.BorderSize = 2;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.ForeColor = System.Drawing.Color.Red;
            this.BtnEliminar.Location = new System.Drawing.Point(26, 160);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 4;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(268, 160);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 3;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // ABCContFrmOperadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 196);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ABCContFrmOperadores";
            this.ShowIcon = false;
            this.Text = "Control de Operadores";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABCContFrmOperadores_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DTFechaEgreso;
        private System.Windows.Forms.DateTimePicker DTFechaIngreso;
        private System.Windows.Forms.Label LblFechaEgreso;
        private System.Windows.Forms.Label LblFechaIngreso;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnGuardar;
    }
}