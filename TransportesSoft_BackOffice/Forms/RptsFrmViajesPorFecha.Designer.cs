namespace TransportesSoft_BackOffice.Forms
{
    partial class RptsFrmViajesPorFecha
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
            this.CboClienteSeleccionado = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DTFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.DTFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChkClienteSeleccionado = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CboClienteSeleccionado
            // 
            this.CboClienteSeleccionado.FormattingEnabled = true;
            this.CboClienteSeleccionado.Location = new System.Drawing.Point(139, 8);
            this.CboClienteSeleccionado.Name = "CboClienteSeleccionado";
            this.CboClienteSeleccionado.Size = new System.Drawing.Size(146, 21);
            this.CboClienteSeleccionado.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DTFechaFinal);
            this.groupBox1.Controls.Add(this.DTFechaInicial);
            this.groupBox1.Controls.Add(this.BtnImprimir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 110);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entre Fechas: ";
            // 
            // DTFechaFinal
            // 
            this.DTFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFechaFinal.Location = new System.Drawing.Point(174, 49);
            this.DTFechaFinal.Name = "DTFechaFinal";
            this.DTFechaFinal.Size = new System.Drawing.Size(87, 20);
            this.DTFechaFinal.TabIndex = 1;
            // 
            // DTFechaInicial
            // 
            this.DTFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFechaInicial.Location = new System.Drawing.Point(12, 49);
            this.DTFechaInicial.Name = "DTFechaInicial";
            this.DTFechaInicial.Size = new System.Drawing.Size(87, 20);
            this.DTFechaInicial.TabIndex = 0;
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Location = new System.Drawing.Point(94, 75);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(75, 23);
            this.BtnImprimir.TabIndex = 5;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Inicial:";
            // 
            // ChkClienteSeleccionado
            // 
            this.ChkClienteSeleccionado.AutoSize = true;
            this.ChkClienteSeleccionado.Location = new System.Drawing.Point(12, 12);
            this.ChkClienteSeleccionado.Name = "ChkClienteSeleccionado";
            this.ChkClienteSeleccionado.Size = new System.Drawing.Size(127, 17);
            this.ChkClienteSeleccionado.TabIndex = 9;
            this.ChkClienteSeleccionado.Text = "Cliente seleccionado:";
            this.ChkClienteSeleccionado.UseVisualStyleBackColor = true;
            this.ChkClienteSeleccionado.CheckedChanged += new System.EventHandler(this.ChkClienteSeleccionado_CheckedChanged);
            // 
            // RptsFrmViajesPorFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 163);
            this.Controls.Add(this.CboClienteSeleccionado);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChkClienteSeleccionado);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RptsFrmViajesPorFecha";
            this.ShowIcon = false;
            this.Text = "Viajes Por Fecha";
            this.Load += new System.EventHandler(this.RptsFrmViajesPorFecha_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboClienteSeleccionado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DTFechaFinal;
        private System.Windows.Forms.DateTimePicker DTFechaInicial;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkClienteSeleccionado;
    }
}