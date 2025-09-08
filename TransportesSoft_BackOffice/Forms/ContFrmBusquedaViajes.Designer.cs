namespace TransportesSoft_BackOffice.Forms
{
    partial class ContFrmBusquedaViajes
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(61, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(493, 20);
            this.txtBuscar.TabIndex = 6;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(437, 287);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(117, 23);
            this.BtnAceptar.TabIndex = 8;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 38);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(542, 243);
            this.DGV.TabIndex = 7;
            this.DGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellDoubleClick);
            // 
            // ContFrmBusquedaViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 325);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.DGV);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContFrmBusquedaViajes";
            this.ShowIcon = false;
            this.Text = "Busqueda de viajes";
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.DataGridView DGV;
    }
}