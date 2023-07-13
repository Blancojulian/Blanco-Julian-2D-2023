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
            this.FormClosing += this.CerrarAplicacion;
        }
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.ActualizarDatosFactura(this._factura);
            this.ActualizarDinero(this._cliente.Dinero);
            this.ConfigurarDataGrid();
            this.CargarTablaDeProductos();
            this.lblSaludo.Text = this._cliente.MostrarNombreApellido();
            this._factura.OnActulizarDatosFactura += ActualizarDatosFactura;
            this._cliente.OnActualizarDinero += ActualizarDinero;
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

        private void ActualizarDatosFactura(Factura factura)
        {
            if (this.InvokeRequired)//ver si funciona
            {
                object[] parametros = new object[] { factura };
                this.Invoke(this.ActualizarDatosFactura, parametros);
            }
            else
            {
                this.lblNumeroFactura.Text = $"Factura {factura.NumeroFactura.PasarANumeroFactura()}";
                this.lblDetalle.Text = factura.DetalleProductos;
                this.lblMontoTotal.Text = $"$ {factura.Total:n}";
            }
        }
        public void ActualizarDinero(double dineroActual)
        {
            if (this.lblMonto.InvokeRequired)//ver si funciona
            {
                object[] parametros = new object[] { dineroActual };
                this.lblMonto.Invoke(this.ActualizarDatosFactura, parametros);
            }
            else
            {
                this.lblMonto.Text = $"$ {dineroActual:n}";
            }
        }
        private Corte GetProducto()
        {
            if (this.dtgvDatos.CurrentRow is null && this.dtgvDatos.SelectedRows.Count < 1)
            {
                throw new ErrorOperacionClienteExcepcion("Debe selecionar un producto");
            }

            if (this.dtgvDatos.SelectedRows.Count > 1)
            {
                throw new ErrorOperacionClienteExcepcion("Debe selecionar un solo producto");
            }
            
            return (Corte)this.dtgvDatos.CurrentRow.DataBoundItem;
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            
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
                {//ver si hay que llamar a ActualizarDatosFactura para actulizar los datos o si el evento OnActulizarDatosFactura llega a actulizarlos
                    this._factura = new Factura(this._cliente.Dni, this._cliente.MostrarNombreApellido());
                    this._factura.OnActulizarDatosFactura += ActualizarDatosFactura;
                    MessageBox.Show("Se realizo la compra con exito");
                }
            }
            catch (ErrorOperacionClienteExcepcion ex)
            {
                this.PlayError();
                MessageBox.Show(ex.Message);
            }
            catch (DineroExcepcion ex)
            {
                this.PlayError();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                this.PlayError();
                MostrarVentanaDeError(ex);
            }
        }

        private void btnLimpiarCarrito_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            this._factura.EliminarProducto();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            FrmDinero frmDinero = new FrmDinero(this._cliente);
            frmDinero.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            this.tbxBuscar.Text = string.Empty;
            this.dtgvDatos.ClearSelection();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.PlayClick();
                double cantidad = (double)this.nudCantidad.Value;
                Corte corte = GetProducto();
                this._factura.AgregarProducto(corte, cantidad);
                


            }
            catch (ErrorOperacionClienteExcepcion ex)
            {
                this.PlayError();
                MessageBox.Show(ex.Message);
            }
            catch (DineroExcepcion ex)
            {
                this.PlayError();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                this.PlayError();
                MostrarVentanaDeError(ex);
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.PlayClick();
                double cantidad = (double)this.nudCantidad.Value;
                Corte corte = GetProducto();
                this._factura.ModificarProducto(corte, cantidad);
                
            }
            catch (ErrorOperacionClienteExcepcion ex)
            {
                this.PlayError();
                MessageBox.Show(ex.Message);
            }
            catch (DineroExcepcion ex)
            {
                this.PlayError();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                this.PlayError();
                MostrarVentanaDeError(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                this.PlayClick();
                Corte corte = GetProducto();
                this._factura.EliminarProducto(corte.Id);
                
            }
            catch (ErrorOperacionClienteExcepcion ex)
            {
                this.PlayError();
                MessageBox.Show(ex.Message);
            }
            catch (DineroExcepcion ex)
            {
                this.PlayError();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                this.PlayError();
                MostrarVentanaDeError(ex);
            }
        }

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
            this.PlayClick();
            this.FormClosing -= this.CerrarAplicacion;
            this.OnAbrirLogin?.Invoke();
            this.Close();
        }

        private void CerrarAplicacion(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
