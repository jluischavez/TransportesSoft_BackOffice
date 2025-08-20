namespace TransportesSoft_BackOffice.Forms
{
    partial class ContFrmBuscar
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
            this.DGV_Unidades = new System.Windows.Forms.DataGridView();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BntReporte = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Unidades)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Unidades
            // 
            this.DGV_Unidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Unidades.Location = new System.Drawing.Point(12, 38);
            this.DGV_Unidades.Name = "DGV_Unidades";
            this.DGV_Unidades.Size = new System.Drawing.Size(339, 325);
            this.DGV_Unidades.TabIndex = 1;
            this.DGV_Unidades.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Unidades_CellDoubleClick);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(276, 369);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 2;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            // 
            // BntReporte
            // 
            this.BntReporte.Location = new System.Drawing.Point(12, 369);
            this.BntReporte.Name = "BntReporte";
            this.BntReporte.Size = new System.Drawing.Size(75, 23);
            this.BntReporte.TabIndex = 3;
            this.BntReporte.Text = "Imprimir";
            this.BntReporte.UseVisualStyleBackColor = true;
            this.BntReporte.Click += new System.EventHandler(this.BntReporte_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(61, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(290, 20);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Buscar:";
            // 
            // ContFrmBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 404);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.BntReporte);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.DGV_Unidades);
            this.Name = "ContFrmBuscar";
            this.ShowIcon = false;
            this.Text = "Buscar";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Unidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Unidades;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BntReporte;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
    }
}