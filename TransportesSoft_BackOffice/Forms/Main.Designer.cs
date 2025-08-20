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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contabilidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remolquesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBCDeUnidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contabilidadToolStripMenuItem,
            this.operadoresToolStripMenuItem,
            this.unidadesToolStripMenuItem,
            this.remolquesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(961, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // contabilidadToolStripMenuItem
            // 
            this.contabilidadToolStripMenuItem.Name = "contabilidadToolStripMenuItem";
            this.contabilidadToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.contabilidadToolStripMenuItem.Text = "Clientes";
            // 
            // operadoresToolStripMenuItem
            // 
            this.operadoresToolStripMenuItem.Name = "operadoresToolStripMenuItem";
            this.operadoresToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.operadoresToolStripMenuItem.Text = "Operadores";
            // 
            // unidadesToolStripMenuItem
            // 
            this.unidadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBCDeUnidadesToolStripMenuItem});
            this.unidadesToolStripMenuItem.Name = "unidadesToolStripMenuItem";
            this.unidadesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.unidadesToolStripMenuItem.Text = "Unidades";
            // 
            // remolquesToolStripMenuItem
            // 
            this.remolquesToolStripMenuItem.Name = "remolquesToolStripMenuItem";
            this.remolquesToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.remolquesToolStripMenuItem.Text = "Remolques";
            // 
            // aBCDeUnidadesToolStripMenuItem
            // 
            this.aBCDeUnidadesToolStripMenuItem.Name = "aBCDeUnidadesToolStripMenuItem";
            this.aBCDeUnidadesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aBCDeUnidadesToolStripMenuItem.Text = "ABC de Unidades";
            this.aBCDeUnidadesToolStripMenuItem.Click += new System.EventHandler(this.aBCDeUnidadesToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 446);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Transportes BackOffice";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contabilidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remolquesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBCDeUnidadesToolStripMenuItem;
    }
}

