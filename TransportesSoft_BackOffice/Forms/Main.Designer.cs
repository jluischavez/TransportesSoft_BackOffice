using System.Drawing;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contabilidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBCDeUnidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumoDeUnidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remolquesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusConexion = new System.Windows.Forms.ToolStripStatusLabel();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumoDeUnidadesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contabilidadToolStripMenuItem,
            this.operadoresToolStripMenuItem,
            this.unidadesToolStripMenuItem,
            this.remolquesToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 24);
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
            this.aBCDeUnidadesToolStripMenuItem,
            this.consumoDeUnidadesToolStripMenuItem});
            this.unidadesToolStripMenuItem.Name = "unidadesToolStripMenuItem";
            this.unidadesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.unidadesToolStripMenuItem.Text = "Unidades";
            // 
            // aBCDeUnidadesToolStripMenuItem
            // 
            this.aBCDeUnidadesToolStripMenuItem.Name = "aBCDeUnidadesToolStripMenuItem";
            this.aBCDeUnidadesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.aBCDeUnidadesToolStripMenuItem.Text = "ABC de Unidades";
            this.aBCDeUnidadesToolStripMenuItem.Click += new System.EventHandler(this.aBCDeUnidadesToolStripMenuItem_Click);
            // 
            // consumoDeUnidadesToolStripMenuItem
            // 
            this.consumoDeUnidadesToolStripMenuItem.Name = "consumoDeUnidadesToolStripMenuItem";
            this.consumoDeUnidadesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.consumoDeUnidadesToolStripMenuItem.Text = "Consumo de Unidades";
            this.consumoDeUnidadesToolStripMenuItem.Click += new System.EventHandler(this.consumoDeUnidadesToolStripMenuItem_Click);
            // 
            // remolquesToolStripMenuItem
            // 
            this.remolquesToolStripMenuItem.Name = "remolquesToolStripMenuItem";
            this.remolquesToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.remolquesToolStripMenuItem.Text = "Remolques";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusConexion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 632);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(920, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusConexion
            // 
            this.toolStripStatusConexion.Name = "toolStripStatusConexion";
            this.toolStripStatusConexion.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusConexion.Text = "Conexion";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consumoDeUnidadesToolStripMenuItem1});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // consumoDeUnidadesToolStripMenuItem1
            // 
            this.consumoDeUnidadesToolStripMenuItem1.Name = "consumoDeUnidadesToolStripMenuItem1";
            this.consumoDeUnidadesToolStripMenuItem1.Size = new System.Drawing.Size(249, 22);
            this.consumoDeUnidadesToolStripMenuItem1.Text = "Consumo de Unidades Por Fecha";
            this.consumoDeUnidadesToolStripMenuItem1.Click += new System.EventHandler(this.consumoDeUnidadesToolStripMenuItem1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 654);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Transportes BackOffice";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem consumoDeUnidadesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusConexion;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consumoDeUnidadesToolStripMenuItem1;
    }
}

