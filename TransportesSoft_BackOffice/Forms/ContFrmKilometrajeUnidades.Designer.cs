namespace TransportesSoft_BackOffice.Forms
{
    partial class ContFrmKilometrajeUnidades
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
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DTFecha = new System.Windows.Forms.DateTimePicker();
            this.txtKilometraje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBUnidades = new System.Windows.Forms.ComboBox();
            this.LblKilometrajeActual = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(88, 154);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(145, 23);
            this.BtnGuardar.TabIndex = 23;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DTFecha);
            this.groupBox1.Controls.Add(this.txtKilometraje);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CBUnidades);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 116);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Registro:";
            // 
            // DTFecha
            // 
            this.DTFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFecha.Location = new System.Drawing.Point(94, 77);
            this.DTFecha.Name = "DTFecha";
            this.DTFecha.Size = new System.Drawing.Size(130, 20);
            this.DTFecha.TabIndex = 4;
            // 
            // txtKilometraje
            // 
            this.txtKilometraje.Location = new System.Drawing.Point(94, 50);
            this.txtKilometraje.Name = "txtKilometraje";
            this.txtKilometraje.Size = new System.Drawing.Size(130, 20);
            this.txtKilometraje.TabIndex = 3;
            this.txtKilometraje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKilometraje_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kilometraje:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unidad:";
            // 
            // CBUnidades
            // 
            this.CBUnidades.FormattingEnabled = true;
            this.CBUnidades.Location = new System.Drawing.Point(94, 23);
            this.CBUnidades.Name = "CBUnidades";
            this.CBUnidades.Size = new System.Drawing.Size(203, 21);
            this.CBUnidades.TabIndex = 0;
            this.CBUnidades.SelectedIndexChanged += new System.EventHandler(this.CBUnidades_SelectedIndexChanged);
            // 
            // LblKilometrajeActual
            // 
            this.LblKilometrajeActual.AutoSize = true;
            this.LblKilometrajeActual.Location = new System.Drawing.Point(85, 138);
            this.LblKilometrajeActual.Name = "LblKilometrajeActual";
            this.LblKilometrajeActual.Size = new System.Drawing.Size(94, 13);
            this.LblKilometrajeActual.TabIndex = 26;
            this.LblKilometrajeActual.Text = "Kilometraje Actual:";
            // 
            // ContFrmKilometrajeUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 189);
            this.Controls.Add(this.LblKilometrajeActual);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ContFrmKilometrajeUnidades";
            this.Text = "Control de kilometraje de unidades";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContFrmPreciosDiesel_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblKilometrajeActual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBUnidades;
        private System.Windows.Forms.DateTimePicker DTFecha;
        private System.Windows.Forms.TextBox txtKilometraje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}