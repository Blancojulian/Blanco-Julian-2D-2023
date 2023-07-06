using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcial.Vista
{
    public partial class FrmPrueba : FrmBase
    {
        public FrmPrueba() : base()
        {
            InitializeComponent();
        }

        private void FrmPrueba_Load(object sender, EventArgs e)
        {
            MessageBox.Show("FrmPrueba_Load");
        }

        protected override void ConfigurarForm()
        {
            base.ConfigurarForm();
            this.BackColor = Color.FromArgb(83, 97, 215);

        }
    }
}
