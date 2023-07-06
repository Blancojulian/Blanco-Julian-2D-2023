using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Excepciones;
using BibliotecaEntidades.MetodosDeExtension;
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
    public partial class FrmCliente : FrmBase
    {//antes era FrmVenta
        public event Action OnAbrirLogin;
        private Cliente _cliente;
        private Factura _factura;
        public FrmCliente(Cliente cliente) : this(cliente, new Factura(cliente.Dni, cliente.MostrarNombreApellido()))
        {
            InitializeComponent();
        }

        private FrmCliente(Cliente cliente, Factura factura) : base()
        {
            this._cliente = cliente;
            this._factura = factura;
        }
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.CargarMontos();
            this.ConfigurarDataGrid();
            this.CargarTablaDeProductos();
            this.lblDetalle.Text = string.Empty;
            this.lblSaludo.Text += this._cliente.MostrarNombreApellido();
            this._factura.OnActualizarUltimoNumeroFactura += ActualizarNumeroDeFactura;
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
                    str = (string)row.Cells["Nombre"].Value;
                    //va tirar error ahora se llama Nombre la columna Producto
                    if (row.Cells["Nombre"]?.Value is not null &&
                        !str.EsCadenaVaciaOTieneEspacios() &&
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

        public void ActualizarNumeroDeFactura(int numeroFactura)
        {
            //this.ActulizarLblNumeroFactura(this.lblNumeroFactura, numeroFactura);
            if (this.lblNumeroFactura.InvokeRequired)//ver si funciona
            {
                Action<int> delegado = this.ActualizarNumeroDeFactura;
                object[] parametros = new object[] { numeroFactura };
                this.lblNumeroFactura.Invoke(delegado, numeroFactura);
            }
            else
            {
                this.lblNumeroFactura.Text = $"Factura {numeroFactura.PasarANumeroFactura()}";
            }
        }

        private void ActulizarLblNumeroFactura(Label label, int numeroFactura)
        {
            if (InvokeRequired)//ver si funciona
            {
                object[] parametros = new object[] { numeroFactura };
                label.Invoke(this.ActualizarNumeroDeFactura, parametros);
            }
            else
            {
                label.Text = $"Factura {numeroFactura.PasarANumeroFactura()}";
            }
        }

        private Corte GetProducto()
        {
            if (this.dtgvDatos.CurrentRow is null && this.dtgvDatos.SelectedRows.Count < 1)
            {
                throw new ErrorOperacionCompraExcepcion("Debe selecionar un producto");
            }

            if (this.dtgvDatos.SelectedRows.Count > 1)
            {
                throw new ErrorOperacionCompraExcepcion("Debe selecionar un solo producto");
            }
            
            return (Corte)this.dtgvDatos.CurrentRow.DataBoundItem;
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            double total = this._factura.Total;

            try
            {
                //ver si se puede hacer metodos para validar y tirar la excepcion dentro de las clases 
                if (!(this._cliente - total))
                {
                    throw new DineroExcepcion("No tiene dinero suficiente para realizar la compra");
                }

                this._factura.ValidarCarrito();

                FrmDetalleCompra frmCompra = new FrmDetalleCompra(this._cliente, this._factura);
                frmCompra.ShowDialog();

                if (frmCompra.DialogResult == DialogResult.OK)
                {
                    this._factura = new Factura(this._cliente.Dni, this._cliente.MostrarNombreApellido());
                    this.CargarMontos();
                    MessageBox.Show("Se realizo la compra con exito");
                }
            }
            catch (ErrorOperacionCompraExcepcion ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
            catch (DineroExcepcion ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiarCarrito_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            this._factura.EliminarProducto();
            this.CargarMontos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            FrmDinero frmDinero = new FrmDinero(this._cliente);
            frmDinero.ShowDialog();
            this.CargarMontos();
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
                double cantidad = (double)this.nudCantidad.Value;
                Corte corte = GetProducto();
                if (this._factura.AgregarProducto(corte, cantidad))
                {
                    this.CargarMontos();
                }


            }
            catch (ErrorOperacionCompraExcepcion ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
            catch (DineroExcepcion ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                this._playerError.Play();
                MostrarVentanaDeError(ex);
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this._playerClick.Play();
                double cantidad = (double)this.nudCantidad.Value;
                Corte corte = GetProducto();
                if (this._factura.ModificarProducto(corte, cantidad))
                {
                    this.CargarMontos();
                }
            }
            catch (ErrorOperacionCompraExcepcion ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
            catch (DineroExcepcion ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                this._playerError.Play();
                MostrarVentanaDeError(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                
                //MessageBox.Show("El producto no se encuentra en el carrito");

                this._playerClick.Play();
                Corte corte = GetProducto();
                if (this._factura.EliminarProducto(corte.Id))
                {
                    this.CargarMontos();
                }
            }
            catch (ErrorOperacionCompraExcepcion ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
            catch (DineroExcepcion ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                this._playerError.Play();
                MostrarVentanaDeError(ex);
            }
        }

        /*
        protected override void ConfiguarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.ControlBox = false;
            this.ShowIcon = false;
        }
        */
        protected override void ConfigurarColorForm()
        {
            this.BackColor = Color.FromArgb(209, 157, 250);
        }
        private void tbxBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarProducto();
        }

        private void msiCerrarSesion_Click(object sender, EventArgs e)
        {
            this.OnAbrirLogin?.Invoke();
            this.Close();
        }

        private void FrmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.OnAbrirLogin?.Invoke();
        }
    }
}
