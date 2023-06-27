using BibliotecaEntidades.DAO;
using BibliotecaEntidades.Interfaces;
using BibliotecaEntidades.MetodosDeExtension;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public delegate void ActualizarUltimoNumeroFactura(int numero);
    public class Factura : ITrabajarConTxt
    {
        private Dictionary<int, double> _productos;
        private int _dniCliente;
        private int _numeroFactura;
        private string? _nombreCliente;
        private bool _vendido;
        private bool _credito;
        private int _ultimoNumeroFactura;
        private Task _taskRefrescarNumero;

        

        private Factura(int numeroFactura, bool credito, bool vendido, int dniCliente, string nombreCliente, Dictionary<int, double> productos)
        {
            this._productos = productos;
            this._numeroFactura = numeroFactura;
            this._vendido = vendido;
            this._credito = credito;
            this._dniCliente = dniCliente;
            this._nombreCliente = nombreCliente;

            this._ultimoNumeroFactura = ClaseDAO.FacturaDAO.GetUltimoNumeroFactura();
            this._taskRefrescarNumero = Task.Run(RefrescarNumero);

            if (!vendido)
            {
                this._numeroFactura = _ultimoNumeroFactura + 1;
                OnActualizarUltimoNumeroFactura += ActualizarNumeroFacturaDeLaInstancia;
            }


        }
        public Factura(int numeroFactura, bool credito, bool vendido, int dniCliente, string nombreCliente) : this(numeroFactura, credito, vendido, dniCliente, nombreCliente, new Dictionary<int, double>())
        {

        }

        public Factura(bool credito, int dniCliente, string nombreCliente) : this(0, credito, false, dniCliente, nombreCliente)
        {

        }
        public Factura(int dniCliente, string nombreCliente) : this(0, false, false, dniCliente, nombreCliente)
        {

        }
        [JsonIgnore]
        public bool Vendido { 
            get => this._vendido; 
            set
            {
                if (value)
                {
                    OnActualizarUltimoNumeroFactura -= ActualizarNumeroFacturaDeLaInstancia;
                    
                } else
                {
                    this._ultimoNumeroFactura = ClaseDAO.FacturaDAO.GetUltimoNumeroFactura();
                    this._numeroFactura = _ultimoNumeroFactura + 1;
                    OnActualizarUltimoNumeroFactura += ActualizarNumeroFacturaDeLaInstancia;
                }

                this._vendido = value;
            } 
        }
        [JsonIgnore]
        public bool Credito { get => this._credito; set => this._credito = value; }
        //[JsonIgnore]
        //public int UltimoNumeroFactura => _ultimoNumeroFactura;
        public int NumeroFactura => this._numeroFactura;
        public int DniCliente => this._dniCliente;
        public string? NombreCliente { get => this._nombreCliente; set => this._nombreCliente = value; }
        public string CreditoDebito => Credito ? "Credito" : "Debito";
        public string VentaRealizada => Vendido ? "Realizada" : "En proceso";

        public string DetalleProductos => this.GenerarDetalleProductos();

        public double Total => this.CalcularTotal();
        public Dictionary<int, double> Productos => new Dictionary<int, double>(this._productos);

        public bool AgregarProducto(int idProducto, double cantidad)
        {
            Corte? detalle = ClaseDAO.CorteDAO.Get(idProducto);
            bool retorno = cantidad > 0d && detalle is not null && !this._productos.ContainsKey(idProducto);

            if (retorno)
            {
                this._productos.Add(idProducto, cantidad);
            }

            return retorno;
        }
        public bool ModificarProducto(int idProducto, double cantidad)
        {
            Corte? detalle = ClaseDAO.CorteDAO.Get(idProducto);
            bool retorno = cantidad > 0d && detalle is not null && this._productos.ContainsKey(idProducto);

            if (retorno)
            {
                this._productos[idProducto] = cantidad;
            }

            return retorno;
        }
        public bool EliminarProducto(int idProducto)
        {
            bool retorno = this._productos.ContainsKey(idProducto);

            if (retorno)
            {
                this._productos.Remove(idProducto);
            }

            return retorno;
        }
        public void EliminarProducto()
        {
            this._productos.Clear();
        }

        //no creo que se use mas
        /*
        public void ModificarNombreProducto(string nombre, string nuevoNombre)
        {
            bool retorno = this._productos.ContainsKey(nombre) && !this._productos.ContainsKey(nuevoNombre);
            if (retorno)
            {
                double value = this._productos[nombre];
                this._productos.Remove(nombre);
                this._productos.Add(nuevoNombre, value);
            }

        }*/


        private double CalcularTotal()
        {
            double precio;
            double total = 0d;
            Corte? detalle;
            List<Corte> listaCortes = ClaseDAO.CorteDAO.GetAll(this._productos.Keys.ToArray());


            foreach (KeyValuePair<int, double> producto in this._productos)
            {
                detalle = listaCortes.Find((c) => c.Id == producto.Key);

                if (detalle is not null)
                {
                    precio = detalle.CalcularPrecio(producto.Value);
                    total += precio;
                }

            }

            if (Credito)
            {
                total *= 1.05;
            }


            return total;
        }

        private string GenerarDetalleProductos()
        {
            var sb = new StringBuilder();
            double precio;
            double total = 0;
            string nombreCorte = string.Empty;
            Corte? detalle;
            List<Corte> listaCortes = ClaseDAO.CorteDAO.GetAll(this._productos.Keys.ToArray());

            foreach (KeyValuePair<int, double> producto in this._productos)
            {
                detalle = listaCortes.Find((c) => c.Id == producto.Key);

                nombreCorte = detalle is not null ? detalle.Nombre : $"Producto id {producto.Key}";

                if (detalle is not null)
                {
                    precio = detalle.CalcularPrecio(producto.Value);
                    total += precio;
                    sb.AppendLine($"{nombreCorte} cantidad: {producto.Value} KG precio: ${precio:0.00}");
                }

            }

            if (this._productos.Count > 0 && Credito)
            {
                sb.AppendLine($"5% de recargo: {(total * 0.05):0.00}");
            }


            return sb.ToString();
        }

        internal void AgregarProducto(SqlDataReader r)
        {
            int id = int.Parse(r["idCorte"]?.ToString());
            double cantidad = double.Parse(r["cantidadKilos"]?.ToString());
            this._productos.Add(id, cantidad);


        }
        public static explicit operator Factura(SqlDataReader r)
        {
            Factura f = new Factura(
                int.Parse(r["numeroFactura"]?.ToString()),
                bool.Parse(r["pagoConCredito"]?.ToString()),
                bool.Parse(r["vendido"]?.ToString()),
                int.Parse(r["dniCliente"]?.ToString()),
                r["nombreCompleto"]?.ToString()
                );
            return f;
        }
        public static explicit operator Factura(string linea)
        {
            string[] parametros = linea.Split(',');
            Dictionary<int,double> productos = parametros[5].Split(';')
                .Select(part => part.Split('='))
                .Where(part => part.Length == 2)
                .ToDictionary(sp => int.Parse(sp[0]), sp => double.Parse(sp[1]));

            return new Factura(
                int.Parse(parametros[0]),
                bool.Parse(parametros[1]),
                bool.Parse(parametros[2]),
                int.Parse(parametros[3]),
                parametros[4],
                productos
                );

        }

        public string EscribirTxt()
        {
            string strProductos = string.Join(';', Productos.Select(kv => kv.Key + "=" + kv.Value).ToArray()); 
            return $"{NumeroFactura},{Credito},{Vendido},{DniCliente},{NombreCliente},{strProductos}";
        }
        public string EscribirCamposTxt()
        {
            StringBuilder sb = new StringBuilder();
            return $"NumeroFactura,Credito,Vendido,DniCliente,NombreCliente,Productos";
        }
        private void ActualizarNumeroFacturaDeLaInstancia(int ultimoNumero)
        {
            if (!this.Vendido)
            {
                this._numeroFactura = ultimoNumero + 1;

            }
        }
        private void RefrescarNumero()
        {
            int numero = 0;
            while (true)
            {
                numero = ClaseDAO.FacturaDAO.GetUltimoNumeroFactura();

                if (_ultimoNumeroFactura != numero)
                {
                    _ultimoNumeroFactura = numero;
                    OnActualizarUltimoNumeroFactura?.Invoke(numero);
                }
                Thread.Sleep(1000);
            }
        }

        public static event ActualizarUltimoNumeroFactura OnActualizarUltimoNumeroFactura;
        //agregar evento para que actualizar la lista cada vez que se ejecute el metodo que
        //vendedor agregue un corte
        //no usar, se hizo un metodo que trae los cortes segun un array de id
        /*
        private static void CargarNombreProductos()
        {
            Task task = Task.Run(() =>
            {
                Dictionary<int, string> nombreProductos = new Dictionary<int, string>();
                List<Corte> listaCortes = ClaseDAO.CorteDAO.GetAll();

                foreach (var corte in listaCortes)
                {
                    nombreProductos.Add(corte.Id, corte.Nombre);
                }

                _nombreProductos = nombreProductos;
            });
            
        }

        internal static event ActualizarNombreProductos OnActualizarNombreProductos;*/
    }
}
