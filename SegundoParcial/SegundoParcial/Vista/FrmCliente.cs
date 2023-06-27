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
    public partial class FrmCliente : Form
    {//antes era FrmVenta

        private Cliente _cliente;
        private Factura _factura;
        private Form _frmPadre;
        private SoundPlayer _playerError;
        private SoundPlayer _playerClick;
        public FrmCliente(Cliente cliente, Form frmPadre) : this(cliente, frmPadre, new Factura(cliente.Dni, cliente.MostrarNombreApellido()))
        {
            InitializeComponent();
        }

        private FrmCliente(Cliente cliente, Form frmPadre, Factura factura)
        {
            this._cliente = cliente;
            this._frmPadre = frmPadre;
            this._factura = factura;
            this._playerClick = new SoundPlayer(Properties.Resources.click);
            this._playerError = new SoundPlayer(Properties.Resources.error);
        }
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.ConfiguarForm();
            this.CargarMontos();
            this.ConfigurarDataGrid();
            this.CargarTablaDeProductos();
            this.lblDetalle.Text = string.Empty;
            this.lblSaludo.Text += this._cliente.MostrarNombreApellido();
        }

        private void CargarTablaDeProductos()
        {
            this.dtgvDatos.DataSource = this._cliente.GetProductos();
            this.dtgvDatos.Columns["Disponible"].Visible = false;

            this.dtgvDatos.ClearSelection();
        }

        private void BuscarProducto()
        {
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

                    if (row.Cells["Producto"].Value is not null &&
                        !string.IsNullOrEmpty(str) &&
                        !string.IsNullOrWhiteSpace(str) &&
                        !string.IsNullOrEmpty(searchValue) &&
                        str.ToLower().Contains(searchValue))
                    {
                        rowIndex = row.Index;
                        this.dtgvDatos.Rows[rowIndex].Selected = true;
                        this.dtgvDatos.FirstDisplayedScrollingRowIndex = rowIndex;
                        valueResult = true;
                        break;

                    }


                }
                if (!valueResult)
                {
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
            this.lblDetalle.Text = this._factura.DetalleProductos;
            this.lblMontoTotal.Text = $"$ {this._factura.Total:n}";
        }


        private bool GetIdProducto(out int producto)
        {
            int idProducto = 0;
            bool retorno = false;

            if (this.dtgvDatos.SelectedRows.Count > 0)
            {
                idProducto = int.Parse((string)this.dtgvDatos.SelectedRows[0].Cells["Id"].Value);
                retorno = true;
            }
            producto = idProducto;

            return retorno;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            double total = this._factura.Total;
            bool dineroSuficiente = this._cliente - total;
            if (this._factura.Productos.Count > 0 && this._factura.Total > 0 && dineroSuficiente)
            {
                FrmDetalleCompra frmCompra = new FrmDetalleCompra(this._cliente, this._factura);
                frmCompra.ShowDialog();

                if (frmCompra.DialogResult == DialogResult.OK)
                {
                    this._factura = new Factura(this._cliente.Dni, this._cliente.MostrarNombreApellido());
                    this.CargarMontos();
                    MessageBox.Show("Se realizo la compra con exito");
                }

            }
            else if (!dineroSuficiente)
            {
                this._playerError.Play();
                MessageBox.Show("No tiene dinero suficiente para realizar la compra");

            }
            else
            {
                this._playerError.Play();
                MessageBox.Show("Debe tener productos en el carrito para realizar la compra");

            }
        }

        private void btnLimpiarCarrito_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            this.tbxBuscar.Text = string.Empty;
            this.dtgvDatos.ClearSelection();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this._playerClick.Play();
                int idProducto;
                double cantidad = (double)this.nudCantidad.Value;
                bool boolProducto = GetIdProducto(out idProducto);
                if (boolProducto && this._factura.AgregarProducto(idProducto, cantidad))
                {
                    this.CargarMontos();
                }
                else if (!boolProducto)
                {
                    this._playerError.Play();
                    MessageBox.Show("Debe seleccionar un producto");
                }
                else if (cantidad <= 0)
                {
                    this._playerError.Play();
                    MessageBox.Show("Debe ingresar una cantidad mayor a cero");
                }
                else
                {
                    this._playerError.Play();
                    MessageBox.Show("El producto ya se esta en el carrito");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this._playerClick.Play();

                int idProducto;
                double cantidad = (double)this.nudCantidad.Value;
                bool boolProducto = GetIdProducto(out idProducto);
                if (boolProducto && this._factura.ModificarProducto(idProducto, cantidad))
                {
                    this.CargarMontos();

                }
                else if (!boolProducto)
                {
                    this._playerError.Play();
                    MessageBox.Show("Debe seleccionar un producto");
                }
                else if (cantidad <= 0)
                {
                    this._playerError.Play();
                    MessageBox.Show("Debe ingresar una cantidad mayor a cero");
                }
                else
                {
                    this._playerError.Play();
                    MessageBox.Show("El producto no se encuentra en el carrito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                this._playerClick.Play();
                int idProducto;
                bool boolProducto = GetIdProducto(out idProducto);
                if (boolProducto && this._factura.EliminarProducto(idProducto))
                {
                    this.CargarMontos();
                }
                else if (!boolProducto)
                {
                    this._playerError.Play();
                    MessageBox.Show("Debe seleccionar un producto");
                }
                else
                {
                    this._playerError.Play();
                    MessageBox.Show("El producto no se encuentra en el carrito");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ConfiguarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.ControlBox = false;
            this.ShowIcon = false;
            this.BackColor = Color.FromArgb(209, 157, 250);
        }

        private void tbxBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarProducto();
        }

        private void FrmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._frmPadre.Show();
        }
    }
}
