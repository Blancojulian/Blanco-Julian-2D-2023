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
    public partial class FrmPrueba : Form
    {
        public FrmPrueba()
        {
            InitializeComponent();
        }

        private void FrmPrueba_Load(object sender, EventArgs e)
        {

            this.dtgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDatos.MultiSelect = false;
            //cambia a solamente lectura
            this.dtgvDatos.ReadOnly = true;
            //le saca la flechita que tiene al costado la fila
            this.dtgvDatos.RowHeadersVisible = false;
            this.dtgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvDatos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dtgvDatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //this.dtgvDatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            this.dtgvDatos.DataSource = GenerarTablaDeProductos();
            this.dtgvDatos.ClearSelection();
        }

        private DataTable GenerarTablaDeProductos()
        {
            Dictionary<string, DetalleCorte> cortes = Carniceria.Heladera.Cortes;
            DataTable dt = new DataTable();


            dt.Columns.Add("Nombre");
            dt.Columns.Add("stock (kilo)");
            dt.Columns.Add("Precio x kilo");
            dt.Columns.Add("Categoria");

            foreach (KeyValuePair<string, DetalleCorte> c in cortes)
            {
                dt.Rows.Add(c.Key, c.Value.StockKilos, c.Value.PrecioKilo, c.Value.Categoria);
            }

            return dt;
        }
    }
}
