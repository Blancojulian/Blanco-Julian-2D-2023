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
    public partial class FrmCorteModificar : ParcialCarniceria.Forms.FrmBaseCorte
    {
        public FrmCorteModificar(string nombre, DetalleCorte detalle) : base(nombre, detalle, "Modificar corte de carne")
        {
            InitializeComponent();
        }
        protected override void ConfirmarCorte()
        {
            if (this._detalleCorte is not null)
            {
                this._detalleCorte.Categoria = (Categorias)this.cbxCategoria.SelectedItem;
                this._detalleCorte.StockKilos = (double)this.nudStock.Value;
                this._detalleCorte.PrecioKilo = (double)this.nudPrecio.Value;
                this._detalleCorte.Detalle = this.rtbxDetalle.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
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
                this.rtbxDetalle.Text = this._detalleCorte.Detalle;

            }
            else
            {
                MessageBox.Show("Error, no se selecciono corte de carne");
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
