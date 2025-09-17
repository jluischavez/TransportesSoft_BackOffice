namespace TransportesSoft_BackOffice.Forms
{
    partial class ContFrmMantenimientos
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
            this.DGVMantenimientosDet = new System.Windows.Forms.DataGridView();
            this.TxtKilometraje = new System.Windows.Forms.TextBox();
            this.TxtCostoTotal = new System.Windows.Forms.TextBox();
            this.DTFechaMantenimiento = new System.Windows.Forms.DateTimePicker();
            this.LblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblRemolque = new System.Windows.Forms.Label();
            this.Lblunidad = new System.Windows.Forms.Label();
            this.CBRemolque = new System.Windows.Forms.ComboBox();
            this.CBUnidad = new System.Windows.Forms.ComboBox();
            this.TxtProveedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RBRemolque = new System.Windows.Forms.RadioButton();
            this.RBUnidad = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMantenimientosDet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVMantenimientosDet
            // 
            this.DGVMantenimientosDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMantenimientosDet.Location = new System.Drawing.Point(9, 71);
            this.DGVMantenimientosDet.Name = "DGVMantenimientosDet";
            this.DGVMantenimientosDet.Size = new System.Drawing.Size(648, 195);
            this.DGVMantenimientosDet.TabIndex = 6;
            this.DGVMantenimientosDet.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMantenimientosDet_CellValueChanged);
            this.DGVMantenimientosDet.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGVMantenimientosDet_EditingControlShowing);
            this.DGVMantenimientosDet.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DGVMantenimientosDet_RowsAdded);
            this.DGVMantenimientosDet.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DGVMantenimientosDet_RowsRemoved);
            // 
            // TxtKilometraje
            // 
            this.TxtKilometraje.Location = new System.Drawing.Point(76, 19);
            this.TxtKilometraje.Name = "TxtKilometraje";
            this.TxtKilometraje.Size = new System.Drawing.Size(118, 20);
            this.TxtKilometraje.TabIndex = 1;
            this.TxtKilometraje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKilometraje_KeyPress);
            this.TxtKilometraje.Leave += new System.EventHandler(this.TxtKilometraje_Leave);
            // 
            // TxtCostoTotal
            // 
            this.TxtCostoTotal.Location = new System.Drawing.Point(536, 272);
            this.TxtCostoTotal.Name = "TxtCostoTotal";
            this.TxtCostoTotal.Size = new System.Drawing.Size(118, 20);
            this.TxtCostoTotal.TabIndex = 7;
            // 
            // DTFechaMantenimiento
            // 
            this.DTFechaMantenimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFechaMantenimiento.Location = new System.Drawing.Point(545, 19);
            this.DTFechaMantenimiento.Name = "DTFechaMantenimiento";
            this.DTFechaMantenimiento.Size = new System.Drawing.Size(112, 20);
            this.DTFechaMantenimiento.TabIndex = 3;
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(13, 15);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(21, 13);
            this.LblID.TabIndex = 19;
            this.LblID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtID.Location = new System.Drawing.Point(40, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(49, 20);
            this.txtID.TabIndex = 1;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Kilometraje:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Costo Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Fecha Mantenimiento:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblRemolque);
            this.groupBox1.Controls.Add(this.Lblunidad);
            this.groupBox1.Controls.Add(this.CBRemolque);
            this.groupBox1.Controls.Add(this.CBUnidad);
            this.groupBox1.Controls.Add(this.TxtProveedor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DGVMantenimientosDet);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtKilometraje);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtCostoTotal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DTFechaMantenimiento);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 298);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // LblRemolque
            // 
            this.LblRemolque.AutoSize = true;
            this.LblRemolque.Location = new System.Drawing.Point(217, 52);
            this.LblRemolque.Name = "LblRemolque";
            this.LblRemolque.Size = new System.Drawing.Size(58, 13);
            this.LblRemolque.TabIndex = 28;
            this.LblRemolque.Text = "Remolque:";
            // 
            // Lblunidad
            // 
            this.Lblunidad.AutoSize = true;
            this.Lblunidad.Location = new System.Drawing.Point(9, 52);
            this.Lblunidad.Name = "Lblunidad";
            this.Lblunidad.Size = new System.Drawing.Size(44, 13);
            this.Lblunidad.TabIndex = 27;
            this.Lblunidad.Text = "Unidad:";
            // 
            // CBRemolque
            // 
            this.CBRemolque.FormattingEnabled = true;
            this.CBRemolque.Location = new System.Drawing.Point(284, 44);
            this.CBRemolque.Name = "CBRemolque";
            this.CBRemolque.Size = new System.Drawing.Size(118, 21);
            this.CBRemolque.TabIndex = 5;
            // 
            // CBUnidad
            // 
            this.CBUnidad.FormattingEnabled = true;
            this.CBUnidad.Location = new System.Drawing.Point(76, 44);
            this.CBUnidad.Name = "CBUnidad";
            this.CBUnidad.Size = new System.Drawing.Size(118, 21);
            this.CBUnidad.TabIndex = 4;
            // 
            // TxtProveedor
            // 
            this.TxtProveedor.Location = new System.Drawing.Point(284, 18);
            this.TxtProveedor.Name = "TxtProveedor";
            this.TxtProveedor.Size = new System.Drawing.Size(118, 20);
            this.TxtProveedor.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Proveedor:";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.BtnEliminar.FlatAppearance.BorderSize = 2;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.ForeColor = System.Drawing.Color.Red;
            this.BtnEliminar.Location = new System.Drawing.Point(21, 342);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 5;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(591, 342);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 4;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RBRemolque);
            this.groupBox2.Controls.Add(this.RBUnidad);
            this.groupBox2.Location = new System.Drawing.Point(232, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 33);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // RBRemolque
            // 
            this.RBRemolque.AutoSize = true;
            this.RBRemolque.Location = new System.Drawing.Point(104, 10);
            this.RBRemolque.Name = "RBRemolque";
            this.RBRemolque.Size = new System.Drawing.Size(73, 17);
            this.RBRemolque.TabIndex = 2;
            this.RBRemolque.TabStop = true;
            this.RBRemolque.Text = "Remolque";
            this.RBRemolque.UseVisualStyleBackColor = true;
            // 
            // RBUnidad
            // 
            this.RBUnidad.AutoSize = true;
            this.RBUnidad.Location = new System.Drawing.Point(6, 10);
            this.RBUnidad.Name = "RBUnidad";
            this.RBUnidad.Size = new System.Drawing.Size(59, 17);
            this.RBUnidad.TabIndex = 1;
            this.RBUnidad.TabStop = true;
            this.RBUnidad.Text = "Unidad";
            this.RBUnidad.UseVisualStyleBackColor = true;
            this.RBUnidad.CheckedChanged += new System.EventHandler(this.RBUnidad_CheckedChanged);
            // 
            // ContFrmMantenimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 377);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.txtID);
            this.Name = "ContFrmMantenimientos";
            this.Text = "Control de Mantenimientos a Unidades";
            this.Load += new System.EventHandler(this.ContFrmMantenimientos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContFrmMantenimientos_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGVMantenimientosDet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVMantenimientosDet;
        private System.Windows.Forms.TextBox TxtKilometraje;
        private System.Windows.Forms.TextBox TxtCostoTotal;
        private System.Windows.Forms.DateTimePicker DTFechaMantenimiento;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox TxtProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblRemolque;
        private System.Windows.Forms.Label Lblunidad;
        private System.Windows.Forms.ComboBox CBRemolque;
        private System.Windows.Forms.ComboBox CBUnidad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBRemolque;
        private System.Windows.Forms.RadioButton RBUnidad;
    }
}