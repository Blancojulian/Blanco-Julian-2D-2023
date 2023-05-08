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
    public partial class FrmBaseCorte : Form
    {

        protected string? _titulo;
        protected string? _nombre;
        protected DetalleCorte? _detalleCorte;

        public FrmBaseCorte(string nombre, DetalleCorte? detalle, string titulo) : this()
        {
            //InitializeComponent();
            this._detalleCorte = detalle;
            this._titulo = titulo;
            this._nombre = nombre;
        }
        public FrmBaseCorte()
        {
            InitializeComponent();
        }
        public DetalleCorte? DetalleCorte => this._detalleCorte;
        public string? NombreCorte => this._nombre;
        private void FrmBaseCorte_Load(object sender, EventArgs e)
        {
            this.ConfigurarForm();
            //MessageBox.Show("load en frmBaseCorte");

        }

        protected virtual void ConfirmarCorte()
        {
            if (ControlarCampos())//hacer metodo que controler que nada esta null
            {
                string detalle = this.rtbxDetalle.Text ?? string.Empty;
                this._nombre = this.tbxNombre.Text;
                this._detalleCorte = new DetalleCorte(
                    (double)this.nudStock.Value,
                    (double)this.nudPrecio.Value,
                    (Categorias)this.cbxCategoria.SelectedItem
                    );
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        protected virtual void ConfigurarForm()
        {
            this.Text = this._titulo;
            this.cbxCategoria.DataSource = Enum.GetValues(typeof(Categorias));
        }

        protected bool ControlarCampos()
        {
            return true;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.ConfirmarCorte();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this._nombre = string.Empty;
            this._detalleCorte = null;
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
