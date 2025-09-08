namespace TransportesSoft_BackOffice.Forms
{
    partial class ContFrmViajes
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
            this.CBClientes = new System.Windows.Forms.ComboBox();
            this.CBOrigen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.CBDestino = new System.Windows.Forms.ComboBox();
            this.CBOperadores = new System.Windows.Forms.ComboBox();
            this.DTFechaViaje = new System.Windows.Forms.DateTimePicker();
            this.txtFolioFactura = new System.Windows.Forms.TextBox();
            this.DTFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.txtNumeroTransporte = new System.Windows.Forms.TextBox();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtManiobra = new System.Windows.Forms.TextBox();
            this.txtRetenciones = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.LblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBClientes
            // 
            this.CBClientes.FormattingEnabled = true;
            this.CBClientes.Location = new System.Drawing.Point(113, 29);
            this.CBClientes.Name = "CBClientes";
            this.CBClientes.Size = new System.Drawing.Size(151, 21);
            this.CBClientes.TabIndex = 1;
            // 
            // CBOrigen
            // 
            this.CBOrigen.FormattingEnabled = true;
            this.CBOrigen.Location = new System.Drawing.Point(113, 160);
            this.CBOrigen.Name = "CBOrigen";
            this.CBOrigen.Size = new System.Drawing.Size(151, 21);
            this.CBOrigen.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Viaje:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Factura:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Folio Factura:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Número Transporte:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Origen:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Destino:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Monto:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "IVA:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Retenciones:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 333);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Total:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 304);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Maniobra:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 361);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Operador:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 390);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Comentarios:";
            // 
            // CBDestino
            // 
            this.CBDestino.FormattingEnabled = true;
            this.CBDestino.Location = new System.Drawing.Point(113, 187);
            this.CBDestino.Name = "CBDestino";
            this.CBDestino.Size = new System.Drawing.Size(151, 21);
            this.CBDestino.TabIndex = 7;
            // 
            // CBOperadores
            // 
            this.CBOperadores.FormattingEnabled = true;
            this.CBOperadores.Location = new System.Drawing.Point(113, 352);
            this.CBOperadores.Name = "CBOperadores";
            this.CBOperadores.Size = new System.Drawing.Size(151, 21);
            this.CBOperadores.TabIndex = 13;
            // 
            // DTFechaViaje
            // 
            this.DTFechaViaje.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFechaViaje.Location = new System.Drawing.Point(113, 56);
            this.DTFechaViaje.Name = "DTFechaViaje";
            this.DTFechaViaje.Size = new System.Drawing.Size(151, 20);
            this.DTFechaViaje.TabIndex = 2;
            // 
            // txtFolioFactura
            // 
            this.txtFolioFactura.Location = new System.Drawing.Point(113, 108);
            this.txtFolioFactura.MaxLength = 25;
            this.txtFolioFactura.Name = "txtFolioFactura";
            this.txtFolioFactura.Size = new System.Drawing.Size(151, 20);
            this.txtFolioFactura.TabIndex = 4;
            // 
            // DTFechaFactura
            // 
            this.DTFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFechaFactura.Location = new System.Drawing.Point(113, 82);
            this.DTFechaFactura.Name = "DTFechaFactura";
            this.DTFechaFactura.Size = new System.Drawing.Size(151, 20);
            this.DTFechaFactura.TabIndex = 3;
            // 
            // txtNumeroTransporte
            // 
            this.txtNumeroTransporte.Location = new System.Drawing.Point(113, 134);
            this.txtNumeroTransporte.MaxLength = 6;
            this.txtNumeroTransporte.Name = "txtNumeroTransporte";
            this.txtNumeroTransporte.Size = new System.Drawing.Size(151, 20);
            this.txtNumeroTransporte.TabIndex = 5;
            this.txtNumeroTransporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTransporte_KeyPress_1);
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(113, 245);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(151, 20);
            this.txtIVA.TabIndex = 9;
            this.txtIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTransporte_KeyPress);
            this.txtIVA.Leave += new System.EventHandler(this.txtMonto_Leave);
            this.txtIVA.Validating += new System.ComponentModel.CancelEventHandler(this.txtMonto_Validating);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(113, 219);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(151, 20);
            this.txtMonto.TabIndex = 8;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTransporte_KeyPress);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            this.txtMonto.Validating += new System.ComponentModel.CancelEventHandler(this.txtMonto_Validating);
            // 
            // txtManiobra
            // 
            this.txtManiobra.Location = new System.Drawing.Point(113, 297);
            this.txtManiobra.Name = "txtManiobra";
            this.txtManiobra.Size = new System.Drawing.Size(151, 20);
            this.txtManiobra.TabIndex = 11;
            this.txtManiobra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTransporte_KeyPress);
            this.txtManiobra.Leave += new System.EventHandler(this.txtMonto_Leave);
            this.txtManiobra.Validating += new System.ComponentModel.CancelEventHandler(this.txtMonto_Validating);
            // 
            // txtRetenciones
            // 
            this.txtRetenciones.Location = new System.Drawing.Point(113, 271);
            this.txtRetenciones.Name = "txtRetenciones";
            this.txtRetenciones.Size = new System.Drawing.Size(151, 20);
            this.txtRetenciones.TabIndex = 10;
            this.txtRetenciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTransporte_KeyPress);
            this.txtRetenciones.Leave += new System.EventHandler(this.txtMonto_Leave);
            this.txtRetenciones.Validating += new System.ComponentModel.CancelEventHandler(this.txtMonto_Validating);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(113, 326);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(151, 20);
            this.txtTotal.TabIndex = 12;
            this.txtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTransporte_KeyPress);
            this.txtTotal.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtComentarios
            // 
            this.txtComentarios.Location = new System.Drawing.Point(113, 379);
            this.txtComentarios.MaxLength = 50;
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(252, 33);
            this.txtComentarios.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CBClientes);
            this.groupBox1.Controls.Add(this.txtComentarios);
            this.groupBox1.Controls.Add(this.CBOrigen);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtManiobra);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRetenciones);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIVA);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMonto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNumeroTransporte);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DTFechaFactura);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFolioFactura);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.DTFechaViaje);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.CBOperadores);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.CBDestino);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 431);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Captura de datos: ";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.BtnEliminar.FlatAppearance.BorderSize = 2;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.ForeColor = System.Drawing.Color.Red;
            this.BtnEliminar.Location = new System.Drawing.Point(21, 475);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 4;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(302, 475);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 3;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(12, 15);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(21, 13);
            this.LblID.TabIndex = 32;
            this.LblID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtID.Location = new System.Drawing.Point(39, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(49, 20);
            this.txtID.TabIndex = 1;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // ContFrmViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 510);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ContFrmViajes";
            this.ShowIcon = false;
            this.Text = "Registro de viajes";
            this.Load += new System.EventHandler(this.ContFrmViajes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContFrmViajes_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBClientes;
        private System.Windows.Forms.ComboBox CBOrigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox CBDestino;
        private System.Windows.Forms.ComboBox CBOperadores;
        private System.Windows.Forms.DateTimePicker DTFechaViaje;
        private System.Windows.Forms.TextBox txtFolioFactura;
        private System.Windows.Forms.DateTimePicker DTFechaFactura;
        private System.Windows.Forms.TextBox txtNumeroTransporte;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtManiobra;
        private System.Windows.Forms.TextBox txtRetenciones;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtComentarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.TextBox txtID;
    }
}