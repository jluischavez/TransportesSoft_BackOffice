namespace TransportesSoft_BackOffice
{
    partial class Main
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
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Unidades)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Unidades
            // 
            this.DGV_Unidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Unidades.Location = new System.Drawing.Point(141, 89);
            this.DGV_Unidades.Name = "DGV_Unidades";
            this.DGV_Unidades.Size = new System.Drawing.Size(657, 245);
            this.DGV_Unidades.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 446);
            this.Controls.Add(this.DGV_Unidades);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Transportes BackOffice";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Unidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Unidades;
    }
}

