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
    public partial class FrmListadoCompras : Form
    {
        private Vendedor _vendedor;
        private Cliente _cliente;

        public FrmListadoCompras(Vendedor vendedor, Cliente cliente)
        {
            InitializeComponent();
            this._vendedor = vendedor;
            this._cliente = cliente;
        }

        private void FrmListadoCompras_Load(object sender, EventArgs e)
        {
            this.lblCliente.Text += " " + this._cliente.MostrarNombreApellido();
            this.lblDineroDisponible.Text = $"{this._cliente.Dinero}";
            ConfiguarForm();
            ConfigurarDataGrid();
            CargarTablaDeCompras();
            this.dtgvDatos.ClearSelection();
            this.dtgvDatos.ClearSelection();

        }

        private void CargarTablaDeCompras()
        {
            this.dtgvDatos.DataSource = this._cliente.Compras;
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgvDatos.SelectedRows.Count > 0)
                {
                    string mensaje = string.Empty;
                    bool respuesta = false;
                    Compra compra = SeleccionarCompra();
                    DialogResult dialogResult = MessageBox.Show("¿Desea realizar la venta?", "Confirmar", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        respuesta = this._vendedor.RealizarVenta(this._cliente, compra, out mensaje);
                    }

                    if (!respuesta && dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show(mensaje);
                    }
                    this.lblDineroDisponible.Text = $"{this._cliente.Dinero}";
                    //CargarTablaDeCompras();
                    this.dtgvDatos.Update();
                    this.dtgvDatos.Refresh();
                    this.dtgvDatos.ClearSelection();
                }
                else
                {
                    MessageBox.Show($"Debe seleccionar una compra");

                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show($"Debe seleccionar una compra");

            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}");
            }
            
        }

        private Compra SeleccionarCompra()
        {
            
            return (Compra)this.dtgvDatos.CurrentRow.DataBoundItem;
        }

        private void ConfiguarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.BackColor = Color.FromArgb(222, 122, 34);
        }
    }
}
