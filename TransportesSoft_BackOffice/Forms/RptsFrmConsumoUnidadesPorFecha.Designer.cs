namespace TransportesSoft_BackOffice.Forms
{
    partial class RptsFrmConsumoUnidadesPorFecha
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
            this.DTFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.DTFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.CBUnidadSeleccionada = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CboUnidades = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DTFechaInicial
            // 
            this.DTFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFechaInicial.Location = new System.Drawing.Point(12, 49);
            this.DTFechaInicial.Name = "DTFechaInicial";
            this.DTFechaInicial.Size = new System.Drawing.Size(87, 20);
            this.DTFechaInicial.TabIndex = 0;
            // 
            // DTFechaFinal
            // 
            this.DTFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFechaFinal.Location = new System.Drawing.Point(174, 49);
            this.DTFechaFinal.Name = "DTFechaFinal";
            this.DTFechaFinal.Size = new System.Drawing.Size(87, 20);
            this.DTFechaFinal.TabIndex = 1;
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
            // CBUnidadSeleccionada
            // 
            this.CBUnidadSeleccionada.AutoSize = true;
            this.CBUnidadSeleccionada.Location = new System.Drawing.Point(22, 18);
            this.CBUnidadSeleccionada.Name = "CBUnidadSeleccionada";
            this.CBUnidadSeleccionada.Size = new System.Drawing.Size(131, 17);
            this.CBUnidadSeleccionada.TabIndex = 6;
            this.CBUnidadSeleccionada.Text = "Unidad Seleccionada:";
            this.CBUnidadSeleccionada.UseVisualStyleBackColor = true;
            this.CBUnidadSeleccionada.CheckedChanged += new System.EventHandler(this.CBTodasUnidades_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DTFechaFinal);
            this.groupBox1.Controls.Add(this.DTFechaInicial);
            this.groupBox1.Controls.Add(this.BtnImprimir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(22, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 110);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entre Fechas: ";
            // 
            // CboUnidades
            // 
            this.CboUnidades.FormattingEnabled = true;
            this.CboUnidades.Location = new System.Drawing.Point(149, 14);
            this.CboUnidades.Name = "CboUnidades";
            this.CboUnidades.Size = new System.Drawing.Size(146, 21);
            this.CboUnidades.TabIndex = 8;
            // 
            // RptsFrmConsumoUnidadesPorFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 178);
            this.Controls.Add(this.CboUnidades);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CBUnidadSeleccionada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RptsFrmConsumoUnidadesPorFecha";
            this.ShowIcon = false;
            this.Text = "Consumo de unidades por fecha";
            this.Load += new System.EventHandler(this.RptsFrmConsumoUnidadesPorFecha_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTFechaInicial;
        private System.Windows.Forms.DateTimePicker DTFechaFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.CheckBox CBUnidadSeleccionada;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CboUnidades;
    }
}