namespace TransportesSoft_BackOffice.Forms
{
    partial class ContFrmConsumosUnidades
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
            this.GB1 = new System.Windows.Forms.GroupBox();
            this.DTFecha = new System.Windows.Forms.DateTimePicker();
            this.CBUnidades = new System.Windows.Forms.ComboBox();
            this.LblUnidad = new System.Windows.Forms.Label();
            this.LblFecha = new System.Windows.Forms.Label();
            this.LblConsumoLitros = new System.Windows.Forms.Label();
            this.LblComentarios = new System.Windows.Forms.Label();
            this.txtConsumoEnPesos = new System.Windows.Forms.TextBox();
            this.LblConsumoPesos = new System.Windows.Forms.Label();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.txtConsumoLitros = new System.Windows.Forms.TextBox();
            this.BTGuardar = new System.Windows.Forms.Button();
            this.LblPrecioActual = new System.Windows.Forms.Label();
            this.GB1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB1
            // 
            this.GB1.Controls.Add(this.DTFecha);
            this.GB1.Controls.Add(this.CBUnidades);
            this.GB1.Controls.Add(this.LblUnidad);
            this.GB1.Controls.Add(this.LblFecha);
            this.GB1.Controls.Add(this.LblConsumoLitros);
            this.GB1.Controls.Add(this.LblComentarios);
            this.GB1.Controls.Add(this.txtConsumoEnPesos);
            this.GB1.Controls.Add(this.LblConsumoPesos);
            this.GB1.Controls.Add(this.txtComentarios);
            this.GB1.Controls.Add(this.txtConsumoLitros);
            this.GB1.Location = new System.Drawing.Point(12, 12);
            this.GB1.Name = "GB1";
            this.GB1.Size = new System.Drawing.Size(357, 211);
            this.GB1.TabIndex = 16;
            this.GB1.TabStop = false;
            this.GB1.Text = "Registro";
            // 
            // DTFecha
            // 
            this.DTFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFecha.Location = new System.Drawing.Point(140, 61);
            this.DTFecha.Name = "DTFecha";
            this.DTFecha.Size = new System.Drawing.Size(195, 20);
            this.DTFecha.TabIndex = 2;
            // 
            // CBUnidades
            // 
            this.CBUnidades.FormattingEnabled = true;
            this.CBUnidades.Location = new System.Drawing.Point(140, 34);
            this.CBUnidades.Name = "CBUnidades";
            this.CBUnidades.Size = new System.Drawing.Size(195, 21);
            this.CBUnidades.TabIndex = 1;
            // 
            // LblUnidad
            // 
            this.LblUnidad.AutoSize = true;
            this.LblUnidad.Location = new System.Drawing.Point(15, 37);
            this.LblUnidad.Name = "LblUnidad";
            this.LblUnidad.Size = new System.Drawing.Size(44, 13);
            this.LblUnidad.TabIndex = 0;
            this.LblUnidad.Text = "Unidad:";
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.Location = new System.Drawing.Point(15, 63);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(40, 13);
            this.LblFecha.TabIndex = 1;
            this.LblFecha.Text = "Fecha:";
            // 
            // LblConsumoLitros
            // 
            this.LblConsumoLitros.AutoSize = true;
            this.LblConsumoLitros.Location = new System.Drawing.Point(15, 89);
            this.LblConsumoLitros.Name = "LblConsumoLitros";
            this.LblConsumoLitros.Size = new System.Drawing.Size(97, 13);
            this.LblConsumoLitros.TabIndex = 2;
            this.LblConsumoLitros.Text = "Consumo en Litros:";
            // 
            // LblComentarios
            // 
            this.LblComentarios.AutoSize = true;
            this.LblComentarios.Location = new System.Drawing.Point(15, 145);
            this.LblComentarios.Name = "LblComentarios";
            this.LblComentarios.Size = new System.Drawing.Size(68, 13);
            this.LblComentarios.TabIndex = 4;
            this.LblComentarios.Text = "Comentarios:";
            // 
            // txtConsumoEnPesos
            // 
            this.txtConsumoEnPesos.Enabled = false;
            this.txtConsumoEnPesos.Location = new System.Drawing.Point(140, 112);
            this.txtConsumoEnPesos.MaxLength = 5;
            this.txtConsumoEnPesos.Name = "txtConsumoEnPesos";
            this.txtConsumoEnPesos.Size = new System.Drawing.Size(195, 20);
            this.txtConsumoEnPesos.TabIndex = 4;
            this.txtConsumoEnPesos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumoEnPesos_KeyPress);
            // 
            // LblConsumoPesos
            // 
            this.LblConsumoPesos.AutoSize = true;
            this.LblConsumoPesos.Location = new System.Drawing.Point(15, 115);
            this.LblConsumoPesos.Name = "LblConsumoPesos";
            this.LblConsumoPesos.Size = new System.Drawing.Size(101, 13);
            this.LblConsumoPesos.TabIndex = 5;
            this.LblConsumoPesos.Text = "Consumo en Pesos:";
            // 
            // txtComentarios
            // 
            this.txtComentarios.Location = new System.Drawing.Point(140, 142);
            this.txtComentarios.MaxLength = 50;
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(195, 63);
            this.txtComentarios.TabIndex = 5;
            // 
            // txtConsumoLitros
            // 
            this.txtConsumoLitros.Location = new System.Drawing.Point(140, 86);
            this.txtConsumoLitros.MaxLength = 3;
            this.txtConsumoLitros.Name = "txtConsumoLitros";
            this.txtConsumoLitros.Size = new System.Drawing.Size(195, 20);
            this.txtConsumoLitros.TabIndex = 3;
            this.txtConsumoLitros.TextChanged += new System.EventHandler(this.txtConsumoLitros_TextChanged);
            this.txtConsumoLitros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumoLitros_KeyPress);
            this.txtConsumoLitros.Leave += new System.EventHandler(this.txtConsumoLitros_Leave);
            // 
            // BTGuardar
            // 
            this.BTGuardar.Location = new System.Drawing.Point(272, 229);
            this.BTGuardar.Name = "BTGuardar";
            this.BTGuardar.Size = new System.Drawing.Size(75, 23);
            this.BTGuardar.TabIndex = 6;
            this.BTGuardar.Text = "Guardar";
            this.BTGuardar.UseVisualStyleBackColor = true;
            this.BTGuardar.Click += new System.EventHandler(this.BTGuardar_Click);
            // 
            // LblPrecioActual
            // 
            this.LblPrecioActual.AutoSize = true;
            this.LblPrecioActual.Location = new System.Drawing.Point(27, 234);
            this.LblPrecioActual.Name = "LblPrecioActual";
            this.LblPrecioActual.Size = new System.Drawing.Size(73, 13);
            this.LblPrecioActual.TabIndex = 27;
            this.LblPrecioActual.Text = "Precio Actual:";
            // 
            // ContFrmConsumosUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 260);
            this.Controls.Add(this.LblPrecioActual);
            this.Controls.Add(this.BTGuardar);
            this.Controls.Add(this.GB1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContFrmConsumosUnidades";
            this.ShowIcon = false;
            this.Text = "Control de consumo de diesel por unidad";
            this.Load += new System.EventHandler(this.ContFrmConsumosUnidades_Load);
            this.Shown += new System.EventHandler(this.ContFrmConsumosUnidades_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContFrmConsumosUnidades_KeyDown);
            this.GB1.ResumeLayout(false);
            this.GB1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GB1;
        private System.Windows.Forms.Label LblUnidad;
        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.Label LblConsumoLitros;
        private System.Windows.Forms.Label LblComentarios;
        private System.Windows.Forms.TextBox txtConsumoEnPesos;
        private System.Windows.Forms.Label LblConsumoPesos;
        private System.Windows.Forms.TextBox txtComentarios;
        private System.Windows.Forms.TextBox txtConsumoLitros;
        private System.Windows.Forms.ComboBox CBUnidades;
        private System.Windows.Forms.DateTimePicker DTFecha;
        private System.Windows.Forms.Button BTGuardar;
        private System.Windows.Forms.Label LblPrecioActual;
    }
}