using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcial.Vista
{
    public partial class FrmMostrar<T> : FrmBase where T : class
    {
        private List<T> _lista;
        private string _nombreLista;
        public FrmMostrar(List<T> lista, string nombreLista) : base()
        {
            InitializeComponent();
            this._lista = lista;
            this._nombreLista = nombreLista;
        }

        private void FrmMostrar_Load(object sender, EventArgs e)
        {
            this.lblLista.Text += this._nombreLista;
            ConfigurarDataGrid();

            this.dtgvDatos.DataSource = _lista;
            this.ConfigurarColumnas();
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

        private void ConfigurarColumnas()
        {
            if (typeof(T) == typeof(Corte))
            {
                this.dtgvDatos.Columns["Disponible"].Visible = false;
                this.dtgvDatos.Columns["StockKilos"].HeaderText = "Stock";
                this.dtgvDatos.Columns["PrecioKilo"].HeaderText = "Precio x Kilo";

            }

            if (typeof(T) == typeof(Factura))
            {
                this.dtgvDatos.Columns["Credito"].Visible = false;
                this.dtgvDatos.Columns["Productos"].Visible = false;
                this.dtgvDatos.Columns["NumeroFactura"].HeaderText = "Numero Factura";
                this.dtgvDatos.Columns["DniCliente"].HeaderText = "DNI Cliente";
                this.dtgvDatos.Columns["NombreCliente"].HeaderText = "Nombre Cliente";
                this.dtgvDatos.Columns["CreditoDebito"].HeaderText = "Credito/Debito";
                this.dtgvDatos.Columns["DetalleProductos"].HeaderText = "Detalle Productos";


            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        protected override void ConfigurarForm()
        {
            base.ConfigurarForm();
            this.ControlBox = false;
        }
    }
}
