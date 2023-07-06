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
    {//hay que volver hacer el form que muestre todas las facturas y tenga un checkbox para elegir cuales pasar a texto
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
        
        private void NotificarVentaRealizada(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private Factura GetFactura()
        {
            if (this.dtgvDatos.CurrentRow is null && this.dtgvDatos.SelectedRows.Count < 1)
            {
                throw new ErrorOperacionVentaExcepcion("Debe selecionar una factura");
            }

            if (this.dtgvDatos.SelectedRows.Count > 1)
            {
                throw new ErrorOperacionVentaExcepcion("Debe selecionar una sola factura");
            }

            return (Factura)this.dtgvDatos.CurrentRow.DataBoundItem;
        }

        private void CargarTablaDeFacturas()
        {

            this.dtgvDatos.DataSource = this._vendedor.GetFacturas(EstadoVenta.Pendiente);
            this.dtgvDatos.ClearSelection();


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
        //eliminar no se va usar
        private void dtgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        e.RowIndex >= 0)
            {
                this._playerClick.Play();

                string mail = senderGrid.Rows[e.RowIndex].Cells["Mail"].Value.ToString() ?? "nulo";
                Cliente? cliente = this._vendedor.GetUsuario(mail);

                if (cliente is not null)
                {/*cambiar
                    FrmListadoCompras frmCompras = new FrmListadoCompras(this._vendedor, cliente);
                    frmCompras.ShowDialog();
                    this.CargarTablaDeClientes();*/
                }

            }
        }

        //ver bien este metodo se saco del form FrmListadoCompras
        private void CargarTablaDeCompras()
        {
            this.dtgvDatos.DataSource = this._vendedor.GetFacturas(EstadoVenta.Todas);
            this.dtgvDatos.Columns["Vendido"].Visible = false;
            this.dtgvDatos.Columns["Credito"].Visible = false;
            this.dtgvDatos.Columns["Productos"].Visible = false;
            this.dtgvDatos.Columns["NombreCliente"].Visible = false;
            this.dtgvDatos.Columns["CreditoDebito"].HeaderText = "Credito/Debito";
            this.dtgvDatos.Columns["DetalleProductos"].HeaderText = "Detalle productos";
            this.dtgvDatos.Columns["VentaRealizada"].HeaderText = "Estado";
            this.dtgvDatos.Columns["DetalleProductos"].DisplayIndex = 0;

            this.dtgvDatos.ClearSelection();

        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                this._playerClick.Play();
                Factura factura = GetFactura();
                Cliente? cliente = this._vendedor.GetCliente(factura.DniCliente);
                if (this._vendedor.RealizarVenta(cliente, factura))
                {
                    CargarTablaDeFacturas();
                }
            }
            catch (ErrorOperacionVentaExcepcion ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
            catch (DineroExcepcion ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
            catch (VentaYaRealizada ex)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            this.DialogResult = DialogResult.None;
            this.Close();
        }
    }
}
