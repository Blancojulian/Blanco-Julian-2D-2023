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
    public partial class FrmCorteModificar : FrmBaseCorte
    {
        private string _nombreInicial;
        private Predicate<string> _controlarNombre;
        public FrmCorteModificar(Corte corte, Predicate<string> controlarNombre) : base(corte, "Modificar corte de carne")
        {
            InitializeComponent();
            this._nombreInicial = corte.Nombre ?? string.Empty;
            this._controlarNombre = controlarNombre;
        }

        private void FrmCorteModificar_Load(object sender, EventArgs e)
        {

        }

        private void chbxNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbxNombre.Checked)
            {
                this.tbxNombre.Enabled = true;
            }
            else
            {
                this.tbxNombre.Text = this._nombreInicial;
                this.tbxNombre.Enabled = false;
            }
        }

        protected override void ConfirmarCorte()
        {
            bool nombreExiste = this.chbxNombre.Checked && this.tbxNombre.Text != this._nombreInicial && this._controlarNombre(this.tbxNombre.Text);

            if (this.ControlarCampos() && this._corte is not null && !nombreExiste)
            {
                this._corte.Categoria = (Categorias)this.cbxCategoria.SelectedItem;
                this._corte.StockKilos = (double)this.nudStock.Value;
                this._corte.PrecioKilo = (double)this.nudPrecio.Value;
                this._corte.Detalle = this.rtbxDetalle.Text;
                if (this.chbxNombre.Checked)
                {
                    this._corte.Nombre = this.tbxNombre.Text;
                    //Carniceria.Heladera.ModificarNombreCorte(this._nombreInicial, this._nombre);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (nombreExiste)
            {
                this.PlayError();
                MessageBox.Show("Error, el nombre ya existe");
            }
            else
            {
                this.PlayError();
                MessageBox.Show("Error, no se selecciono corte de carne");
            }
        }
        protected override void ConfigurarForm()
        {
            base.ConfigurarForm();
            if (this._corte is not null)
            {
                this.tbxNombre.Text = this._corte.Nombre;
                this.tbxNombre.Enabled = false;
                this.cbxCategoria.SelectedItem = (Categorias)this._corte.Categoria;
                this.nudPrecio.Value = (decimal)this._corte.PrecioKilo;
                this.nudStock.Value = (decimal)this._corte.StockKilos;
                this.rtbxDetalle.Text = this._corte.Detalle ?? string.Empty;

            }
            else
            {
                MessageBox.Show("Error, no se selecciono corte de carne");
                this.DialogResult = DialogResult.No;
            }
        }

        protected override bool ControlarCampos()
        {

            return (!this.chbxNombre.Checked && this.tbxNombre.Text == this._nombreInicial || (this.chbxNombre.Checked &&
                !this.tbxNombre.Text.EsCadenaVaciaOTieneEspacios() )) &&
                this.nudPrecio.Value > 0 && this.nudStock.Value >= 0 &&
                Enum.IsDefined(typeof(Categorias), this.cbxCategoria.Text) &&
                this.rtbxDetalle.Text is not null;
        }
    }
}
