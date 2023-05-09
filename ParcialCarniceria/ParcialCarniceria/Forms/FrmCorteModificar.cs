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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ParcialCarniceria.Forms
{
    public partial class FrmCorteModificar : ParcialCarniceria.Forms.FrmBaseCorte
    {
        private string _nombreInicial;
        public FrmCorteModificar(string nombre, DetalleCorte detalle) : base(nombre, detalle, "Modificar corte de carne")
        {
            InitializeComponent();
            this._nombreInicial = nombre;
        }
        protected override void ConfirmarCorte()
        {
            DetalleCorte? detalle = Carniceria.Heladera.GetDetalleCorte(this.tbxNombre.Text);
            bool nombreExiste = detalle is not null && this.chbxNombre.Checked && this.tbxNombre.Text != this._nombreInicial;

            if (this.ControlarCampos() && this._detalleCorte is not null && !nombreExiste)
            {
                this._detalleCorte.Categoria = (Categorias)this.cbxCategoria.SelectedItem;
                this._detalleCorte.StockKilos = (double)this.nudStock.Value;
                this._detalleCorte.PrecioKilo = (double)this.nudPrecio.Value;
                this._detalleCorte.Detalle = this.rtbxDetalle.Text;
                if (this.chbxNombre.Checked)
                {
                    this._nombre = this.tbxNombre.Text;
                    Carniceria.Heladera.ModificarNombreCorte(this._nombreInicial, this._nombre);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (nombreExiste)
            {
                this._playerError.Play();

                MessageBox.Show("Error, el nombre ya existe");
            }
            else
            {
                this._playerError.Play();

                MessageBox.Show("Error, no se selecciono corte de carne");
            }
        }
        protected override void ConfigurarForm()
        {
            base.ConfigurarForm();
            if (this._detalleCorte is not null)
            {
                this.tbxNombre.Text = this._nombre;
                this.tbxNombre.Enabled = false;
                this.cbxCategoria.SelectedItem = (Categorias)this._detalleCorte.Categoria;
                this.nudPrecio.Value = (decimal)this._detalleCorte.PrecioKilo;
                this.nudStock.Value = (decimal)this._detalleCorte.StockKilos;
                this.rtbxDetalle.Text = this._detalleCorte.Detalle ?? string.Empty;

            }
            else
            {
                MessageBox.Show("Error, no se selecciono corte de carne");
                this.DialogResult = DialogResult.No;
            }
        }

        protected override bool ControlarCampos()
        {

            return ( !this.chbxNombre.Checked && this.tbxNombre.Text == this._nombreInicial || (this.chbxNombre.Checked &&
                !string.IsNullOrEmpty(this.tbxNombre.Text) &&
                !string.IsNullOrWhiteSpace(this.tbxNombre.Text) ) ) &&
                this.nudPrecio.Value > 0 && this.nudStock.Value >= 0 &&
                Enum.IsDefined(typeof(Categorias), this.cbxCategoria.Text) &&
                this.rtbxDetalle.Text is not null;
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
    }
}
