using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.MetodosDeExtension;
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
    public partial class FrmBaseCorte : FrmBase
    {
        protected string? _titulo;
        protected Corte? _corte;

        public FrmBaseCorte(Corte? corte, string titulo) : this()
        {
            this._corte = corte;
            this._titulo = titulo;
        }
        public FrmBaseCorte() : base()
        {
            InitializeComponent();
        }
        public Corte? Corte => this._corte;
        private void FrmBaseCorte_Load(object sender, EventArgs e)
        {
            this.ConfigurarForm();

        }


        protected virtual void ConfirmarCorte()
        {

            if (ControlarCampos())
            {
                string detalle = this.rtbxDetalle.Text ?? string.Empty;
                this._corte = new Corte(
                    this.tbxNombre.Text,
                    (double)this.nudStock.Value,
                    (double)this.nudPrecio.Value,
                    (Categorias)this.cbxCategoria.SelectedItem,
                    detalle
                    );
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.PlayError();
                MessageBox.Show("Debe completar los campos");
            }
        }

        protected override void ConfigurarForm()
        {
            base.ConfigurarForm();
            this.ControlBox = false;
            this.Text = this._titulo;
            this.cbxCategoria.DataSource = Enum.GetValues(typeof(Categorias));
        }

        protected virtual bool ControlarCampos()
        {
            return this.nudPrecio.Value > 0 && this.nudStock.Value >= 0 &&
                Enum.IsDefined(typeof(Categorias), this.cbxCategoria.Text) &&
                !this.tbxNombre.Text.EsCadenaVaciaOTieneEspacios() &&
                this.rtbxDetalle.Text is not null;
        }

        protected override void ConfigurarColorForm()
        {
            this.BackColor = Color.FromArgb(222, 122, 34);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            this.ConfirmarCorte();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            this._corte = null;
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
