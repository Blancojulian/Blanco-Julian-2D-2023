using BibliotecaEntidades.DAO;
using BibliotecaEntidades.Excepciones;
using BibliotecaEntidades.MetodosDeExtension;
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
    public delegate void NoficarVenta(string mensaje);
    public delegate void NotificarStockCorte(Corte corte, double stockRepuesto);


    //invocar al evento estatico de OnActualizarNombreProductos de la clase Factura
    //para que refresque su lista de nombres de productos
    public class Vendedor : Usuario
    {

        public event NoficarVenta OnVentaRealizada;
        public event NotificarStockCorte OnReponerStock;
        private JSON<Corte> _serializadorProductosJson;
        private XML<Corte> _serializadorProductosXml;
        private TXT<Factura> _serializadorFacturasTxt;

        public Vendedor(string nombre, string apellido, int dni, string mail, string contrasenia) : base(nombre, apellido, dni, mail, contrasenia)
        {
            _serializadorProductosJson = new JSON<Corte>();
            _serializadorProductosXml = new XML<Corte>();
            _serializadorFacturasTxt = new TXT<Factura>();
        }

        public JSON<Corte> SerializadorProductosJson => _serializadorProductosJson;
        public XML<Corte> SerializadorProductosXml => _serializadorProductosXml;
        public TXT<Factura> SerializadorFacturasTxt => _serializadorFacturasTxt;

        public bool RealizarVenta(Cliente cliente, Factura factura)
        {
            double total = factura.Total;
            int filas = 0;

            if (factura.Vendido)
            {
                throw new VentaYaRealizada("Venta ya realizada");
            }

            if (!(cliente - total))
            {
                throw new DineroInsufiente("El cliente no tiene dinero sufiente");
            }

            HayStockCortes(factura);

            Cliente.GastarDinero(cliente, total);
            factura.Vendido = true;
            //ver si estoy modificando el dinero en update
            filas += ClaseDAO.UsuarioDAO.Update(cliente.Dni, cliente);
            filas += ClaseDAO.FacturaDAO.Update(factura.NumeroFactura, factura);

            OnVentaRealizada?.Invoke($"Venta realizada al cliente {factura.NombreCliente} " +
                $"comprobante {factura.NumeroFactura.PasarANumeroFactura()} Total {total}");

            return filas >= 2;
        }

        private static bool HayStockCortes(Factura factura)
        {
            bool retorno = true;
            Dictionary<int, double> productos = factura.Productos;
            List<Corte> listaCortes;

            if (productos.Count <= 0)
            {
                throw new ErrorAlRealizarVenta($"No se ingresaron productos al carrito");

            }

            listaCortes = ClaseDAO.CorteDAO.GetAll(productos.Keys.ToArray());

            foreach (Corte corte in listaCortes)
            {
                if (!corte.Disponible)
                {
                    retorno = false;
                    throw new ErrorAlRealizarVenta($"No hay stock de {corte.Nombre} ID:{corte.Id}");
                }
            }

            return retorno;
        }

        //hacer que simule un pedido de mercaderia y que avise cuando llegue con un evento
        public void ReponerStock(Corte corte, double stock)
        {

            if (corte is not null)
            {
                Task.Run(() =>
                {
                    corte.StockKilos += stock;
                    ClaseDAO.CorteDAO.Update(corte.Id, corte);
                    Thread.Sleep(3000);
                    OnReponerStock?.Invoke(corte, stock);
                });
            }

        }

        public int AgregarCorte(Corte corte)
        {
            return ClaseDAO.CorteDAO.Add(corte);
        }

        public int ModificarCorte(int idCorte, Corte corte)
        {
            return ClaseDAO.CorteDAO.Update(idCorte, corte);
        }

        public int EliminarCorte(int idCorte)
        {
            return ClaseDAO.CorteDAO.Delete(idCorte);
        }

        public Corte? GetDetalleCorte(int idCorte)
        {
            return ClaseDAO.CorteDAO.Get(idCorte);
        }
        public Cliente? GetUsuario(string mail)
        {
            return (Cliente?)ClaseDAO.UsuarioDAO.Get(mail);
        }
        public List<Cliente> GetClientes()
        {
            return ClaseDAO.UsuarioDAO.GetAll<Cliente>();
        }
        public List<Factura> GetFacturas(EstadoVenta estado)
        {
            return ClaseDAO.FacturaDAO.GetAll(estado);
        }
        public List<Corte> GetProductos(bool disponible)
        {
            return ClaseDAO.CorteDAO.GetAll(disponible);
        }
        public override List<Corte> GetProductos()
        {
            return ClaseDAO.CorteDAO.GetAll();
        }
        public int AgregarCliente(Cliente cliente)
        {
            return ClaseDAO.UsuarioDAO.Add(cliente);
        }

        //hacer una interfaz generica para GenerarTablaDeInfomacion
        /*
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

        

        public DataTable GenerarTablaDeInfomacion(Filtros filtro)
        {
            return Carniceria.Heladera.GenerarTablaDeProductos(filtro);
        }
        */

        public override string MostrarNombreApellido()
        {
            return $"Vendedor: {Nombre} {Apellido}";
        }

        public static explicit operator Vendedor?(SqlDataReader r)
        {
            return new Vendedor(
                r["nombre"].ToString() ?? "",
                r["apellido"].ToString() ?? "",
                Convert.ToInt32(r["dni"]),
                r["mail"].ToString() ?? "",
                r["contrasenia"].ToString() ?? ""
                );
        }




    }
}
