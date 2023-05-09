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
    public partial class FrmHeladera : Form
    {
        private Vendedor _vendedor;
        private Form _frmPadre;
        private int _lastIndex;
        private SoundPlayer _playerError;
        private SoundPlayer _playerClick;
        public FrmHeladera(Vendedor vendedor, Form frmPadre)
        {
            InitializeComponent();
            this._vendedor = vendedor;
            this._frmPadre = frmPadre;
            this._lastIndex = 0;
            this._playerClick = new SoundPlayer(Properties.Resources.click);
            this._playerError = new SoundPlayer(Properties.Resources.error);
        }

        private void FrmHeladera_Load(object sender, EventArgs e)
        {
            
            this.cbxFiltro.DataSource = Enum.GetValues(typeof(Filtros));
            this.cbxFiltro.SelectedItem = Filtros.Disponible;
            this.ConfiguarForm();
            this.ConfigurarDataGrid();
            this.CargarTablaDeProductos();
            this.lblVendedor.Text = this._vendedor.MostrarNombreApellido();
            this.dtgvDatos.ClearSelection();

        }

        private void FrmHeladera_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._frmPadre.Show();
        }
        
        private void CargarTablaDeProductos()
        {
            this.dtgvDatos.DataSource = this._vendedor.GenerarTablaDeInfomacion((Filtros)this.cbxFiltro.SelectedItem);
            this.dtgvDatos.Update();
            this.dtgvDatos.Refresh();
            //this.dtgvDatos.ClearSelection();
            if (this.dtgvDatos.Rows.Count > 0 && this._lastIndex < this.dtgvDatos.Rows.Count)
            {
                this.dtgvDatos.Rows[this._lastIndex].Selected = true;
            }

        }

        private void SetLastIndex()
        {
            this._lastIndex = this.dtgvDatos.CurrentRow.Index;
        }

        private void msiVender_Click(object sender, EventArgs e)
        {
            FrmVendedor frmVendedor = new FrmVendedor(this._vendedor, this);
            frmVendedor.Show();
            this.Hide();
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
                    //MessageBox.Show("No se encontro el producto " + searchValue);
                    this.dtgvDatos.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            this.tbxBuscar.Text = string.Empty;
            this.dtgvDatos.ClearSelection();

        }

        private void msiHistorial_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            FrmHistorial frmHistorial = new FrmHistorial(this._vendedor, this);
            frmHistorial.Show();
            this.Hide();
        }

        private void cbxFiltro_SelectedValueChanged(object sender, EventArgs e)
        {
            this.CargarTablaDeProductos();
            this.dtgvDatos.ClearSelection();
        }

        private void btnReponer_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            double stock = (double)this.nudCantidad.Value;
            string producto;

            if (GetNombreProducto(out producto))
            {
                this._vendedor.ReponerStock(producto, stock);
                this.SetLastIndex();
                this.CargarTablaDeProductos();
            }
            else
            {
                this._playerError.Play();
                MessageBox.Show("Debe selecionar un producto");
            }
        }

        private void tbxBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarProducto();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            FrmCorteAgregar frm = new FrmCorteAgregar();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK && 
                (frm.NombreCorte is not null && frm.DetalleCorte is not null) &&
                this._vendedor.AgregarCorte(frm.NombreCorte, frm.DetalleCorte))
            {
                this.SetLastIndex();
                this.CargarTablaDeProductos();
            }
            else if (frm.DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("Se cancelo la operacion");
            }
            else
            {
                this._playerError.Play();
                MessageBox.Show("Fallo al agregar el producto");
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            string producto;
            bool boolProducto = GetNombreProducto(out producto);
            DetalleCorte? detalle = this._vendedor.GetDetalleCorte(producto);
            
            if (boolProducto && detalle is not null)
            {
                FrmCorteModificar frm = new FrmCorteModificar(producto, detalle);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    this.SetLastIndex();
                    this.CargarTablaDeProductos();
                }
                else if (frm.DialogResult == DialogResult.Cancel)
                {
                    MessageBox.Show("Se cancelo la operacion");
                }
                else
                {
                    this._playerError.Play();
                    MessageBox.Show("Fallo al agregar el producto");
                }
            }
            else if (!boolProducto)
            {
                this._playerError.Play();
                MessageBox.Show("Debe seleccionar un producto");
            }
            else
            {
                MessageBox.Show("El producto no existe");

            }
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
