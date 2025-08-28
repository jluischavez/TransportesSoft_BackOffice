namespace TransportesSoft_BackOffice.Forms
{
    partial class ABCContFrmUnidades
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
            this.LblMarca = new System.Windows.Forms.Label();
            this.LblSerie = new System.Windows.Forms.Label();
            this.LblKilometraje = new System.Windows.Forms.Label();
            this.LblOperador = new System.Windows.Forms.Label();
            this.LblProxMantenimiento = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtKilometraje = new System.Windows.Forms.TextBox();
            this.txtProxMantenimiento = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.LblID = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBRemolques = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBOperadores = new System.Windows.Forms.ComboBox();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblMarca
            // 
            this.LblMarca.AutoSize = true;
            this.LblMarca.Location = new System.Drawing.Point(15, 37);
            this.LblMarca.Name = "LblMarca";
            this.LblMarca.Size = new System.Drawing.Size(40, 13);
            this.LblMarca.TabIndex = 0;
            this.LblMarca.Text = "Marca:";
            // 
            // LblSerie
            // 
            this.LblSerie.AutoSize = true;
            this.LblSerie.Location = new System.Drawing.Point(15, 63);
            this.LblSerie.Name = "LblSerie";
            this.LblSerie.Size = new System.Drawing.Size(34, 13);
            this.LblSerie.TabIndex = 1;
            this.LblSerie.Text = "Serie:";
            // 
            // LblKilometraje
            // 
            this.LblKilometraje.AutoSize = true;
            this.LblKilometraje.Location = new System.Drawing.Point(15, 89);
            this.LblKilometraje.Name = "LblKilometraje";
            this.LblKilometraje.Size = new System.Drawing.Size(61, 13);
            this.LblKilometraje.TabIndex = 2;
            this.LblKilometraje.Text = "Kilometraje:";
            // 
            // LblOperador
            // 
            this.LblOperador.AutoSize = true;
            this.LblOperador.Location = new System.Drawing.Point(15, 115);
            this.LblOperador.Name = "LblOperador";
            this.LblOperador.Size = new System.Drawing.Size(54, 13);
            this.LblOperador.TabIndex = 4;
            this.LblOperador.Text = "Operador:";
            // 
            // LblProxMantenimiento
            // 
            this.LblProxMantenimiento.AutoSize = true;
            this.LblProxMantenimiento.Location = new System.Drawing.Point(15, 141);
            this.LblProxMantenimiento.Name = "LblProxMantenimiento";
            this.LblProxMantenimiento.Size = new System.Drawing.Size(119, 13);
            this.LblProxMantenimiento.TabIndex = 5;
            this.LblProxMantenimiento.Text = "Próximo Mantenimiento:";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(140, 34);
            this.txtMarca.MaxLength = 15;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(195, 20);
            this.txtMarca.TabIndex = 1;
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(140, 60);
            this.txtSerie.MaxLength = 20;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(195, 20);
            this.txtSerie.TabIndex = 2;
            // 
            // txtKilometraje
            // 
            this.txtKilometraje.Location = new System.Drawing.Point(140, 86);
            this.txtKilometraje.MaxLength = 999999;
            this.txtKilometraje.Name = "txtKilometraje";
            this.txtKilometraje.Size = new System.Drawing.Size(195, 20);
            this.txtKilometraje.TabIndex = 3;
            this.txtKilometraje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKilometraje_KeyPress);
            this.txtKilometraje.Leave += new System.EventHandler(this.txtKilometraje_Leave);
            // 
            // txtProxMantenimiento
            // 
            this.txtProxMantenimiento.Location = new System.Drawing.Point(140, 138);
            this.txtProxMantenimiento.MaxLength = 999999;
            this.txtProxMantenimiento.Name = "txtProxMantenimiento";
            this.txtProxMantenimiento.Size = new System.Drawing.Size(195, 20);
            this.txtProxMantenimiento.TabIndex = 5;
            this.txtProxMantenimiento.Leave += new System.EventHandler(this.txtProxMantenimiento_Leave);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtID.Location = new System.Drawing.Point(54, 16);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(49, 20);
            this.txtID.TabIndex = 1;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(27, 19);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(21, 13);
            this.LblID.TabIndex = 13;
            this.LblID.Text = "ID:";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(272, 251);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 6;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CBRemolques);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CBOperadores);
            this.groupBox1.Controls.Add(this.LblMarca);
            this.groupBox1.Controls.Add(this.LblSerie);
            this.groupBox1.Controls.Add(this.LblKilometraje);
            this.groupBox1.Controls.Add(this.LblOperador);
            this.groupBox1.Controls.Add(this.txtProxMantenimiento);
            this.groupBox1.Controls.Add(this.LblProxMantenimiento);
            this.groupBox1.Controls.Add(this.txtMarca);
            this.groupBox1.Controls.Add(this.txtKilometraje);
            this.groupBox1.Controls.Add(this.txtSerie);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 203);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // CBRemolques
            // 
            this.CBRemolques.FormattingEnabled = true;
            this.CBRemolques.Location = new System.Drawing.Point(140, 164);
            this.CBRemolques.Name = "CBRemolques";
            this.CBRemolques.Size = new System.Drawing.Size(195, 21);
            this.CBRemolques.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Remolque:";
            // 
            // CBOperadores
            // 
            this.CBOperadores.FormattingEnabled = true;
            this.CBOperadores.Location = new System.Drawing.Point(140, 112);
            this.CBOperadores.Name = "CBOperadores";
            this.CBOperadores.Size = new System.Drawing.Size(195, 21);
            this.CBOperadores.TabIndex = 4;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.BtnEliminar.FlatAppearance.BorderSize = 2;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.ForeColor = System.Drawing.Color.Red;
            this.BtnEliminar.Location = new System.Drawing.Point(30, 251);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 7;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // ABCContFrmUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 285);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.txtID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ABCContFrmUnidades";
            this.ShowIcon = false;
            this.Text = "Control de Unidades";
            this.Load += new System.EventHandler(this.ABCContFrmUnidades_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABCContFrmUnidades_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblMarca;
        private System.Windows.Forms.Label LblSerie;
        private System.Windows.Forms.Label LblKilometraje;
        private System.Windows.Forms.Label LblOperador;
        private System.Windows.Forms.Label LblProxMantenimiento;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtKilometraje;
        private System.Windows.Forms.TextBox txtProxMantenimiento;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CBOperadores;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.ComboBox CBRemolques;
        private System.Windows.Forms.Label label1;
    }
}