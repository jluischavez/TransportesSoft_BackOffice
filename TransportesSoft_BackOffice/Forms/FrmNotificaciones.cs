using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransportesSoft_BackOffice.Forms
{
    public partial class FrmNotificaciones : Base
    {
        public FrmNotificaciones()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.BackColor = Color.Gray;
        }

        private void FrmNotificaciones_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                this.Size = new Size(this.MdiParent.ClientSize.Width / 2 -10, this.MdiParent.ClientSize.Height / 2);
                this.Location = new Point(this.MdiParent.ClientSize.Width / 2, 0); // esquina superior derecha
            }
        }
    }
}
