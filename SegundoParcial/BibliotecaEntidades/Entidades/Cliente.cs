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
                }
            }
        }

        //hay que hacer una interfaz
        /*
        public override DataTable GenerarTablaDeInfomacion()
        {

            DataTable dt = Carniceria.Heladera.GenerarTablaDeProductos(Carniceria.Heladera.CortesDisponibles);

            return dt;
        }*/
        public void ActulizarDinero(double monto)
        {
            if(monto <= 0d)
            {
                throw new DineroExcepcion("Debe ingresar un monto mayor a cero");
            }

            this.Dinero = monto;
            ClaseDAO.UsuarioDAO.Update(this.Dni, this);
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
            bool retorno = this - total;

            if (retorno)
            {
                factura.NombreCliente = this.MostrarNombreApellido();
                factura.DniCliente = this.Dni;
                factura.Estado = EstadoFactura.Pendiente;
                ClaseDAO.FacturaDAO.Add(factura);
            }

            return retorno && filas > 0;
        }


        public static void GastarDinero(Cliente cliente, double dinero)
        {
            cliente._dinero -= dinero;
        }

        public static bool operator -(Cliente cliente, double dinero)
        {
            return cliente is not null && cliente._dinero - dinero >= 0;
        }




        //ver si no trae problemas r["dinero"] cuando no se trae en la consulta
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
