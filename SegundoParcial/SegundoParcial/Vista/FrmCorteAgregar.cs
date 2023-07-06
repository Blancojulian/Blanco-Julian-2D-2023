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
    public partial class FrmCorteAgregar : SegundoParcial.Vista.FrmBaseCorte
    {
        public FrmCorteAgregar() : base(null, "Agregar corte de carne")
        {
            InitializeComponent();
        }

        private void FrmCorteAgregar_Load(object sender, EventArgs e)
        {

        }

        protected override void ConfirmarCorte()
        {
            base.ConfirmarCorte();
        }
        protected override void ConfigurarForm()
        {
            base.ConfigurarForm();
        }

        protected override bool ControlarCampos()
        {

            return base.ControlarCampos();
        }
    }
}
