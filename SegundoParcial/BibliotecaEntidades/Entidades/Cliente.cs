using BibliotecaEntidades.DAO;
using BibliotecaEntidades.Excepciones;
using BibliotecaEntidades.Serializacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class Cliente : Usuario
    {
        public delegate void GastarDineroCliente(InfoDineroEventArgs infoDinero);
        public delegate void ActualizarDinero(double dineroActual);
        public event GastarDineroCliente OnGastarDinero;
        public event ActualizarDinero OnActualizarDinero;
        private double _dinero;

        public Cliente(string nombre, string apellido, int dni, string mail, string contrasenia, double dinero) : base(nombre, apellido, dni, mail, contrasenia)
        {
            this._dinero = dinero;
        }
        public Cliente(string nombre, string apellido, int dni, string mail, string contrasenia) : this(nombre, apellido, dni, mail, contrasenia, 0)
        {

        }
        public double Dinero
        {
            get => this._dinero;
            set
            {
                if (value > 0)
                {
                    this._dinero = value;
                    OnActualizarDinero?.Invoke(value);
                }
            }
        }

        public void ActulizarDinero(double monto)
        {
            if(monto <= 0d)
            {
                throw new DineroExcepcion("Debe ingresar un monto mayor a cero");
            }

            this.Dinero = monto;
            ClaseDAO.UsuarioDAO.InsertOrUpdateDinero(this);
        }
        public override string MostrarNombreApellido()
        {
            return $"{Nombre} {Apellido}";
        }
        public override List<Corte> GetProductos()
        {
            return ClaseDAO.CorteDAO.GetAll(true);
        }

        
        public bool RealizarCompra(Factura factura)
        {
            double total = factura.Total;
            int filas = 0;
            

            if (!(this - total))
            {
                throw new DineroExcepcion($"Dinero insuficiente, le falta {total - this._dinero}");
            }
            
            factura.NombreCliente = this.MostrarNombreApellido();
            factura.DniCliente = this.Dni;
            factura.Estado = EstadoFactura.Pendiente;
            filas = ClaseDAO.FacturaDAO.Add(factura);
            

            return filas > 0;
        }


        public static void GastarDinero(Cliente cliente, double dinero)
        {
            if (!(cliente - dinero))
            {
                throw new DineroExcepcion($"El cliente {cliente.MostrarNombreApellido()} no tiene " +
                    $"dinero suficiente para realizar la operación, le falta {dinero - cliente._dinero}");

            }
            cliente._dinero -= dinero;
            //ver si usa ActulizarDinero, pero no acepta valores menores a cero
            ClaseDAO.UsuarioDAO.InsertOrUpdateDinero(cliente);
            cliente.OnGastarDinero?.Invoke(new InfoDineroEventArgs(dinero, cliente._dinero));

        }

        public static bool operator -(Cliente cliente, double dinero)
        {
            return cliente is not null && cliente._dinero - dinero >= 0;
        }

        public static explicit operator Cliente?(SqlDataReader r)
        {
            Cliente c;
            
            double monto = r["monto"] is DBNull ? 0d : double.Parse(Convert.ToString(r["monto"]));
            c = new Cliente(
                r["nombre"]?.ToString() ?? "",
                r["apellido"]?.ToString() ?? "",
                Convert.ToInt32(r["dni"]),
                r["mail"]?.ToString() ?? "",
                r["contrasenia"]?.ToString() ?? "",
                monto
                );

            return c;
        }
    }
}
