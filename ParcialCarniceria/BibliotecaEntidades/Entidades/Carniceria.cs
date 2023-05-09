using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public static class Carniceria
    {
        private static List<Usuario> _usuarios;
        private static Heladera _heladera;

        static Carniceria()
        {
            _usuarios = new List<Usuario>();
            _heladera = new Heladera();
            CargarDatos();
            CargarCompras();
        }
        public static List<Cliente> Clientes
        {
            get
            {
                List<Cliente> clientes = new List<Cliente>();

                foreach (Usuario u in _usuarios)
                {
                    if (u is Cliente)
                    {
                        clientes.Add((Cliente)u);
                    }
                }

                return clientes;
            }
        }

        public static Heladera Heladera => _heladera;

        public static Usuario? GetUsuario(string mail, string contrasenia)
        {
            Usuario? usuario = null;

            foreach (Usuario u in _usuarios)
            {
                if (Usuario.DatosLogin(u, mail, contrasenia))
                {
                    usuario = u;
                    break;
                }
            }

            return usuario;
        }
        public static Usuario? GetUsuario(string mail)
        {
            Usuario? usuario = null;

            foreach (Usuario u in _usuarios)
            {
                if (u == mail)
                {
                    usuario = u;
                    break;
                }
            }

            return usuario;
        }
        //public por ahora
        private static Usuario? GetUsuario(Usuarios tipoDeUsuario)
        {
            Usuario? usuario = null;

            foreach (Usuario u in _usuarios)
            {
                if (tipoDeUsuario == Usuarios.Cliente && u is Cliente)
                {
                    usuario = u;
                    break;
                }
                else if (tipoDeUsuario == Usuarios.Vendedor && u is Vendedor)
                {
                    usuario = u;
                    break;
                }
            }

            return usuario;
        }

        public static bool GetUsuario(Usuarios tipoDeUsuario, out string mail, out string contrasenia)
        {
            bool retorno = false;
            string strMail = string.Empty;
            string strContrasenia = string.Empty;
            Usuario? usuario = GetUsuario(tipoDeUsuario);

            if (usuario is not null)
            {
                Usuario.DatosLogin(usuario, out strMail, out strContrasenia);
                retorno = true;
            }
            mail = strMail;
            contrasenia = strContrasenia;

            return retorno;
        }

        public static List<Compra> GetCompras()
        {
            List<Compra> compras = new List<Compra>();
            Cliente cliente;
            foreach (Usuario u in _usuarios)
            {
                if (u is not null && u is Cliente)
                {
                    cliente = (Cliente)u;
                    compras.AddRange(cliente.Compras);
                }
            }

            return compras;
        }
        public static List<Compra> GetCompras(EstadoVenta estado)
        {
            List<Compra> compras;

            switch (estado)
            {
                case EstadoVenta.Realizada:
                    compras = FiltarCompras(true);
                    break;
                case EstadoVenta.En_Proceso:
                    compras = FiltarCompras(false);

                    break;
                case EstadoVenta.Todas:
                    compras = GetCompras();

                    break;
                default:
                    compras = new List<Compra>();
                    break;
            }

            return compras;
        }

        

        public static List<Compra> GetCompras(string mail)
        {
            List<Compra> compras = new List<Compra>();
            Usuario? usuario = GetUsuario(mail);
            
            if (usuario is not null && usuario is Cliente && usuario == mail)
            {
                compras = ((Cliente)usuario).Compras;
            }

            return compras;
        }
        public static List<Compra> FiltarCompras(bool realizada)
        {
            List<Compra> compras = new List<Compra>();
            Cliente cliente;
            foreach (Usuario u in _usuarios)
            {
                if (u is not null && u is Cliente)
                {
                    cliente = (Cliente)u;
                    foreach (Compra compra in cliente.Compras)
                    {
                        if (compra.Vendido == realizada)
                        {
                            compras.Add(compra);
                        }
                    }
                }
            }

            return compras;
        }
        private static void CargarDatos()
        {
            var usuarios = new List<Usuario>
            {
                new Cliente("Juan", "Doe", 1234, "juan@gmail.com", "0000", 10000),
                new Cliente("Esteban", "Algo", 2222, "esteban@gmail.com", "1111", 5000),
                new Cliente("Enzo", "Fernandez", 2222, "enzo@gmail.com", "1111", 20000),
                new Vendedor("David", "Esteban", 3333, "david@gmail.com", "1111"),
                new Vendedor("Elsa", "Murai", 4444, "elsa@gmail.com", "1111"),
                new Vendedor("Esteban", "Quito", 4444, "esteban@gmail.com", "2222")

            };

            _usuarios = usuarios;
        }
        /// <summary>
        /// 
        /// </summary>
        private static void CargarCompras()
        {
            Cliente cliente;

            Compra c1;
            Compra c2;
            Compra c3;
            Compra c4;


            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente)
                {
                    c1 = new Compra();
                    c2 = new Compra();
                    c3 = new Compra(true);
                    c4 = new Compra(true);


                    c1.AgregarProducto("Bola de Lomo", 1d);
                    c1.AgregarProducto("Aguja", 2d);
                    c1.AgregarProducto("Vacio", 1d);

                    c2.AgregarProducto("Matambre", 3d);
                    c2.AgregarProducto("Falda", 1d);

                    c3.AgregarProducto("Bola de Lomo", 1d);
                    c3.AgregarProducto("Falda", 1d);
                    c3.AgregarProducto("Cuadril", 1d);
                    c3.AgregarProducto("Lomo", 1d);
                    c3.AgregarProducto("Vacio", 1d);

                    c4.AgregarProducto("Vacio", 2d);

                    cliente = (Cliente)u;
                    cliente.RealizarCompra(c1);
                    cliente.RealizarCompra(c2);
                    cliente.RealizarCompra(c3);
                    cliente.RealizarCompra(c4);

                }
            }
        }
    }
}
