using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public sealed class Heladera
    {
        private Dictionary<string, DetalleCorte> _cortesCarne;

        public Heladera() : this(CargarCortesDeCarne())
        {
            
        }
        private Heladera(Dictionary<string, DetalleCorte> cortesCarne)
        {
            this._cortesCarne = cortesCarne;
        }

        public Dictionary<string, DetalleCorte> Cortes => this._cortesCarne;
        public Dictionary<string, DetalleCorte> CortesDisponibles => FiltarCortes(true);
        public Dictionary<string, DetalleCorte> CortesNoDisponibles => FiltarCortes(false);

        public DetalleCorte? GetDetalleCorte(string corte)
        {
            DetalleCorte? detalleCorte = null;

            if (this._cortesCarne.ContainsKey(corte))
            {
                detalleCorte = this._cortesCarne[corte];
            }
           
            return detalleCorte;
        }

        public bool HayStockCorte(Compra compra, out string strMensaje)
        {
            bool retorno = true;
            var sb = new StringBuilder();
            DetalleCorte? detalle;

            foreach (KeyValuePair<string, double> producto in compra.Productos)
            {
                detalle = this.GetDetalleCorte(producto.Key);

                if (detalle is not null && !(detalle - producto.Value))
                {
                    sb.AppendLine($"{producto.Key}");
                    retorno = false;
                }
                
            }

            strMensaje = retorno ? string.Empty : $"No hay stock de los producto:\n{sb.ToString()}";

            return retorno;
        }

        public bool AgregarCorte(string nombre, DetalleCorte detalleCorte)
        {
            bool retorno = !this._cortesCarne.ContainsKey(nombre);
            if (retorno)
            {
                this._cortesCarne.Add(nombre, detalleCorte);
            }

            return retorno;
        }

        public void ReponerStock(string corte, double stock)
        {
            DetalleCorte? detalle = this.GetDetalleCorte(corte);
            if (detalle is not null)
            {
                detalle.StockKilos += stock;
            }

        }

        public DataTable GenerarTablaDeProductos(Dictionary<string, DetalleCorte> cortes)
        {
            DataTable dt = new DataTable();
            string disponible;

            dt.Columns.Add("Producto");
            dt.Columns.Add("Stock");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Disponible");
            dt.Columns.Add("Categoria");
            dt.Columns.Add("Detalle");

            foreach (KeyValuePair<string, DetalleCorte> c in cortes)
            {
                disponible = c.Value.Disponible ? "disponible" : "no disponible";
                dt.Rows.Add(c.Key, c.Value.StockKilos, c.Value.PrecioKilo, disponible, c.Value.Categoria, c.Value.Detalle);
            }
            return dt;
        }
        public DataTable GenerarTablaDeProductos()
        {
            return this.GenerarTablaDeProductos(this.Cortes);
        }
        public DataTable GenerarTablaDeProductos(Filtros filtro)
        {
            DataTable dt;

            switch (filtro)
            {
                case Filtros.Disponible:
                    dt = GenerarTablaDeProductos(this.CortesDisponibles);
                    break;
                case Filtros.No_Disponible:
                    dt = GenerarTablaDeProductos(this.CortesNoDisponibles);

                    break;
                case Filtros.Todos:
                    dt = GenerarTablaDeProductos();

                    break;
                default:
                    dt = GenerarTablaDeProductos();
                    break;
            }

            return dt;
        }
        private Dictionary<string, DetalleCorte> FiltarCortes(bool disponible)
        {
            Dictionary<string, DetalleCorte> cortes = new Dictionary<string, DetalleCorte>();

            foreach (KeyValuePair<string, DetalleCorte> corte in this._cortesCarne)
            {
                if (corte.Value.Disponible == disponible)
                {
                    cortes.Add(corte.Key, corte.Value);
                }
            }
            return cortes;
        }
        private static Dictionary<string, DetalleCorte> CargarCortesDeCarne()
        {
            Dictionary<string, DetalleCorte> cortes = new Dictionary<string, DetalleCorte>();

            cortes.Add("Aguja", new DetalleCorte(50, 500, Categorias.Segunda, "Delicioso corte, ideal para guisos"));
            cortes.Add("Asado", new DetalleCorte(100, 600, Categorias.Tercera));
            cortes.Add("Cuadril", new DetalleCorte(50, 400, Categorias.Primera));
            cortes.Add("Falda", new DetalleCorte(50, 670, Categorias.Tercera));
            cortes.Add("Lomo", new DetalleCorte(0, 550, Categorias.Segunda));
            cortes.Add("Matambre", new DetalleCorte(50, 800, Categorias.Primera));
            cortes.Add("Peceto", new DetalleCorte(0, 500, Categorias.Primera));
            cortes.Add("Vacio", new DetalleCorte(0, 500, Categorias.Primera));
            cortes.Add("Bola de Lomo", new DetalleCorte(50, 900, Categorias.Primera));


            return cortes;
        }

    }
}
