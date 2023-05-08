using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class Cliente : Usuario
    {
        private double _dinero;
        private List<Compra> _compras;

        public Cliente(string nombre, string apellido, int dni, string mail, string contrasenia, double dinero) : base(nombre, apellido, dni, mail, contrasenia)
        {
            this._dinero = dinero;
            this._compras = new List<Compra>();
        }
        public Cliente(string nombre, string apellido, int dni, string mail, string contrasenia) : this(nombre, apellido, dni, mail, contrasenia, -1)
        {

        }
        public double Dinero
        {
            get => this._dinero;
            set
            {
                if(value > 0)
                {
                    this._dinero = value;
                }
            }
        }
        public List<Compra> Compras => this._compras;

        public override DataTable GenerarTablaDeInfomacion()
        {

            DataTable dt = Carniceria.Heladera.GenerarTablaDeProductos(Carniceria.Heladera.CortesDisponibles);
            
            return dt;
        }
        public override string MostrarNombreApellido()
        {
            return $"{Nombre} {Apellido}";
        }
        public bool RealizarCompra(Compra compra)
        {
            double total = compra.CalcularTotal();
            string msg = string.Empty;
            bool retorno = this - total;

            if (retorno)
            {
                compra.NombreCliente = this.MostrarNombreApellido();
                this._compras.Add(compra);
                retorno = true;
            }

            return retorno;
        }
        /*
        public bool RealizarCompra(Compra compra, out string strMensaje)
        {
            double total;
            string msg = string.Empty;
            bool retorno = compra.CalcularTotal(out total, out msg) && this - total;

            if (retorno)
            {
                this._compras.Add(compra);
                retorno = true;
            }
            else
            {
                msg = this - total ? msg : "No tiene dinero sufiente";
            }

            strMensaje = msg;

            return retorno;
        }*/
        public static void GastarDinero(Cliente cliente, double dinero)
        {
            cliente._dinero -= dinero;
        }
        //no me convence si no le puedo poner private al operator -
        public static bool operator -(Cliente cliente, double dinero)
        {
            return cliente is not null && cliente._dinero - dinero >= 0;
        }

    }
}
