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
    public partial class FrmVenta : Form
    {
        private Cliente _cliente;
        private Compra _compra;
        private Form _frmPadre;
        public FrmVenta(Cliente cliente, Form frmPadre)
        {
            InitializeComponent();
            this._cliente = cliente;
            this._frmPadre = frmPadre;
            this._compra = new Compra();
        }
        /*
        public FrmVenta(Cliente cliente) : this()
        {
            this._cliente = cliente;
        }*/

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.CargarMontos();
            this.ConfigurarDataGrid();
            this.CargarTablaDeProductos();
            this.lblDetalle.Text = string.Empty;
            this.lblSaludo.Text += this._cliente.MostrarNombreApellido();
        }

        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._frmPadre.Show();
        }
        private void CargarTablaDeProductos()
        {
            this.dtgvDatos.DataSource = this._cliente.GenerarTablaDeInfomacion();
            this.dtgvDatos.Columns["Disponible"].Visible = false;

            this.dtgvDatos.ClearSelection();
        }

        private void BuscarProducto()
        {//usar cadena.Contains(cadena)
            string searchValue = this.tbxBuscar.Text;
            searchValue = searchValue.ToLower().Trim();
            try
            {
                bool valueResult = false;
                int rowIndex;
                string str;

                foreach (DataGridViewRow row in this.dtgvDatos.Rows)
                {
                    str = (string)row.Cells["Producto"].Value;
                    //MessageBox.Show($"{string.IsNullOrEmpty(str)} - {row.Cells["Producto"].Value} - {str.ToLower()} = {searchValue.ToLower()}");
                    if (row.Cells["Producto"].Value is not null &&
                        !string.IsNullOrEmpty(str) &&
                        !string.IsNullOrWhiteSpace(str) &&
                        !string.IsNullOrEmpty(searchValue) &&
                        //row.Cells["Producto"].Value.ToString() is not null &&
                        str.ToLower().Contains(searchValue) )
                    {
                        rowIndex = row.Index;
                        this.dtgvDatos.Rows[rowIndex].Selected = true;
                        valueResult = true;
                        break;

                    }
                    

                }
                if (!valueResult)
                {
                    //MessageBox.Show("No se encontro el producto " + searchValue);
                    this.dtgvDatos.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConfigurarDataGrid()
        {
            this.dtgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDatos.MultiSelect = false;
            this.dtgvDatos.ReadOnly = true;
            this.dtgvDatos.RowHeadersVisible = false;
            this.dtgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvDatos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dtgvDatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtgvDatos.AllowUserToAddRows = false;

            this.dtgvDatos.ClearSelection();

        }
        private void CargarMontos()
        {
            this.lblMonto.Text = $"$ {this._cliente.Dinero:n}";
            this.lblDetalle.Text = this._compra.DetalleProductos;
            this.lblMontoTotal.Text = $"$ {this._compra.Total:n}";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.tbxBuscar.Text = string.Empty;
            this.dtgvDatos.ClearSelection();

        }

        private void tbxBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarProducto();
        }
        private bool GetNombreProducto(out string producto)
        {
            string nombreProducto = string.Empty;
            bool retorno = false;

            if (this.dtgvDatos.SelectedRows.Count > 0)
            {
                nombreProducto = (string)this.dtgvDatos.SelectedRows[0].Cells["Producto"].Value;
                retorno = true;
            }
            producto = nombreProducto;

            return retorno;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string producto;
            double cantidad = (double)this.nudCantidad.Value;
            bool boolProducto = GetNombreProducto(out producto);
            if (boolProducto && this._compra.AgregarProducto(producto, cantidad))
            {
                this.CargarMontos();
            }
            else if (!boolProducto)
            {
                MessageBox.Show("Debe seleccionar un producto");
            }
            else if (cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad mayor a cero");
            }
            else
            {
                MessageBox.Show("El producto ya se esta en el carrito");

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string producto;
            double cantidad = (double)this.nudCantidad.Value;
            bool boolProducto = GetNombreProducto(out producto);
            if (boolProducto && this._compra.ModificarProducto(producto, cantidad))
            {
                this.CargarMontos();
            }
            else if (!boolProducto)
            {
                MessageBox.Show("Debe seleccionar un producto");
            }
            else if (cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad mayor a cero");
            }
            else
            {
                MessageBox.Show("El producto no se encuentra en el carrito");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string producto;
            bool boolProducto = GetNombreProducto(out producto);
            if (boolProducto && this._compra.EliminarProducto(producto))
            {
                this.CargarMontos();
            }
            else if (!boolProducto)
            {
                MessageBox.Show("Debe seleccionar un producto");
            }
            else
            {
                MessageBox.Show("El producto no se encuentra en el carrito");
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (this._compra.Productos.Count > 0 && this._compra.Total > 0)
            {
                FrmDetalleCompra frmCompra = new FrmDetalleCompra(this._cliente, this._compra);
                frmCompra.ShowDialog();

                if (frmCompra.DialogResult == DialogResult.OK)
                {
                    this._compra = new Compra();
                    this.CargarMontos();
                    MessageBox.Show("Se realizo la compra con exito");

                }
            }
            else
            {
                MessageBox.Show("Debe tener productos en el carrito para realizar la compra");

            }
        }

        private void btnLimpiarCarrito_Click(object sender, EventArgs e)
        {
            this._compra.EliminarProducto();
            this.CargarMontos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            FrmDinero frmDinero = new FrmDinero(this._cliente);
            frmDinero.ShowDialog();
            this.CargarMontos();
        }
    }
}
