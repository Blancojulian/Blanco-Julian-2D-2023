using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Excepciones;
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
    public partial class FrmVendedor : FrmBase
    {
        private Vendedor _vendedor;

        public FrmVendedor(Vendedor vendedor) : base()
        {
            InitializeComponent();
            this._vendedor = vendedor;
        }

        private void FrmVendedor_Load(object sender, EventArgs e)
        {
            this.lblVendedor.Text = this._vendedor.MostrarNombreApellido();
            ConfigurarDataGrid();
            CargarTablaDeFacturas();
            this.dtgvDatos.ClearSelection();

            this._vendedor.OnVentaRealizada += NotificarVentaRealizada;

        }
        
        private void NotificarVentaRealizada(InfoVentaEventArgs e)
        {
            MessageBox.Show($"Venta realizada al cliente {e.NombreCliente} comprobante {e.NumeroFactura} Total {e.Total}");
        }

        private Factura GetFactura()
        {
            if (this.dtgvDatos.CurrentRow is null && this.dtgvDatos.SelectedRows.Count < 1)
            {
                throw new ErrorOperacionVendedorExcepcion("Debe selecionar una factura");
            }

            if (this.dtgvDatos.SelectedRows.Count > 1)
            {
                throw new ErrorOperacionVendedorExcepcion("Debe selecionar una sola factura");
            }

            return (Factura)this.dtgvDatos.CurrentRow.DataBoundItem;
        }

        private void CargarTablaDeFacturas()
        {

            this.dtgvDatos.DataSource = this._vendedor.GetFacturas(EstadoVenta.Pendiente);
            this.dtgvDatos.ClearSelection();

            this.dtgvDatos.Columns["Credito"].Visible = false;
            this.dtgvDatos.Columns["Productos"].Visible = false;
            this.dtgvDatos.Columns["NumeroFactura"].HeaderText = "Numero Factura";
            this.dtgvDatos.Columns["DniCliente"].HeaderText = "DNI Cliente";
            this.dtgvDatos.Columns["NombreCliente"].HeaderText = "Nombre Cliente";
            this.dtgvDatos.Columns["CreditoDebito"].HeaderText = "Credito/Debito";
            this.dtgvDatos.Columns["DetalleProductos"].HeaderText = "Detalle Productos";
            //this.dtgvHistorial.Columns["VentaRealizada"].HeaderText = "Estado";
            this.dtgvDatos.Columns["DetalleProductos"].DisplayIndex = 1;

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

        protected override void ConfigurarForm()
        {
            base.ConfigurarForm();
            this.ControlBox = false;

        }
        protected override void ConfigurarColorForm()
        {
            this.BackColor = Color.FromArgb(222, 122, 34);
        }
        
        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                this.PlayClick();
                Factura factura = GetFactura();
                Cliente? cliente = this._vendedor.GetCliente(factura.DniCliente);
                if (this._vendedor.RealizarVenta(cliente, factura))
                {
                    CargarTablaDeFacturas();
                }
            }
            catch (ErrorOperacionVendedorExcepcion ex)
            {
                this.PlayError();
                MessageBox.Show(ex.Message);
            }
            catch (DineroExcepcion ex)
            {
                this.PlayError();
                MessageBox.Show(ex.Message);
            }
            catch (VentaYaRealizada ex)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.PlayClick();

            this.DialogResult = DialogResult.None;
            this.Close();
        }
    }
}
