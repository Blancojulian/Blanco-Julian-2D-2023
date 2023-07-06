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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SegundoParcial.Vista
{
    public partial class FrmHeladera : FrmBase
    {//hacer columna checkbox para elegir que serializar
        public event Action OnAbrirLogin;
        private OpenFileDialog _openFileDialog;
        private SaveFileDialog _saveFileDialog;
        private Vendedor _vendedor;
        private int _lastIndex;
        //private List<Corte> _listaCortes;
        private string _ultimoArchivo;
        public FrmHeladera(Vendedor vendedor) : base()
        {
            InitializeComponent();
            this._vendedor = vendedor;
            this._lastIndex = 0;
            this._openFileDialog = new OpenFileDialog();
            this._openFileDialog.Filter = "Archivo JSON|*.json|Archivo XML|*.xml";
            this._saveFileDialog = new SaveFileDialog();
            this._saveFileDialog.Filter = "Archivo JSON|*.json|Archivo XML|*.xml";
            //this._listaCortes = new List<Corte>();
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
        private void FrmHeladera_Load(object sender, EventArgs e)
        {
            this.cbxFiltro.DataSource = Enum.GetValues(typeof(Filtros));
            this.cbxFiltro.SelectedItem = Filtros.Disponible;
            this.ConfigurarDataGrid();
            this.CargarTablaDeProductos(this._vendedor.GetProductos((Filtros)this.cbxFiltro.SelectedItem));
            this.lblVendedor.Text = this._vendedor.MostrarNombreApellido();
            this.dtgvDatos.ClearSelection();
            this.SetOpcionesSerializacion(false);
            this.dtgvDatos.Columns["Seleccionar"].Visible = false;
            this.dtgvDatos.Columns["Disponible"].Visible = false;

            this._vendedor.OnReponerStock += NotificarReponerStock;

        }

        private void CargarTablaDeProductos(List<Corte> listaCortes)
        {
            try
            {
                //this._listaCortes = this._vendedor.GetProductos((Filtros)this.cbxFiltro.SelectedItem);
                //this._listaCortes = listaCortes;
                this.dtgvDatos.DataSource = listaCortes;
                this.dtgvDatos.Update();
                this.dtgvDatos.Refresh();
                //this.dtgvDatos.ClearSelection();
                if (this.dtgvDatos.Rows.Count > 0 && this._lastIndex < this.dtgvDatos.Rows.Count)
                {
                    this.dtgvDatos.Rows[this._lastIndex].Selected = true;
                }

            }
            catch (Exception ex)
            {
                MostrarVentanaDeError(ex);
            }
        }

        private void SetLastIndex()
        {
            this._lastIndex = this.dtgvDatos.CurrentRow.Index;
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

        private Corte GetProducto()
        {
            if (this.dtgvDatos.CurrentRow is null && this.dtgvDatos.SelectedRows.Count < 1)
            {
                throw new Exception("Debe selecionar un producto");
            }

            if (this.dtgvDatos.SelectedRows.Count > 1)
            {
                throw new Exception("Debe selecionar un solo producto");
            }

            return (Corte)this.dtgvDatos.CurrentRow.DataBoundItem;
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
                    //MessageBox.Show("No se encontro el producto " + searchValue);
                    this.dtgvDatos.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BuscarFiltro()
        {
            string searchValue = this.tbxFiltrar.Text;
            searchValue = searchValue.ToLower().Trim();
            this.lblFiltroBuscado.Text = searchValue;
            try
            {
                this.CargarTablaDeProductos(this._vendedor.GetProductos(searchValue, (Filtros)this.cbxFiltro.SelectedItem));

            }
            catch (Exception ex)
            {
                MostrarVentanaDeError(ex);
            }
        }

        private void SetOpcionesSerializacion(bool serializar)
        {
            this.btnSeleccionarTodos.Enabled = serializar;
            this.btnSeleccionarTodos.Visible = serializar;
            this.btnDeseleccionarTodos.Enabled = serializar;
            this.btnDeseleccionarTodos.Visible = serializar;
            this.btnGuardar.Enabled = serializar;
            this.btnGuardar.Visible = serializar;
            this.btnGuardarComo.Enabled = serializar;
            this.btnGuardarComo.Visible = serializar;
            this.btnCancelar.Enabled = serializar;
            this.btnCancelar.Visible = serializar;
            this.lblMensaje.Enabled = serializar;
            this.lblMensaje.Visible = serializar;
            this.dtgvDatos.Columns["Seleccionar"].Visible = serializar;

            if (!serializar)
            {
                SetColumnaSeleccionar(false);
            }

        }

        private void SetColumnaSeleccionar(bool valor)
        {

            foreach (DataGridViewRow row in this.dtgvDatos.Rows)
            {
                row.Cells["Seleccionar"].Value = valor;
            }
        }

        protected override void ConfigurarColorForm()
        {
            this.BackColor = Color.FromArgb(222, 122, 34);
        }

        private void cbxFiltro_SelectedValueChanged(object sender, EventArgs e)
        {
            this.CargarTablaDeProductos(this._vendedor.GetProductos((Filtros)this.cbxFiltro.SelectedItem));
            this.lblFiltroBuscado.Text = string.Empty;
            this.dtgvDatos.ClearSelection();
        }

        private void tbxBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarProducto();
        }

        private void btnReponer_Click(object sender, EventArgs e)
        {

            double stock = (double)this.nudCantidad.Value;
            Corte corte;

            try
            {
                this._playerClick.Play();
                corte = GetProducto();
                this._vendedor.ReponerStock(corte, stock);
                this.SetLastIndex();
                //this.CargarTablaDeProductos();
                this.CargarTablaDeProductos(this._vendedor.GetProductos((Filtros)this.cbxFiltro.SelectedItem));

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
            this.dtgvDatos.CurrentCell = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            FrmCorteAgregar frm = new FrmCorteAgregar();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK && frm.Corte is not null)
            {
                this._vendedor.AgregarCorte(frm.Corte);
                this.SetLastIndex();
                //this.CargarTablaDeProductos();
                this.CargarTablaDeProductos(this._vendedor.GetProductos((Filtros)this.cbxFiltro.SelectedItem));

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

            Corte corte;

            try
            {
                this._playerClick.Play();
                corte = GetProducto();
                //MessageBox.Show($"{corte.Nombre}");
                FrmCorteModificar frm = new FrmCorteModificar(corte, this._vendedor.ExisteNombreCorte);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    corte = frm.Corte;
                    this._vendedor.ModificarCorte(corte.Id, corte);
                    this.SetLastIndex();
                    //this.CargarTablaDeProductos();
                    this.CargarTablaDeProductos(this._vendedor.GetProductos((Filtros)this.cbxFiltro.SelectedItem));

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
            catch (Exception ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Corte corte = GetProducto();

                DialogResult dialogResult = MessageBox.Show($"¿Desea eliminar el producto {corte.Nombre}?", "Confirmar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this._vendedor.EliminarCorte(corte.Id);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void NotificarReponerStock(InfoStockEventArgs infoStock)
        {
            MessageBox.Show($"Ingresaro {infoStock.StockRepuesto} kilos de {infoStock.NombreCorte}");

        }

        private void dtgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                this._playerClick.Play();
                bool check = Convert.ToBoolean(senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !check;

            }
        }

        private void msiAbrir_Click(object sender, EventArgs e)
        {
            List<Corte> listaCortes;
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UltimoArchivo = _openFileDialog.FileName;

                try
                {
                    switch (Path.GetExtension(UltimoArchivo))
                    {
                        case ".json":
                            listaCortes = this._vendedor.SerializadorProductosJson.Leer(UltimoArchivo);
                            break;
                        case ".xml":
                            listaCortes = this._vendedor.SerializadorProductosXml.Leer(UltimoArchivo);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MostrarVentanaDeError(ex);
                }
            }
        }
        private List<Corte> GetCortesSeleccionados()
        {
            List<Corte> listaCortes = new List<Corte>();


            foreach(DataGridViewRow row in this.dtgvDatos.Columns)
            {
                if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                {
                    listaCortes.Add((Corte)row.DataBoundItem);
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
                List<Corte> listaCortes = GetCortesSeleccionados();

                switch (Path.GetExtension(UltimoArchivo))
                {
                    case ".json":
                        this._vendedor.SerializadorProductosJson.Guardar(UltimoArchivo, listaCortes);
                        break;
                    case ".xml":
                        this._vendedor.SerializadorProductosXml.Guardar(UltimoArchivo, listaCortes);
                        break;
                }
            }
            catch (Exception ex)
            {
                MostrarVentanaDeError(ex);
            }
        }

        private void Guardar()
        {
            try
            {
                List<Corte> listaCortes = GetCortesSeleccionados();
                switch (Path.GetExtension(UltimoArchivo))
                {
                    case ".json":
                        this._vendedor.SerializadorProductosJson.Guardar(UltimoArchivo, listaCortes);
                        break;
                    case ".xml":
                        this._vendedor.SerializadorProductosXml.Guardar(UltimoArchivo, listaCortes);
                        break;
                }
            }
            catch (Exception ex)
            {
                MostrarVentanaDeError(ex);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
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
            this._playerClick.Play();
            GuardarComo();
        }

        private void btnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            this.SetColumnaSeleccionar(true);
        }

        private void btnDeseleccionarTodos_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            this.SetColumnaSeleccionar(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            this.SetOpcionesSerializacion(false);

        }

        private void msiSerializar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            this.SetOpcionesSerializacion(true);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            this.BuscarFiltro();
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            this.lblFiltroBuscado.Text = string.Empty;
            this.CargarTablaDeProductos(this._vendedor.GetProductos((Filtros)this.cbxFiltro.SelectedItem));
        }

        private void msiVender_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            FrmVendedor frmVendedor = new FrmVendedor(this._vendedor);
            frmVendedor.ShowDialog();
            //frmVendedor.Show();
            //this.Hide();
        }

        private void msiHistorial_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            FrmHistorial frmHistorial = new FrmHistorial(this._vendedor);
            frmHistorial.ShowDialog();
            //frmHistorial.Show();
            //this.Hide();
        }

        private void msiCerrarSesion_Click(object sender, EventArgs e)
        {
            this.OnAbrirLogin?.Invoke();
            this.Close();

        }

        private void FrmHeladera_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.OnAbrirLogin?.Invoke();
            
        }
    }
}
