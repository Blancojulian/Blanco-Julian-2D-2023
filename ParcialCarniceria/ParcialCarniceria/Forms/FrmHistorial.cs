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

namespace ParcialCarniceria.Forms
{
    public partial class FrmHistorial : Form
    {
        private Vendedor _vendedor;
        private Form _frmPadre;
        public FrmHistorial(Vendedor vendedor, Form frmPadre)
        {
            InitializeComponent();
            this._vendedor = vendedor;
            this._frmPadre = frmPadre;
        }

        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            this.lblNombre.Text = this._vendedor.MostrarNombreApellido();
            this.ConfigurarDataGrid();
            this.CargarHistorial();
        }

        private void FrmHistorial_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._frmPadre.Show();
        }

        private void CargarHistorial()
        {
            this.dtgvHistorial.DataSource = Carniceria.GetCompras();
            this.dtgvHistorial.Columns["Vendido"].Visible = false;
            this.dtgvHistorial.Columns["Credito"].Visible = false;
            this.dtgvHistorial.Columns["Productos"].Visible = false;
            this.dtgvHistorial.Columns["CreditoDebito"].HeaderText = "Credito/Debito";
            this.dtgvHistorial.Columns["DetalleProductos"].HeaderText = "Detalle productos";
            this.dtgvHistorial.Columns["VentaRealizada"].HeaderText = "Estado";
            this.dtgvHistorial.Columns["DetalleProductos"].DisplayIndex = 0;

            this.dtgvHistorial.ClearSelection();
        }

        private void ConfigurarDataGrid()
        {
            this.dtgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgvHistorial.MultiSelect = false;
            this.dtgvHistorial.ReadOnly = true;
            this.dtgvHistorial.RowHeadersVisible = false;
            this.dtgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvHistorial.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dtgvHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtgvHistorial.AllowUserToAddRows = false;

            this.dtgvHistorial.ClearSelection();

        }
    }
}
