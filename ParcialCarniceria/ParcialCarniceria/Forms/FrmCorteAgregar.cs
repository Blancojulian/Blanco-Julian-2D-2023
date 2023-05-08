using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialCarniceria.Forms
{
    public partial class FrmCorteAgregar : ParcialCarniceria.Forms.FrmBaseCorte
    {
        public FrmCorteAgregar() : base(string.Empty, null, "Agregar corte de carne")
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
    }
}
