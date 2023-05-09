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

namespace ParcialCarniceria.Forms
{
    public partial class FrmVenta : Form
    {
        private Cliente _cliente;
        private Compra _compra;
        private Form _frmPadre;
        private SoundPlayer _playerError;
        private SoundPlayer _playerClick;
        public FrmVenta(Cliente cliente, Form frmPadre) : this(cliente, frmPadre, new Compra())
        {
            InitializeComponent();
        }
        
        private FrmVenta(Cliente cliente, Form frmPadre, Compra compra)
        {
            this._cliente = cliente;
            this._frmPadre = frmPadre;
            this._compra = compra;
            this._playerClick = new SoundPlayer(Properties.Resources.click);
            this._playerError = new SoundPlayer(Properties.Resources.error);
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.ConfiguarForm();
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
                        str.ToLower().Contains(searchValue) )
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
            this._playerClick.Play();

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
            this._playerClick.Play();
            string producto;
            double cantidad = (double)this.nudCantidad.Value;
            bool boolProducto = GetNombreProducto(out producto);
            if (boolProducto && this._compra.AgregarProducto(producto, cantidad))
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            string producto;
            double cantidad = (double)this.nudCantidad.Value;
            bool boolProducto = GetNombreProducto(out producto);
            if (boolProducto && this._compra.ModificarProducto(producto, cantidad))
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            string producto;
            bool boolProducto = GetNombreProducto(out producto);
            if (boolProducto && this._compra.EliminarProducto(producto))
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            double total = this._compra.Total;
            bool dineroSuficiente = this._cliente - total;
            if (this._compra.Productos.Count > 0 && this._compra.Total > 0 && dineroSuficiente)
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
            this._playerClick.Play();

            this._compra.EliminarProducto();
            this.CargarMontos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            FrmDinero frmDinero = new FrmDinero(this._cliente);
            frmDinero.ShowDialog();
            this.CargarMontos();
        }

        private void ConfiguarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.ControlBox = false;
            this.ShowIcon = false;
            this.BackColor = Color.FromArgb(209, 157, 250);
        }
    }
}
