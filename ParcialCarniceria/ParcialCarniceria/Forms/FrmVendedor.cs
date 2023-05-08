﻿using BibliotecaEntidades.Entidades;
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
    public partial class FrmVendedor : Form
    {
        private Vendedor _vendedor;
        private Form _frmPadre;
        public FrmVendedor(Vendedor vendedor, Form frmPadre)
        {
            InitializeComponent();
            this._vendedor = vendedor;
            this._frmPadre = frmPadre;
        }

        private void FrmVendedor_Load(object sender, EventArgs e)
        {
            ConfiguarForm();
            ConfigurarDataGrid();
            CargarTablaDeClientes();
        }


        private void CargarTablaDeClientes()
        {
            
            this.dtgvDatos.DataSource = this._vendedor.GenerarTablaDeInfomacion();
            this.dtgvDatos.Columns["VerCompras"].DisplayIndex = this.dtgvDatos.Columns.Count - 1;
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
            //this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(222, 122, 34);
        }

        private void dtgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        e.RowIndex >= 0)
            {
                string mail = senderGrid.Rows[e.RowIndex].Cells["Mail"].Value.ToString() ?? "nulo";
                Cliente? cliente = this._vendedor.GetUsuario(mail);

                if (cliente is not null)
                {
                    FrmListadoCompras frmCompras = new FrmListadoCompras(this._vendedor, cliente);
                    frmCompras.ShowDialog();
                    this.CargarTablaDeClientes();
                }
                //MessageBox.Show($"{e.ColumnIndex} row: {e.RowIndex} mail: {mail}");

            }
        }

        private void FrmVendedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._frmPadre.Show();
        }
    }
}
