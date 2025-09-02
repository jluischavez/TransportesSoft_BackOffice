namespace TransportesSoft_BackOffice.Forms
{
    partial class RptsFrmMantenimientoUnidades
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
            this.RBProximosMantenimientos = new System.Windows.Forms.RadioButton();
            this.RBTodasLasUnidades = new System.Windows.Forms.RadioButton();
            this.CBKilometrajes = new System.Windows.Forms.ComboBox();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBProximosMantenimientos);
            this.groupBox1.Controls.Add(this.RBTodasLasUnidades);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // RBProximosMantenimientos
            // 
            this.RBProximosMantenimientos.AutoSize = true;
            this.RBProximosMantenimientos.Location = new System.Drawing.Point(184, 19);
            this.RBProximosMantenimientos.Name = "RBProximosMantenimientos";
            this.RBProximosMantenimientos.Size = new System.Drawing.Size(144, 17);
            this.RBProximosMantenimientos.TabIndex = 2;
            this.RBProximosMantenimientos.TabStop = true;
            this.RBProximosMantenimientos.Text = "Próximos Mantenimientos";
            this.RBProximosMantenimientos.UseVisualStyleBackColor = true;
            // 
            // RBTodasLasUnidades
            // 
            this.RBTodasLasUnidades.AutoSize = true;
            this.RBTodasLasUnidades.Location = new System.Drawing.Point(6, 19);
            this.RBTodasLasUnidades.Name = "RBTodasLasUnidades";
            this.RBTodasLasUnidades.Size = new System.Drawing.Size(117, 17);
            this.RBTodasLasUnidades.TabIndex = 1;
            this.RBTodasLasUnidades.TabStop = true;
            this.RBTodasLasUnidades.Text = "Todas las unidades";
            this.RBTodasLasUnidades.UseVisualStyleBackColor = true;
            this.RBTodasLasUnidades.CheckedChanged += new System.EventHandler(this.RBTodasLasUnidades_CheckedChanged);
            // 
            // CBKilometrajes
            // 
            this.CBKilometrajes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBKilometrajes.FormattingEnabled = true;
            this.CBKilometrajes.Location = new System.Drawing.Point(97, 68);
            this.CBKilometrajes.Name = "CBKilometrajes";
            this.CBKilometrajes.Size = new System.Drawing.Size(154, 21);
            this.CBKilometrajes.TabIndex = 1;
            this.CBKilometrajes.SelectedIndexChanged += new System.EventHandler(this.CBKilometrajes_SelectedIndexChanged);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Location = new System.Drawing.Point(142, 95);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(75, 23);
            this.BtnImprimir.TabIndex = 6;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // RptsFrmMantenimientoUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 132);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.CBKilometrajes);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RptsFrmMantenimientoUnidades";
            this.ShowIcon = false;
            this.Text = "Reporte de próximos mantenimientos de unidades";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBProximosMantenimientos;
        private System.Windows.Forms.RadioButton RBTodasLasUnidades;
        private System.Windows.Forms.ComboBox CBKilometrajes;
        private System.Windows.Forms.Button BtnImprimir;
    }
}