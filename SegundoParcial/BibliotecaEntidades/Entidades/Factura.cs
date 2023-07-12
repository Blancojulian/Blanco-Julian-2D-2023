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
    public delegate void ActulizarDatosFactura(Factura factura);
    
    public class Factura : ITrabajarConTxt
    {
        private event ActualizarUltimoNumeroFactura OnActualizarUltimoNumeroFactura;
        public event ActulizarDatosFactura OnActulizarDatosFactura;

        private Dictionary<int, FacturaItem> _productos;
        private int _dniCliente;
        private int _numeroFactura;
        private string? _nombreCliente;
        private bool _credito;
        private EstadoFactura _estadoFactura;
        private int _ultimoNumeroFactura;
        private Task _taskRefrescarNumero;
        private CancellationTokenSource _cts;
        private CancellationToken _ct;

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
                this._cts = new CancellationTokenSource();
                this._ct = _cts.Token;
                OnActualizarUltimoNumeroFactura += ActualizarNumeroFacturaDeLaInstancia;
                this._taskRefrescarNumero = Task.Run(RefrescarNumero, this._cts.Token);
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
                if (Estado == EstadoFactura.Orden && value != EstadoFactura.Orden)//cambiando de estado orden a otro
                {
                    this._cts.Cancel();
                    OnActualizarUltimoNumeroFactura -= ActualizarNumeroFacturaDeLaInstancia;
                    this._estadoFactura = value;
                }
                else if (Estado != EstadoFactura.Orden && value != EstadoFactura.Orden)//cambiando de estado a cualquier otro que no sea Orden
                {
                    this._estadoFactura = value;

                }

            }
        }
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
                throw new FacturaExcepcion($"El producto {corte.Nombre} ya se esta en el carrito");
            }

            bool retorno = !this._productos.ContainsKey(corte.Id);
            FacturaItem item  = new FacturaItem(corte, cantidad);

            
            if (retorno)
            {
                this._productos.Add(item.IdCorte, item);
                OnActulizarDatosFactura?.Invoke(this);
            }

            return retorno;
        }
        public bool ModificarProducto(Corte corte, double cantidad)
        {
            ValidarCantidad(corte, cantidad);
            if (!this._productos.ContainsKey(corte.Id))
            {
                throw new FacturaExcepcion($"El producto {corte.Nombre} no se encuentra en el carrito");
            }

            bool retorno = this._productos.ContainsKey(corte.Id);

            if (retorno)
            {
                this._productos[corte.Id].CantidadKilos = cantidad;
                OnActulizarDatosFactura?.Invoke(this);
            }

            return retorno;
        }
        public bool EliminarProducto(int idProducto)
        {
            if (!this._productos.ContainsKey(idProducto))
            {
                throw new FacturaExcepcion($"El producto no se encuentra en el carrito");
            }
            bool retorno = this._productos.ContainsKey(idProducto);

            if (retorno)
            {
                this._productos.Remove(idProducto);
                OnActulizarDatosFactura?.Invoke(this);
            }

            return retorno;
        }
        public void EliminarProducto()
        {
            this._productos.Clear();
            OnActulizarDatosFactura?.Invoke(this);
        }
        private void ValidarCantidad(Corte corte, double cantidad)
        {
            if (corte is null)
            {
                throw new FacturaExcepcion($"Debe seleccionar un producto");
            }
            if (corte.Id <= 0)
            {
                throw new FacturaExcepcion($"El Id {corte.Id} no es valido");
            }
            if (!(corte - cantidad))
            {
                throw new FacturaExcepcion($"Stock de {corte.Nombre} insuficiente");
            }
            if (cantidad <= 0d)
            {
                throw new FacturaExcepcion($"La cantidad de {corte.Nombre} ingresada debe ser mayor a cero");
            }
        }

        public void ValidarCarrito()
        {//ver si cambiar a una nueva excepcion, FacturaExcepcion
            if (this.Productos.Count <= 0)
            {
                throw new FacturaExcepcion("Debe tener productos en el carrito para realizar la compra");
            }

            foreach (KeyValuePair<int, FacturaItem> p in this.Productos)
            {
                if (p.Value is null)
                {
                    throw new FacturaExcepcion($"Error, no se agrego datos del corte para el Id {p.Key}");

                }
                if (p.Value.CantidadKilos <= 0)
                {
                    throw new FacturaExcepcion($"La cantidad de {p.Value.NombreCorte} debe ser mayor a cero");
                }
            }
        }

        private double CalcularTotal()
        {
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
            Regex rx = new Regex(@"^NumeroFactura:(\d+),Credito:(True|False),Estado:(Vendido|Pendiente),DniCliente:(\d+),NombreCliente:([a-zA-Z\s]+),Productos:(\[.*\])$");
            string[] parametros;
            string strProductos = "";
            if (!rx.IsMatch(linea))
            {
                throw new ArchivoIncorrectoExcepcion("ERROR, Formato incorrecto");
            }
            
            parametros = rx.Split(linea);
            strProductos = parametros[6];
            strProductos = strProductos.Replace("[","").Replace("]","");

            Dictionary<int,FacturaItem> productos = strProductos.Split(';')
                .Select(part => (FacturaItem)part)
                .ToDictionary(part => part.IdCorte, part => part);
            EstadoFactura estado = (EstadoFactura)Enum.Parse(typeof(EstadoFactura), parametros[3]);

            return new Factura(
                int.Parse(parametros[1]),
                bool.Parse(parametros[2]),
                estado,
                int.Parse(parametros[4]),
                parametros[5],
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
                OnActulizarDatosFactura?.Invoke(this);

            }
        }
        private void RefrescarNumero()
        {
            try
            {
                this._ct.ThrowIfCancellationRequested();
                int numero = 0;
                while (true)
                {
                    if (this._ct.IsCancellationRequested)
                    {
                        this._ct.ThrowIfCancellationRequested();
                    }
                    //this.OnSolicitarUltimoNumeroFactura?.Invoke();
                    numero = ClaseDAO.FacturaDAO.GetUltimoNumeroFactura();

                    if (_ultimoNumeroFactura != numero)
                    {
                        _ultimoNumeroFactura = numero;
                        OnActualizarUltimoNumeroFactura?.Invoke(numero);
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (Exception)
            {

            }
            
        }
        

    }
}
