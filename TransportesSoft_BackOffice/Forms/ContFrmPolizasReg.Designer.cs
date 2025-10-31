namespace TransportesSoft_BackOffice.Forms
{
    partial class ContFrmPolizasReg
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
            this.txtFolioPoliza = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CBTipoPoliza = new System.Windows.Forms.ComboBox();
            this.DTFechaExp = new System.Windows.Forms.DateTimePicker();
            this.DTFechaReg = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.LblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFolioPoliza
            // 
            this.txtFolioPoliza.Location = new System.Drawing.Point(92, 13);
            this.txtFolioPoliza.Name = "txtFolioPoliza";
            this.txtFolioPoliza.Size = new System.Drawing.Size(138, 20);
            this.txtFolioPoliza.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CBTipoPoliza);
            this.groupBox1.Controls.Add(this.DTFechaExp);
            this.groupBox1.Controls.Add(this.DTFechaReg);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFolioPoliza);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 143);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha Expira:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha Registro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo de Póliza:";
            // 
            // CBTipoPoliza
            // 
            this.CBTipoPoliza.FormattingEnabled = true;
            this.CBTipoPoliza.Location = new System.Drawing.Point(92, 97);
            this.CBTipoPoliza.Name = "CBTipoPoliza";
            this.CBTipoPoliza.Size = new System.Drawing.Size(192, 21);
            this.CBTipoPoliza.TabIndex = 4;
            // 
            // DTFechaExp
            // 
            this.DTFechaExp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFechaExp.Location = new System.Drawing.Point(290, 54);
            this.DTFechaExp.Name = "DTFechaExp";
            this.DTFechaExp.Size = new System.Drawing.Size(98, 20);
            this.DTFechaExp.TabIndex = 3;
            // 
            // DTFechaReg
            // 
            this.DTFechaReg.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFechaReg.Location = new System.Drawing.Point(92, 55);
            this.DTFechaReg.Name = "DTFechaReg";
            this.DTFechaReg.Size = new System.Drawing.Size(98, 20);
            this.DTFechaReg.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folio Póliza:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(343, 176);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.BtnEliminar.FlatAppearance.BorderSize = 2;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.ForeColor = System.Drawing.Color.Red;
            this.BtnEliminar.Location = new System.Drawing.Point(12, 179);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 20;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(9, 15);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(21, 13);
            this.LblID.TabIndex = 21;
            this.LblID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtID.Location = new System.Drawing.Point(36, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(49, 20);
            this.txtID.TabIndex = 18;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // ContFrmPolizasRegcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 209);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ContFrmPolizasRegcs";
            this.Text = "Control de Pólizas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolioPoliza;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBTipoPoliza;
        private System.Windows.Forms.DateTimePicker DTFechaExp;
        private System.Windows.Forms.DateTimePicker DTFechaReg;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.TextBox txtID;
    }
}