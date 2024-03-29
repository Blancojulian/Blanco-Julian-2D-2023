﻿using BibliotecaEntidades.Entidades;
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

namespace ParcialCarniceria.Forms
{
    public partial class FrmDetalleCompra : Form
    {
        private Cliente _cliente;
        private Compra _compra;
        private SoundPlayer _playerError;
        private SoundPlayer _playerClick;
        public FrmDetalleCompra(Cliente cliente, Compra compras)
        {
            InitializeComponent();
            this._cliente = cliente;
            this._compra = compras;
            this._playerClick = new SoundPlayer(Properties.Resources.click);
            this._playerError = new SoundPlayer(Properties.Resources.error);
        }

        private void FrmDetalleCompra_Load(object sender, EventArgs e)
        {
            this.ConfiguarForm();
            this.CargarDetalleProductos();

            if (this._compra.Credito)
            {
                this.rbtnCredito.Checked = true;
            }
            else
            {
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
            this._playerClick.Play();

            if ((this.rbtnDebito.Checked || this.rbtnCredito.Checked) &&
                this._compra.Productos.Count > 0 &&
                this._cliente.RealizarCompra(this._compra))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if((!this.rbtnDebito.Checked && !this.rbtnCredito.Checked))
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ConfiguarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.BackColor = Color.FromArgb(209, 157, 250);
        }
    }
}
