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
    public partial class FrmVendedor : Form
    {//hay que volver hacer el form que muestre todas las facturas y tenga un checkbox para elegir cuales pasar a texto
        private Vendedor _vendedor;
        private Form _frmPadre;
        private SoundPlayer _playerError;
        private SoundPlayer _playerClick;

        public FrmVendedor(Vendedor vendedor, Form frmPadre)
        {
            InitializeComponent();
            this._vendedor = vendedor;
            this._frmPadre = frmPadre;
            this._playerClick = new SoundPlayer(Properties.Resources.click);
            this._playerError = new SoundPlayer(Properties.Resources.error);
        }

        private void FrmVendedor_Load(object sender, EventArgs e)
        {
            ConfiguarForm();
            ConfigurarDataGrid();
            CargarTablaDeClientes();
            this.dtgvDatos.ClearSelection();
        }

        private void FrmVendedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._frmPadre.Show();
        }


        private void CargarTablaDeClientes()
        {

            this.dtgvDatos.DataSource = this._vendedor.GetClientes();
            this.dtgvDatos.Columns["Seleccionar"].DisplayIndex = this.dtgvDatos.Columns.Count - 1;
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

        private void ConfiguarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.ControlBox = false;
            this.ShowIcon = false;
            this.BackColor = Color.FromArgb(222, 122, 34);
        }

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
                {
                    FrmListadoCompras frmCompras = new FrmListadoCompras(this._vendedor, cliente);
                    frmCompras.ShowDialog();
                    this.CargarTablaDeClientes();
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
    }
}
