using BibliotecaEntidades.DAO;
using BibliotecaEntidades.Excepciones;
using BibliotecaEntidades.Interfaces;
using BibliotecaEntidades.MetodosDeExtension;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public delegate void ActualizarUltimoNumeroFactura(int numero);
    //ver si crear clase abstracta Comprobante que herede Factura y una nueva clase OrdenDePago, esta va a
    // tener la task y evento que buscan el ultimo numero defactura
    //cliente va usar OrdenDePago y vendedor factura
    //ver bien como quedaria esto en la base de datos, si se puede agregar un campo que diga si es orden de pago
    //que el campo vendido indique si es Factura o orden
    //no, sigue estando el mismo problema que la orden actuliza el ultimo numero siempre
    //mejor hacer un atributo en Factura que diga si la ordenaron
    // o agregar el atributo que diga si la ordenaron orden de pago
    //mejor agregar atributo a Factura y dejarme de joder la vida
    // o agregar un campo en la base de datos que diga el estado y usuar un enum en la clase
    //IMPORTANTE ver si agregar un campo en db y clase que diga cuantos productos tiene, asi se sabe si tendria que tener productos
    public class Factura : ITrabajarConTxt
    {
        public event ActualizarUltimoNumeroFactura OnActualizarUltimoNumeroFactura;
        private Dictionary<int, FacturaItem> _productos;
        private int _dniCliente;
        private int _numeroFactura;
        private string? _nombreCliente;
        private bool _credito;
        private EstadoFactura _estadoFactura;
        private int _ultimoNumeroFactura;
        private Task _taskRefrescarNumero;

        

        private Factura(int numeroFactura, bool credito, EstadoFactura estado, int dniCliente, string nombreCliente, Dictionary<int, FacturaItem> productos)
        {
            this._productos = productos;
            this._numeroFactura = numeroFactura;
            this._estadoFactura = estado;
            this._credito = credito;
            this._dniCliente = dniCliente;
            this._nombreCliente = nombreCliente;

            this._ultimoNumeroFactura = 0;

            if (this._estadoFactura == EstadoFactura.Orden)
            {
                //this._ultimoNumeroFactura = ClaseDAO.FacturaDAO.GetUltimoNumeroFactura();
                OnActualizarUltimoNumeroFactura += ActualizarNumeroFacturaDeLaInstancia;
                this._taskRefrescarNumero = Task.Run(RefrescarNumero);
                //this._numeroFactura = _ultimoNumeroFactura + 1;
            }


        }
        public Factura(int numeroFactura, bool credito, EstadoFactura estado, int dniCliente, string nombreCliente) : this(numeroFactura, credito, estado, dniCliente, nombreCliente, new Dictionary<int, FacturaItem>())
        {

        }

        public Factura(bool credito, int dniCliente, string nombreCliente) : this(1, credito, EstadoFactura.Orden, dniCliente, nombreCliente)
        {

        }
        public Factura(int dniCliente, string nombreCliente) : this(1, false, EstadoFactura.Orden, dniCliente, nombreCliente)
        {

        }
        public Factura() : this(0, string.Empty)
        {

        }
        
        public bool Credito { get => this._credito; set => this._credito = value; }
        public int NumeroFactura { get => this._numeroFactura; set => this._numeroFactura = value; }
        public int DniCliente { get => this._dniCliente; set => this._dniCliente = value; }
        public string? NombreCliente { get => this._nombreCliente; set => this._nombreCliente = value; }
        public EstadoFactura Estado {
            get => this._estadoFactura;
            set//una vez que la factura tiene otro estado que sea orden, no se puede volver a orden
            {
                if (value != EstadoFactura.Orden)//cambiando de estado orden a otro
                {
                    OnActualizarUltimoNumeroFactura -= ActualizarNumeroFacturaDeLaInstancia;
                    this._estadoFactura = value;
                }
                else if (!(Estado != EstadoFactura.Orden && value == EstadoFactura.Orden))//se niega el cambio de cualquier otro estado que no sea orden a orden
                {
                    /*
                    this._ultimoNumeroFactura = ClaseDAO.FacturaDAO.GetUltimoNumeroFactura();
                    this._numeroFactura = _ultimoNumeroFactura + 1;
                    OnActualizarUltimoNumeroFactura += ActualizarNumeroFacturaDeLaInstancia;*/
                    this._estadoFactura = value;

                }

            }
        }
        //public MetodoPago MetodoPago { get => this._metodoPago; set => this._metodoPago = value; }
        [JsonIgnore]
        public string CreditoDebito => Credito ? "Credito" : "Debito";
        [JsonIgnore]
        public string DetalleProductos => this.GenerarDetalleProductos();
        [JsonIgnore]
        public double Total => this.CalcularTotal();
        public Dictionary<int, FacturaItem> Productos => new Dictionary<int, FacturaItem>(this._productos);

        public bool AgregarProducto(Corte corte, double cantidad)
        {
            ValidarCantidad(corte, cantidad);
            if (this._productos.ContainsKey(corte.Id))
            {
                throw new ErrorOperacionCompraExcepcion($"El producto {corte.Nombre} ya se esta en el carrito");
            }

            bool retorno = !this._productos.ContainsKey(corte.Id);
            FacturaItem item  = new FacturaItem(corte, cantidad);

            
            if (retorno)
            {
                this._productos.Add(item.IdCorte, item);
            }

            return retorno;
        }
        public bool ModificarProducto(Corte corte, double cantidad)
        {
            ValidarCantidad(corte, cantidad);
            if (!this._productos.ContainsKey(corte.Id))
            {
                throw new ErrorOperacionCompraExcepcion($"El producto {corte.Nombre} no se encuentra en el carrito");
            }

            bool retorno = this._productos.ContainsKey(corte.Id);

            if (retorno)
            {
                this._productos[corte.Id].CantidadKilos = cantidad;
            }

            return retorno;
        }
        public bool EliminarProducto(int idProducto)
        {
            if (!this._productos.ContainsKey(idProducto))
            {
                throw new ErrorOperacionCompraExcepcion($"El producto no se encuentra en el carrito");
            }
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
        //crear excepciones propias para estos errores como ErrorFacturaExcepcion
        private void ValidarCantidad(Corte corte, double cantidad)
        {
            if (corte is null)
            {
                throw new ErrorOperacionCompraExcepcion($"Debe seleccionar un producto");
            }
            if (corte.Id <= 0)
            {
                throw new ErrorOperacionCompraExcepcion($"El Id {corte.Id} no es valido");
            }
            if (!(corte - cantidad))
            {
                throw new ErrorOperacionCompraExcepcion($"Stock de {corte.Nombre} insuficiente");
            }
            if (cantidad <= 0d)
            {
                throw new ErrorOperacionCompraExcepcion($"La cantidad de {corte.Nombre} ingresada debe ser mayor a cero");
            }
        }

        public void ValidarCarrito()
        {
            if (this.Productos.Count <= 0)
            {
                throw new ErrorOperacionCompraExcepcion("Debe tener productos en el carrito para realizar la compra");
            }

            foreach (KeyValuePair<int, FacturaItem> p in this.Productos)
            {
                if (p.Value.CantidadKilos <= 0)
                {
                    throw new ErrorOperacionCompraExcepcion($"La cantidad de {p.Value.NombreCorte} debe ser mayor a cero");
                }
            }
        }

        private double CalcularTotal()
        {
            double precio;
            double total = 0d;
            
            foreach (KeyValuePair<int, FacturaItem> producto in this._productos)
            {
                total += producto.Value.PrecioProducto;
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

            foreach (KeyValuePair<int, FacturaItem> producto in this._productos)
            {
                
                if (producto.Value is not null)
                {
                    sb.AppendLine(producto.Value.ToString());
                }

            }

            if (this._productos.Count > 0 && Credito)
            {
                sb.AppendLine($"5% de recargo: {(this.Total * 0.05):0.00}");
            }


            return sb.ToString();
        }

        internal void AgregarProducto(SqlDataReader r)
        {
            int id = int.Parse(r["idCorte"]?.ToString());
            FacturaItem item = (FacturaItem)r;
            this._productos.Add(id, item);


        }
        public static explicit operator Factura(SqlDataReader r)
        {
            Factura f = new Factura(
                int.Parse(r["numeroFactura"]?.ToString()),
                bool.Parse(r["pagoConCredito"]?.ToString()),
                (EstadoFactura)int.Parse(r["idEstadoFactura"]?.ToString()),
                int.Parse(r["dniCliente"]?.ToString()),
                r["nombreCompleto"]?.ToString()
                );
            return f;
        }
        public static explicit operator Factura(string linea)
        {
            Regex rx = new Regex(@"^NumeroFactura:(\d+),Credito:(true|false),Estado:(Vendido|Pendiente),DniCliente:(\d+),NombreCliente:([a-zA-Z]+),Productos:(\[.*\])$");
            string[] parametros;
            string strProductos = "";
            if (!rx.IsMatch(linea))
            {
                throw new ArchivoIncorrectoExcepcion("ERROR, Formato incorrecto");
            }
            
            parametros = rx.Split(linea);
            strProductos = parametros[5];
            strProductos = strProductos.Replace("[","").Replace("]","");
            Dictionary<int,FacturaItem> productos = strProductos.Split(';')
                .Select(part => (FacturaItem)part)
                .ToDictionary(part => part.IdCorte, part => part);
            EstadoFactura estado = (EstadoFactura)Enum.Parse(typeof(EstadoFactura), parametros[2]);

            return new Factura(
                int.Parse(parametros[0]),
                bool.Parse(parametros[1]),
                estado,
                int.Parse(parametros[3]),
                parametros[4],
                productos
                ) ;

        }

        public string EscribirTxt()
        {
            string strProductos = string.Join(';', Productos.Select(kv => kv.Value.EscribirTxt()).ToArray());
            
            return $"{nameof(NumeroFactura)}:{NumeroFactura},{nameof(Credito)}:{Credito},{nameof(Estado)}:{Estado}," +
                $"{nameof(DniCliente)}:{DniCliente},{nameof(NombreCliente)}:{NombreCliente},{nameof(Productos)}:[{strProductos}]";
        }
        
        private void ActualizarNumeroFacturaDeLaInstancia(int ultimoNumero)
        {
            if (Estado == EstadoFactura.Orden)
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

    }
}
