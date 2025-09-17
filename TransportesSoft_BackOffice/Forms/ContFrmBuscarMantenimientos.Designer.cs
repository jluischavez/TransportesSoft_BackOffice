namespace TransportesSoft_BackOffice.Forms
{
    partial class ContFrmBuscarMantenimientos
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
            this.txtBuscarUnidad = new System.Windows.Forms.TextBox();
            this.BtnAceptarUnidad = new System.Windows.Forms.Button();
            this.DGV_Unidades = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscarRemolque = new System.Windows.Forms.TextBox();
            this.DGVRemolques = new System.Windows.Forms.DataGridView();
            this.BtnAceptarRemolque = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Unidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRemolques)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Buscar:";
            // 
            // txtBuscarUnidad
            // 
            this.txtBuscarUnidad.Location = new System.Drawing.Point(62, 25);
            this.txtBuscarUnidad.Name = "txtBuscarUnidad";
            this.txtBuscarUnidad.Size = new System.Drawing.Size(290, 20);
            this.txtBuscarUnidad.TabIndex = 6;
            this.txtBuscarUnidad.TextChanged += new System.EventHandler(this.txtBuscarUnidad_TextChanged);
            // 
            // BtnAceptarUnidad
            // 
            this.BtnAceptarUnidad.Location = new System.Drawing.Point(277, 218);
            this.BtnAceptarUnidad.Name = "BtnAceptarUnidad";
            this.BtnAceptarUnidad.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptarUnidad.TabIndex = 8;
            this.BtnAceptarUnidad.Text = "Aceptar";
            this.BtnAceptarUnidad.UseVisualStyleBackColor = true;
            this.BtnAceptarUnidad.Click += new System.EventHandler(this.BtnAceptarUnidad_Click);
            // 
            // DGV_Unidades
            // 
            this.DGV_Unidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Unidades.Location = new System.Drawing.Point(13, 51);
            this.DGV_Unidades.Name = "DGV_Unidades";
            this.DGV_Unidades.Size = new System.Drawing.Size(339, 161);
            this.DGV_Unidades.TabIndex = 7;
            this.DGV_Unidades.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Unidades_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Buscar:";
            // 
            // txtBuscarRemolque
            // 
            this.txtBuscarRemolque.Location = new System.Drawing.Point(61, 29);
            this.txtBuscarRemolque.Name = "txtBuscarRemolque";
            this.txtBuscarRemolque.Size = new System.Drawing.Size(290, 20);
            this.txtBuscarRemolque.TabIndex = 10;
            this.txtBuscarRemolque.TextChanged += new System.EventHandler(this.txtBuscarRemolque_TextChanged);
            // 
            // DGVRemolques
            // 
            this.DGVRemolques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVRemolques.Location = new System.Drawing.Point(15, 55);
            this.DGVRemolques.Name = "DGVRemolques";
            this.DGVRemolques.Size = new System.Drawing.Size(339, 161);
            this.DGVRemolques.TabIndex = 12;
            this.DGVRemolques.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRemolques_CellDoubleClick);
            // 
            // BtnAceptarRemolque
            // 
            this.BtnAceptarRemolque.Location = new System.Drawing.Point(279, 222);
            this.BtnAceptarRemolque.Name = "BtnAceptarRemolque";
            this.BtnAceptarRemolque.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptarRemolque.TabIndex = 13;
            this.BtnAceptarRemolque.Text = "Aceptar";
            this.BtnAceptarRemolque.UseVisualStyleBackColor = true;
            this.BtnAceptarRemolque.Click += new System.EventHandler(this.BtnAceptarRemolque_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBuscarUnidad);
            this.groupBox1.Controls.Add(this.DGV_Unidades);
            this.groupBox1.Controls.Add(this.BtnAceptarUnidad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 254);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unidades";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGVRemolques);
            this.groupBox2.Controls.Add(this.txtBuscarRemolque);
            this.groupBox2.Controls.Add(this.BtnAceptarRemolque);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 259);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remolques";
            // 
            // ContFrmBuscarMantenimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 539);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ContFrmBuscarMantenimientos";
            this.Text = "Busqueda de mantenimientos";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Unidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRemolques)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarUnidad;
        private System.Windows.Forms.Button BtnAceptarUnidad;
        private System.Windows.Forms.DataGridView DGV_Unidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscarRemolque;
        private System.Windows.Forms.DataGridView DGVRemolques;
        private System.Windows.Forms.Button BtnAceptarRemolque;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}