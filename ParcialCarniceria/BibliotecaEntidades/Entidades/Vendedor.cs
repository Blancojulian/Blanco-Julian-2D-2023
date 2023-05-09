using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class Vendedor : Usuario
    {
        public Vendedor(string nombre, string apellido, int dni, string mail, string contrasenia) : base(nombre, apellido, dni, mail, contrasenia)
        {
        }

        public bool RealizarVenta(Cliente cliente, Compra compra, out string strMensaje)
        {
            double total = compra.CalcularTotal();
            string msg = string.Empty;
            bool retorno = !compra.Vendido && Carniceria.Heladera.HayStockCorte(compra, out msg) && cliente - total;


            if (retorno)
            {
                Cliente.GastarDinero(cliente, total);
                compra.Vendido = true;
            }
            else if (compra.Vendido)
            {
                msg = "Venta ya realizada";
            }
            else
            {
                msg = cliente - total ? msg : "No tiene dinero sufiente";
            }

            strMensaje = msg;

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

        public bool AgregarCorte(string nombre, DetalleCorte detalleCorte)
        {
            return Carniceria.Heladera.AgregarCorte(nombre, detalleCorte);
        }

        public bool EliminarCorte(string nombre)
        {
            return Carniceria.Heladera.EliminarCorte(nombre);
        }

        public DetalleCorte? GetDetalleCorte(string corte)
        {
            return Carniceria.Heladera.GetDetalleCorte(corte);
        }
        public Cliente? GetUsuario(string mail)
        {
            return (Cliente?)Carniceria.GetUsuario(mail);
        }
        public List<Compra> GetCompras(EstadoVenta estado)
        {
            return Carniceria.GetCompras(estado);
        }
        public override DataTable GenerarTablaDeInfomacion()
        {
            List<Cliente> clientes = Carniceria.Clientes;
            DataTable dt = new DataTable();

            dt.Columns.Add("Nombre");
            dt.Columns.Add("Dinero");
            dt.Columns.Add("DNI");
            dt.Columns.Add("Mail");

            foreach (Cliente c in clientes)
            {
                dt.Rows.Add(c.MostrarNombreApellido(), c.Dinero, c.Dni, c.Mail);
            }

            return dt;
        }

        public override string MostrarNombreApellido()
        {
            return $"Vendedor: {Nombre} {Apellido}";
        }

        public DataTable GenerarTablaDeInfomacion(Filtros filtro)
        {
           return Carniceria.Heladera.GenerarTablaDeProductos(filtro);
        }


        //no usar
        //DetalleCorte detalle = Carniceria.Heladera.GetDetalleCorte(producto.Key);
        //ver si sacar el control de stock compra y hacer un metodo en heladera, para mantener la logica dentro de heladera
        /*
        public bool RealizarVenta(Cliente cliente, Compra compra)
        {
            bool retorno = false;
            double total;
            string msg = string.Empty;
            retorno = compra.CalcularTotal(out total, out msg) && cliente - total;

            if (retorno)
            {
                compra.Vendido = true;
            }
            else
            {
                msg = cliente - total ? msg : "No tiene dinero sufiente";
            }


            return retorno;
        }*/

        //no usar este RealizarVenta
        /*
        public bool RealizarVenta(Cliente cliente, DetalleCorte corte, double cantidad)
        {
            bool retorno = false;
            double precio = corte.CalcularPrecio(cantidad);

            if (corte - cantidad && cliente - precio)
            {
                Cliente.GastarDinero(cliente, precio);
                retorno = true;
            }

            return retorno;
        }*/
    }
}
