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
            this.CatalogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBCDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBCDeOperadoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aBCDeUnidadesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aBCDeRemolquesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumoDeUnidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumoDeUnidadesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viajesPorFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.próximosMantenimientosDeUnidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viajesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusConexion = new System.Windows.Forms.ToolStripStatusLabel();
            this.aBCDeMunicipiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CatalogosToolStripMenuItem,
            this.unidadesToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.registrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // CatalogosToolStripMenuItem
            // 
            this.CatalogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBCDeClientesToolStripMenuItem,
            this.aBCDeOperadoresToolStripMenuItem1,
            this.aBCDeUnidadesToolStripMenuItem1,
            this.aBCDeRemolquesToolStripMenuItem1,
            this.aBCDeMunicipiosToolStripMenuItem});
            this.CatalogosToolStripMenuItem.Name = "CatalogosToolStripMenuItem";
            this.CatalogosToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.CatalogosToolStripMenuItem.Text = "Catálogos";
            // 
            // aBCDeClientesToolStripMenuItem
            // 
            this.aBCDeClientesToolStripMenuItem.Name = "aBCDeClientesToolStripMenuItem";
            this.aBCDeClientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aBCDeClientesToolStripMenuItem.Text = "ABC de Clientes";
            this.aBCDeClientesToolStripMenuItem.Click += new System.EventHandler(this.aBCDeClientesToolStripMenuItem_Click);
            // 
            // aBCDeOperadoresToolStripMenuItem1
            // 
            this.aBCDeOperadoresToolStripMenuItem1.Name = "aBCDeOperadoresToolStripMenuItem1";
            this.aBCDeOperadoresToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.aBCDeOperadoresToolStripMenuItem1.Text = "ABC de Operadores";
            this.aBCDeOperadoresToolStripMenuItem1.Click += new System.EventHandler(this.aBCDeOperadoresToolStripMenuItem1_Click);
            // 
            // aBCDeUnidadesToolStripMenuItem1
            // 
            this.aBCDeUnidadesToolStripMenuItem1.Name = "aBCDeUnidadesToolStripMenuItem1";
            this.aBCDeUnidadesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.aBCDeUnidadesToolStripMenuItem1.Text = "ABC de Unidades";
            this.aBCDeUnidadesToolStripMenuItem1.Click += new System.EventHandler(this.aBCDeUnidadesToolStripMenuItem1_Click);
            // 
            // aBCDeRemolquesToolStripMenuItem1
            // 
            this.aBCDeRemolquesToolStripMenuItem1.Name = "aBCDeRemolquesToolStripMenuItem1";
            this.aBCDeRemolquesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.aBCDeRemolquesToolStripMenuItem1.Text = "ABC de Remolques";
            this.aBCDeRemolquesToolStripMenuItem1.Click += new System.EventHandler(this.aBCDeRemolquesToolStripMenuItem1_Click);
            // 
            // unidadesToolStripMenuItem
            // 
            this.unidadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consumoDeUnidadesToolStripMenuItem,
            this.mantenimientosToolStripMenuItem});
            this.unidadesToolStripMenuItem.Name = "unidadesToolStripMenuItem";
            this.unidadesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.unidadesToolStripMenuItem.Text = "Unidades";
            // 
            // consumoDeUnidadesToolStripMenuItem
            // 
            this.consumoDeUnidadesToolStripMenuItem.Name = "consumoDeUnidadesToolStripMenuItem";
            this.consumoDeUnidadesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.consumoDeUnidadesToolStripMenuItem.Text = "Consumo de Unidades";
            this.consumoDeUnidadesToolStripMenuItem.Click += new System.EventHandler(this.consumoDeUnidadesToolStripMenuItem_Click);
            // 
            // mantenimientosToolStripMenuItem
            // 
            this.mantenimientosToolStripMenuItem.Name = "mantenimientosToolStripMenuItem";
            this.mantenimientosToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.mantenimientosToolStripMenuItem.Text = "Mantenimientos";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consumoDeUnidadesToolStripMenuItem1,
            this.viajesPorFechaToolStripMenuItem,
            this.próximosMantenimientosDeUnidadesToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // consumoDeUnidadesToolStripMenuItem1
            // 
            this.consumoDeUnidadesToolStripMenuItem1.Name = "consumoDeUnidadesToolStripMenuItem1";
            this.consumoDeUnidadesToolStripMenuItem1.Size = new System.Drawing.Size(282, 22);
            this.consumoDeUnidadesToolStripMenuItem1.Text = "Consumo de Unidades Por Fecha";
            this.consumoDeUnidadesToolStripMenuItem1.Click += new System.EventHandler(this.consumoDeUnidadesToolStripMenuItem1_Click);
            // 
            // viajesPorFechaToolStripMenuItem
            // 
            this.viajesPorFechaToolStripMenuItem.Name = "viajesPorFechaToolStripMenuItem";
            this.viajesPorFechaToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.viajesPorFechaToolStripMenuItem.Text = "Viajes Por Fecha";
            this.viajesPorFechaToolStripMenuItem.Click += new System.EventHandler(this.viajesPorFechaToolStripMenuItem_Click);
            // 
            // próximosMantenimientosDeUnidadesToolStripMenuItem
            // 
            this.próximosMantenimientosDeUnidadesToolStripMenuItem.Name = "próximosMantenimientosDeUnidadesToolStripMenuItem";
            this.próximosMantenimientosDeUnidadesToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.próximosMantenimientosDeUnidadesToolStripMenuItem.Text = "Próximos Mantenimientos de Unidades";
            this.próximosMantenimientosDeUnidadesToolStripMenuItem.Click += new System.EventHandler(this.próximosMantenimientosDeUnidadesToolStripMenuItem_Click);
            // 
            // registrosToolStripMenuItem
            // 
            this.registrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viajesToolStripMenuItem});
            this.registrosToolStripMenuItem.Name = "registrosToolStripMenuItem";
            this.registrosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.registrosToolStripMenuItem.Text = "Registros";
            // 
            // viajesToolStripMenuItem
            // 
            this.viajesToolStripMenuItem.Name = "viajesToolStripMenuItem";
            this.viajesToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.viajesToolStripMenuItem.Text = "Viajes";
            this.viajesToolStripMenuItem.Click += new System.EventHandler(this.viajesToolStripMenuItem_Click);
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
            // aBCDeMunicipiosToolStripMenuItem
            // 
            this.aBCDeMunicipiosToolStripMenuItem.Name = "aBCDeMunicipiosToolStripMenuItem";
            this.aBCDeMunicipiosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aBCDeMunicipiosToolStripMenuItem.Text = "ABC de Municipios";
            this.aBCDeMunicipiosToolStripMenuItem.Click += new System.EventHandler(this.aBCDeMunicipiosToolStripMenuItem_Click);
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
            this.Text = "TransportesSoft BackOffice";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CatalogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consumoDeUnidadesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusConexion;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consumoDeUnidadesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aBCDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viajesPorFechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem próximosMantenimientosDeUnidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viajesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBCDeOperadoresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aBCDeUnidadesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aBCDeRemolquesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mantenimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBCDeMunicipiosToolStripMenuItem;
    }
}

