using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class Compra
    {
        //private List<DetalleCompra> detalles;
        private Dictionary<string, double> _productos;
        private bool _vendido;
        private bool _credito;
        private string? _nombreCliente;

        
        public Compra(Dictionary<string, double> productos, bool credito)
        {
            this._productos = productos;
            this._vendido = false;
            this._credito = credito;
        }
        public Compra(bool credito) : this(new Dictionary<string, double>(), credito)
        {

        }
        public Compra() : this(false)
        {

        }

        public bool Vendido { get => this._vendido; set => this._vendido = value; }
        public bool Credito { get => this._credito; set => this._credito = value; }

        public string? NombreCliente { get => this._nombreCliente; set => this._nombreCliente = value; }
        public string CreditoDebito => Credito ? "Credito" : "Debito";
        public string VentaRealizada => Vendido ? "Realizada" : "En proceso";

        public string DetalleProductos
        {
            get
            {//ver mejor
                var sb = new StringBuilder();
                double precio;
                double total = 0;
                DetalleCorte? detalle;

                foreach (KeyValuePair<string, double> producto in this._productos)
                {
                    detalle = Carniceria.Heladera.GetDetalleCorte(producto.Key);
                    if (detalle is not null)
                    {
                        precio = detalle.CalcularPrecio(producto.Value);
                        total += precio;
                        sb.AppendLine($"{producto.Key} cantidad: {producto.Value} KG precio: ${precio:0.00}");
                        //total += detalle.CalcularPrecio(producto.Value);
                    }

                }

                if (this._productos.Count > 0 && Credito)
                {
                    sb.AppendLine($"5% de recargo: {(total * 0.05):0.00}");
                }
               

                return sb.ToString();
            }
        }

        public double Total
        {
            get
            {
                var sb = new StringBuilder();
                double precio;
                double total = 0d;
                DetalleCorte? detalle;

                foreach (KeyValuePair<string, double> producto in this._productos)
                {
                    detalle = Carniceria.Heladera.GetDetalleCorte(producto.Key);
                    if (detalle is not null)
                    {
                        precio = detalle.CalcularPrecio(producto.Value);
                        total += precio;
                    }

                }

                if ( Credito)
                {
                    total *= 1.05;
                }
               

                return total;
            }
        }
        
        public Dictionary<string, double> Productos => this._productos;

        public bool AgregarProducto(string producto, double cantidad)
        {
            DetalleCorte? detalle = Carniceria.Heladera.GetDetalleCorte(producto);
            bool retorno = cantidad > 0d && detalle is not null && !this._productos.ContainsKey(producto);
            
            if (retorno)
            {
                this._productos.Add(producto, cantidad);
            }

            return retorno;
        }
        public bool ModificarProducto(string producto, double cantidad)
        {
            DetalleCorte? detalle = Carniceria.Heladera.GetDetalleCorte(producto);
            bool retorno = cantidad > 0d && detalle is not null && this._productos.ContainsKey(producto);
            
            if (retorno)
            {
                this._productos[producto] = cantidad;
            }

            return retorno;
        }
        public bool EliminarProducto(string producto)
        {
            bool retorno = this._productos.ContainsKey(producto);

            if (retorno)
            {
                this._productos.Remove(producto);
            }

            return retorno;
        }
        public void EliminarProducto()
        {
            this._productos.Clear();
        }

        /*
        public DataRow Detalle => (DataRow)this;

        public static explicit operator DataRow(Compra c)
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            return dr;
        }
        */



        //no usar
        /*
        public bool CalcularTotal(out double total, out string strMensaje)
        {
            double resTotal = 0;
            bool retorno = true;
            string str = string.Empty;
            DetalleCorte? detalle;

            foreach (KeyValuePair<Cortes, double> producto in this._productos)
            {
                detalle = Carniceria.Heladera.GetDetalleCorte(producto.Key);

                if (detalle - producto.Value)
                {
                    resTotal += detalle.CalcularPrecio(producto.Value);
                }
                else
                {
                    resTotal = 0;
                    str = $"No hay stock del producto: {producto.Key}";
                    retorno = false;
                    break;
                }
            }

            if (Credito)
            {
                resTotal *= 1.05;
            }

            total = resTotal;
            strMensaje = str;

            return retorno;
        }*/

        //ver si usar ese, para mantener la logica separada
        public double CalcularTotal()
        {
            double total = 0;
            DetalleCorte? detalle;

            foreach (KeyValuePair<string, double> producto in this._productos)
            {
                detalle = Carniceria.Heladera.GetDetalleCorte(producto.Key);
                if (detalle is not null)
                {
                    total += detalle.CalcularPrecio(producto.Value);
                }
                
            }

            if (Credito)
            {
                total *= 1.05;
            }


            return total;
        }

        //este descartado
        /*
        public static bool CalcularTotal(Dictionary<string, double> productos, out double total, out string strMensaje)
        {
            double resTotal = 0;
            bool retorno = true;
            string str = string.Empty;
            DetalleCorte? detalle;
            foreach (KeyValuePair<string, double> producto in productos)
            {
                detalle = Carniceria.Heladera.GetDetalleCorte(producto.Key);

                if (detalle - producto.Value)
                {
                    resTotal += detalle.CalcularPrecio(producto.Value);
                }
                else
                {
                    resTotal = 0;
                    str = $"No hay stock del producto: {producto.Key}";
                    retorno = false;
                }
            }

            total = resTotal;
            strMensaje = str;

            return retorno;
        }*/
    }
}
