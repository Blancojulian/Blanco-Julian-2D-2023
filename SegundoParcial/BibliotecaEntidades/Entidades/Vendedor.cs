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
    public delegate void NoficarVenta(InfoVentaEventArgs info);
    public delegate void NotificarStockCorte(InfoStockEventArgs info);
    public delegate void ErrorEnHilo(Exception ex);

    public class Vendedor : Usuario
    {
        public event NoficarVenta OnVentaRealizada;
        public event NotificarStockCorte OnReponerStock;
        public event ErrorEnHilo OnErrorEnHiloSecundario;

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
            
            try
            {
                if (cliente is null)
                {
                    throw new ErrorOperacionVendedorExcepcion($"Debe seleccionar un cliente");

                }

                if (factura.Estado == EstadoFactura.Vendido)
                {
                    throw new VentaYaRealizada("Venta ya realizada");
                }

                if (!(cliente - total))
                {
                    throw new DineroExcepcion("El cliente no tiene dinero sufiente");
                }

                factura.ValidarCarrito();
                HayStockCortes(factura);

                Cliente.GastarDinero(cliente, total);
                factura.Estado = EstadoFactura.Vendido;

                filas += ClaseDAO.UsuarioDAO.InsertOrUpdateDinero(cliente);
                filas += ClaseDAO.FacturaDAO.Update(factura.NumeroFactura, factura);

                OnVentaRealizada?.Invoke(new InfoVentaEventArgs(total, cliente.MostrarNombreApellido(), factura.NumeroFactura.PasarANumeroFactura()));
                
            }
            catch (ErrorOperacionVendedorExcepcion)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ErrorOperacionVendedorExcepcion("Error al realizar venta", ex);
            }
            return filas >= 2;
        }

        private static bool HayStockCortes(Factura factura)
        {
            bool retorno = true;
            Dictionary<int, FacturaItem> productos = factura.Productos;
            List<Corte> listaCortes;
            StringBuilder sb = new StringBuilder();

            if (productos.Count <= 0)
            {
                throw new ErrorOperacionVendedorExcepcion($"No se ingresaron productos al carrito");

            }

            listaCortes = ClaseDAO.CorteDAO.GetAll(productos.Keys.ToArray());

            sb.AppendLine("No hay stock de los siguientes cortes:");
            foreach (Corte corte in listaCortes)
            {
                if (!corte.Disponible)
                {
                    retorno = false;
                    sb.AppendLine($"-{corte.Nombre} ID:{corte.Id}");
                }
            }

            if (!retorno)
            {
                throw new ErrorOperacionVendedorExcepcion(sb.ToString());

            }

            return retorno;
        }

        public async Task ReponerStock(Corte corte, double stock)
        {
            
            try
            {
                
                if (corte is null)
                {
                    throw new ErrorOperacionVendedorExcepcion("Debe Selecionar un corte");
                }


                await Task.Run(() =>
                {
                    try
                    {
                        CorteDAO corteDAO = new CorteDAO();// instanciando otra CorteDAO ya no tira error porque son 2 conecciones distintas
                        
                        Thread.Sleep(3000);
                        corte.StockKilos += stock;
                        corteDAO.Update(corte.Id, corte);
                        OnReponerStock?.Invoke(new InfoStockEventArgs(corte.Nombre, stock));
                    }
                    catch (Exception ex)
                    {
                        OnErrorEnHiloSecundario?.Invoke(ex);

                    }
                });

            }
            catch (ErrorOperacionVendedorExcepcion)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ErrorOperacionVendedorExcepcion("Error al reponer stock", ex);
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
            if (ClaseDAO.CorteDAO.CorteTieneComprasAsociadas(idCorte))
            {
                throw new ErrorOperacionVendedorExcepcion("El producto tiene comprobantes asociados, no se puede eliminar");
            }
            return ClaseDAO.CorteDAO.Delete(idCorte);
        }

        public bool ExisteNombreCorte(string nombreCorte)
        {
            return ClaseDAO.CorteDAO.ExisteNombre(nombreCorte);
        }

        public Cliente? GetUsuario(string mail)
        {
            return (Cliente?)ClaseDAO.UsuarioDAO.Get(mail);
        }
        public List<Cliente> GetClientes()
        {
            return ClaseDAO.UsuarioDAO.GetAll<Cliente>();
        }
        public Corte? GetCorte(int idCorte)
        {
            return ClaseDAO.CorteDAO.Get(idCorte);
        }
        public Cliente? GetCliente(int dniCliente)
        {
            return (Cliente?)ClaseDAO.UsuarioDAO.Get(dniCliente);
        }
        public List<Factura> GetFacturas(EstadoVenta estado)
        {
            return ClaseDAO.FacturaDAO.GetAll(estado);
        }
        public List<Factura> GetFacturas(string cadena, EstadoVenta estado)
        {
            return ClaseDAO.FacturaDAO.BuscarCoincidencias(cadena, estado);
        }
        public List<Corte> GetProductos(Filtros filtro)
        {
            List<Corte> lista;

            switch (filtro)
            {
                case Filtros.Disponible:
                    lista = ClaseDAO.CorteDAO.GetAll(true);
                    break;
                case Filtros.No_Disponible:
                    lista = ClaseDAO.CorteDAO.GetAll(false);
                    break;
                case Filtros.Todos:
                    lista = ClaseDAO.CorteDAO.GetAll();
                    break;
                default:
                    throw new ErrorOperacionVendedorExcepcion("Error, debe seleccionar un filtro valido");
                    break;
            }
            return lista;
        }
        public List<Corte> GetProductos(string cadena, Filtros filtro)
        {
            return ClaseDAO.CorteDAO.BuscarCoincidencias(cadena, filtro);
        }
        public override List<Corte> GetProductos()
        {
            return ClaseDAO.CorteDAO.GetAll();
        }

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
