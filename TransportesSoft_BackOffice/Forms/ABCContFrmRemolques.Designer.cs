namespace TransportesSoft_BackOffice.Forms
{
    partial class ABCContFrmRemolques
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
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DTFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBOYear = new System.Windows.Forms.ComboBox();
            this.LblMarca = new System.Windows.Forms.Label();
            this.LblSerie = new System.Windows.Forms.Label();
            this.LblKilometraje = new System.Windows.Forms.Label();
            this.LblOperador = new System.Windows.Forms.Label();
            this.txtPlacas = new System.Windows.Forms.TextBox();
            this.LblProxMantenimiento = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtKilometraje = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.LblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.BtnEliminar.FlatAppearance.BorderSize = 2;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.ForeColor = System.Drawing.Color.Red;
            this.BtnEliminar.Location = new System.Drawing.Point(36, 303);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 19;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.DTFecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CBOYear);
            this.groupBox1.Controls.Add(this.LblMarca);
            this.groupBox1.Controls.Add(this.LblSerie);
            this.groupBox1.Controls.Add(this.LblKilometraje);
            this.groupBox1.Controls.Add(this.LblOperador);
            this.groupBox1.Controls.Add(this.txtPlacas);
            this.groupBox1.Controls.Add(this.LblProxMantenimiento);
            this.groupBox1.Controls.Add(this.txtMarca);
            this.groupBox1.Controls.Add(this.txtKilometraje);
            this.groupBox1.Controls.Add(this.txtModelo);
            this.groupBox1.Location = new System.Drawing.Point(18, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 255);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(140, 216);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(195, 20);
            this.dateTimePicker2.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(140, 190);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(195, 20);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // DTFecha
            // 
            this.DTFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFecha.Location = new System.Drawing.Point(140, 164);
            this.DTFecha.Name = "DTFecha";
            this.DTFecha.Size = new System.Drawing.Size(195, 20);
            this.DTFecha.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Impermeabilización:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fecha Físico SCT:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Fecha llantas:";
            // 
            // CBOYear
            // 
            this.CBOYear.FormattingEnabled = true;
            this.CBOYear.Location = new System.Drawing.Point(140, 112);
            this.CBOYear.Name = "CBOYear";
            this.CBOYear.Size = new System.Drawing.Size(195, 21);
            this.CBOYear.TabIndex = 4;
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
            this.LblSerie.Size = new System.Drawing.Size(45, 13);
            this.LblSerie.TabIndex = 1;
            this.LblSerie.Text = "Modelo:";
            // 
            // LblKilometraje
            // 
            this.LblKilometraje.AutoSize = true;
            this.LblKilometraje.Location = new System.Drawing.Point(15, 89);
            this.LblKilometraje.Name = "LblKilometraje";
            this.LblKilometraje.Size = new System.Drawing.Size(34, 13);
            this.LblKilometraje.TabIndex = 2;
            this.LblKilometraje.Text = "Serie:";
            // 
            // LblOperador
            // 
            this.LblOperador.AutoSize = true;
            this.LblOperador.Location = new System.Drawing.Point(15, 115);
            this.LblOperador.Name = "LblOperador";
            this.LblOperador.Size = new System.Drawing.Size(29, 13);
            this.LblOperador.TabIndex = 4;
            this.LblOperador.Text = "Año:";
            // 
            // txtPlacas
            // 
            this.txtPlacas.Location = new System.Drawing.Point(140, 138);
            this.txtPlacas.MaxLength = 10;
            this.txtPlacas.Name = "txtPlacas";
            this.txtPlacas.Size = new System.Drawing.Size(195, 20);
            this.txtPlacas.TabIndex = 5;
            // 
            // LblProxMantenimiento
            // 
            this.LblProxMantenimiento.AutoSize = true;
            this.LblProxMantenimiento.Location = new System.Drawing.Point(15, 141);
            this.LblProxMantenimiento.Name = "LblProxMantenimiento";
            this.LblProxMantenimiento.Size = new System.Drawing.Size(42, 13);
            this.LblProxMantenimiento.TabIndex = 5;
            this.LblProxMantenimiento.Text = "Placas:";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(140, 34);
            this.txtMarca.MaxLength = 15;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(195, 20);
            this.txtMarca.TabIndex = 1;
            // 
            // txtKilometraje
            // 
            this.txtKilometraje.Location = new System.Drawing.Point(140, 86);
            this.txtKilometraje.MaxLength = 999999;
            this.txtKilometraje.Name = "txtKilometraje";
            this.txtKilometraje.Size = new System.Drawing.Size(195, 20);
            this.txtKilometraje.TabIndex = 3;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(140, 60);
            this.txtModelo.MaxLength = 20;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(195, 20);
            this.txtModelo.TabIndex = 2;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(278, 303);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 17;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(33, 19);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(21, 13);
            this.LblID.TabIndex = 18;
            this.LblID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtID.Location = new System.Drawing.Point(60, 16);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(49, 20);
            this.txtID.TabIndex = 1;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // ABCContFrmRemolques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 338);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.txtID);
            this.Name = "ABCContFrmRemolques";
            this.ShowIcon = false;
            this.Text = "Control de Remolques";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CBOYear;
        private System.Windows.Forms.Label LblMarca;
        private System.Windows.Forms.Label LblSerie;
        private System.Windows.Forms.Label LblKilometraje;
        private System.Windows.Forms.Label LblOperador;
        private System.Windows.Forms.TextBox txtPlacas;
        private System.Windows.Forms.Label LblProxMantenimiento;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtKilometraje;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker DTFecha;
    }
}