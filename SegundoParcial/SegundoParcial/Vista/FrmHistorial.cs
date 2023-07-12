using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Excepciones;
using BibliotecaEntidades.MetodosDeExtension;
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
    public partial class FrmHistorial : FrmBase
    {
        private Vendedor _vendedor;
        private SaveFileDialog _saveFileDialog;
        private OpenFileDialog _openFileDialog;
        private string _ultimoArchivo;


        public FrmHistorial(Vendedor vendedor) : base()
        {
            InitializeComponent();
            this._vendedor = vendedor;
            this._saveFileDialog = new SaveFileDialog();
            this._saveFileDialog.Filter = "Archivo de texto|*.txt";
            this._openFileDialog = new OpenFileDialog();
            this._openFileDialog.Filter = "Archivo de texto|*.txt";
        }
        private string UltimoArchivo
        {
            get => _ultimoArchivo;

            set
            {
                if (!value.EsCadenaVaciaOTieneEspacios())
                {
                    _ultimoArchivo = value;
                }
            }
        }
        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            //this._vendedor.GetFacturas();
            this.cbxEstadoVenta.DataSource = Enum.GetValues(typeof(EstadoVenta));
            this.cbxEstadoVenta.SelectedItem = EstadoVenta.Todas;

            this.lblNombre.Text = this._vendedor.MostrarNombreApellido();
            this.ConfigurarDataGrid();
            this.CargarHistorial(this._vendedor.GetFacturas((EstadoVenta)this.cbxEstadoVenta.SelectedItem));
        }

        protected override void ConfigurarColorForm()
        {
            this.BackColor = Color.FromArgb(222, 122, 34);
        }
        protected override void ConfigurarForm()
        {
            base.ConfigurarForm();
            this.ControlBox = false;

        }


        private void CargarHistorial(List<Factura> listaFacturas)
        {// ver que propiedades cambiaron en la clase Factura
            //this.dtgvHistorial.DataSource = this._vendedor.GetFacturas((EstadoVenta)this.cbxEstadoVenta.SelectedItem);
            this.dtgvHistorial.DataSource = listaFacturas;
            this.dtgvHistorial.Columns["Credito"].Visible = false;
            this.dtgvHistorial.Columns["Productos"].Visible = false;
            this.dtgvHistorial.Columns["NumeroFactura"].HeaderText = "Numero Factura";
            this.dtgvHistorial.Columns["DniCliente"].HeaderText = "DNI Cliente";
            this.dtgvHistorial.Columns["NombreCliente"].HeaderText = "Nombre Cliente";
            this.dtgvHistorial.Columns["CreditoDebito"].HeaderText = "Credito/Debito";
            this.dtgvHistorial.Columns["DetalleProductos"].HeaderText = "Detalle Productos";
            //this.dtgvHistorial.Columns["VentaRealizada"].HeaderText = "Estado";
            this.dtgvHistorial.Columns["DetalleProductos"].DisplayIndex = 1;

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
        private void SetColumnaSeleccionar(bool valor)
        {

            foreach (DataGridViewRow row in this.dtgvHistorial.Rows)
            {
                row.Cells["Seleccionar"].Value = valor;
            }
        }
        
        private void BuscarFiltro()
        {
            string searchValue = this.tbxBuscar.Text;
            searchValue = searchValue.ToLower().Trim();
            this.lblTextoBuscado.Text = searchValue;
            try
            {
                this.CargarHistorial(this._vendedor.GetFacturas(searchValue, (EstadoVenta)this.cbxEstadoVenta.SelectedItem));

            }
            catch (Exception ex)
            {
                this.PlayError();
                MostrarVentanaDeError(ex);
            }
        }

        private List<Factura> GetFacturasSeleccionados()
        {
            List<Factura> listaCortes = new List<Factura>();

            foreach (DataGridViewRow row in this.dtgvHistorial.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                {
                    listaCortes.Add((Factura)row.DataBoundItem);
                }
            }

            if (listaCortes.Count <= 0)
            {
                throw new ArchivoIncorrectoExcepcion("Debe seleccionar productos para serializar");
            }

            return listaCortes;
        }
        private string SeleccionarUbicacionGuardado()
        {
            return _saveFileDialog.ShowDialog() == DialogResult.OK ? _saveFileDialog.FileName : string.Empty;
        }

        private void GuardarComo()
        {
            UltimoArchivo = SeleccionarUbicacionGuardado();

            try
            {
                List<Factura> listaFacturas = GetFacturasSeleccionados();

                if (Path.GetExtension(UltimoArchivo) == ".txt")
                {
                    this._vendedor.SerializadorFacturasTxt.GuardarComo(UltimoArchivo, listaFacturas);
                }
            }
            catch (Exception ex)
            {
                this.PlayError();
                MostrarVentanaDeError(ex);
            }
        }

        private void Guardar()
        {
            try
            {
                List<Factura> listaFacturas = GetFacturasSeleccionados();
                if (Path.GetExtension(UltimoArchivo) == ".txt")
                {
                    this._vendedor.SerializadorFacturasTxt.Guardar(UltimoArchivo, listaFacturas);
                }
            }
            catch (Exception ex)
            {
                this.PlayError();
                MostrarVentanaDeError(ex);
            }
        }

        private void cbxEstadoVenta_SelectedValueChanged(object sender, EventArgs e)
        {
            this.CargarHistorial( this._vendedor.GetFacturas((EstadoVenta)this.cbxEstadoVenta.SelectedItem) );
            this.tbxBuscar.Text = string.Empty;
            this.lblTextoBuscado.Text = string.Empty;
            
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            this.BuscarFiltro();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            this.lblTextoBuscado.Text = string.Empty;
            this.CargarHistorial(this._vendedor.GetFacturas((EstadoVenta)this.cbxEstadoVenta.SelectedItem));
        }

        private void dtgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.PlayClick();

            DataGridView senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                this.PlayClick();
                bool check = Convert.ToBoolean(senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !check;

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            if (!File.Exists(UltimoArchivo))
            {
                GuardarComo();
            }
            else
            {
                Guardar();
            }
        }

        private void btnGuardarComo_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            GuardarComo();
        }

        private void btnSeleccionarTodas_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            this.SetColumnaSeleccionar(true);
        }

        private void btnDeseleccionarTodas_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            this.SetColumnaSeleccionar(false);
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            this.PlayClick();

            List<Factura> listaFacturas;
            FrmMostrar<Factura> frmMostrar;
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UltimoArchivo = _openFileDialog.FileName;

                try
                {
                    
                    if (!(Path.GetExtension(UltimoArchivo) == ".txt"))
                    {
                        throw new ArchivoIncorrectoExcepcion("Error, Extension desconocida");

                    }
                    listaFacturas = this._vendedor.SerializadorFacturasTxt.LeerFacturaTXT(UltimoArchivo);
                    frmMostrar = new FrmMostrar<Factura>(listaFacturas, "Facturas");
                    frmMostrar.ShowDialog();

                    
                }
                catch (Exception ex)
                {
                    this.PlayError();
                    MostrarVentanaDeError(ex);
                }
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
