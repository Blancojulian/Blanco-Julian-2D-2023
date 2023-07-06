using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcial.Vista
{
    public partial class FrmDetalleCompra : FrmBase
    {
        private Cliente _cliente;
        private Factura _factura;

        public FrmDetalleCompra(Cliente cliente, Factura factura) : base()
        {
            InitializeComponent();
            this._cliente = cliente;
            this._factura = factura;
        }

        private void FrmDetalleCompra_Load(object sender, EventArgs e)
        {
            this.CargarDetalleProductos();

            if (this._factura.Credito)
            {
                this.rbtnCredito.Checked = true;
            }
            else
            {
                this.rbtnDebito.Checked = true;
            }
        }

        private void CargarDetalleProductos()
        {

            this.lblDetalleProductos.Text = this._factura.DetalleProductos;
            this.lblImporte.Text = $"$ {this._factura.Total:0.00}";
        }


        protected override void ConfigurarForm()
        {
            base.ConfigurarForm();
            this.ControlBox = false;
        }
        protected override void ConfigurarColorForm()
        {
            this.BackColor = Color.FromArgb(209, 157, 250);

        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                this._playerClick.Play();

                if ((this.rbtnDebito.Checked || this.rbtnCredito.Checked) &&
                    this._factura.Productos.Count > 0 &&
                    this._cliente.RealizarCompra(this._factura))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if ((!this.rbtnDebito.Checked && !this.rbtnCredito.Checked))
                {
                    this._playerError.Play();

                    MessageBox.Show("Debe seleccionar Credito o Debito");
                }
                else
                {
                    this._playerError.Play();

                    MessageBox.Show("Fallo al realizar la compra");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void rbtnCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnCredito.Checked)
            {
                this._factura.Credito = true;
                this.CargarDetalleProductos();
            }
        }

        private void rbtnDebito_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnDebito.Checked)
            {
                this._factura.Credito = false;
                this.CargarDetalleProductos();
            }
        }
    }
}
