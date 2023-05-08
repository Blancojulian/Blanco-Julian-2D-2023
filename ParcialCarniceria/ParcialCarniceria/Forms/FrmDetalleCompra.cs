﻿using BibliotecaEntidades.Entidades;
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
    public partial class FrmDetalleCompra : Form
    {
        private Cliente _cliente;
        private Compra _compra;
        public FrmDetalleCompra(Cliente cliente, Compra compras)
        {
            InitializeComponent();
            this._cliente = cliente;
            this._compra = compras;
        }

        private void FrmDetalleCompra_Load(object sender, EventArgs e)
        {
            this.CargarDetalleProductos();
            //MessageBox.Show($"{this._compra.Credito}");
            if (this._compra.Credito)
            {
                this.rbtnCredito.Checked = true;
                //this.rbtnDebito.Checked = false;
            }
            else
            {
                //this.rbtnCredito.Checked = false;
                this.rbtnDebito.Checked = true;
            }
        }

        private void rbtnCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnCredito.Checked)
            {
                this._compra.Credito = true;
                this.CargarDetalleProductos();
            }
        }

        private void rbtnDebito_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnDebito.Checked)
            {
                this._compra.Credito = false;
                this.CargarDetalleProductos();
            }
        }

        private void CargarDetalleProductos()
        {
            
            this.lblDetalleProductos.Text = this._compra.DetalleProductos;
            this.lblImporte.Text = $"$ {this._compra.Total:0.00}";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //bool respuesta = false;
            //MessageBox.Show($"{} - {}");
            if ((this.rbtnDebito.Checked || this.rbtnCredito.Checked) &&
                this._compra.Productos.Count > 0 &&
                this._cliente.RealizarCompra(this._compra))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if((!this.rbtnDebito.Checked && !this.rbtnCredito.Checked))
            {
                MessageBox.Show("Debe seleccionar Credito o Debito");
            }
            else
            {
                MessageBox.Show("Fallo al realizar la compra");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
