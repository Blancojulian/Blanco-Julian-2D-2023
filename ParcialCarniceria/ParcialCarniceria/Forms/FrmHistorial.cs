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
            this.cbxFiltro.DataSource = Enum.GetValues(typeof(EstadoVenta));
            this.cbxFiltro.SelectedItem = EstadoVenta.Todas;
            
            this.lblNombre.Text = this._vendedor.MostrarNombreApellido();
            this.ConfiguarForm();
            this.ConfigurarDataGrid();
            this.CargarHistorial();
        }

        private void FrmHistorial_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._frmPadre.Show();
        }

        private void CargarHistorial()
        {
            this.dtgvHistorial.DataSource = this._vendedor.GetCompras((EstadoVenta)this.cbxFiltro.SelectedItem);
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

        private void Buscar()
        {
            string searchValue = this.tbxBuscar.Text;
            searchValue = searchValue.ToLower().Trim();
            try
            {
                bool valueResult = false;
                int rowIndex;
                string str;

                foreach (DataGridViewRow row in this.dtgvHistorial.Rows)
                {
                    rowIndex = row.Index;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        str = $"{cell.Value}";

                        if (//row.Cells["Producto"].Value is not null &&
                            !string.IsNullOrEmpty(str) &&
                            !string.IsNullOrWhiteSpace(str) &&
                            !string.IsNullOrEmpty(searchValue) &&
                            str.ToLower().Contains(searchValue))
                        {
                            
                            this.dtgvHistorial.Rows[rowIndex].Selected = true;
                            this.dtgvHistorial.FirstDisplayedScrollingRowIndex = rowIndex;
                            valueResult = true;
                            break;

                        }

                    }


                }
                if (!valueResult)
                {
                    //MessageBox.Show("No se encontro el producto " + searchValue);
                    this.dtgvHistorial.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxFiltro_SelectedValueChanged(object sender, EventArgs e)
        {
            this.CargarHistorial();
        }

        private void tbxBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void ConfiguarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.ControlBox = false;
            this.ShowIcon = false;
            this.BackColor = Color.FromArgb(222, 122, 34);
        }
    }
}
