using System;
using System.Collections.Generic;
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
        private static void CargarDatos()
        {
            var usuarios = new List<Usuario>
            {
                new Cliente("Juan", "Doe", 1234, "juan@gmail.com", "0000", 10000),
                new Cliente("Esteban", "Algo", 2222, "esteban@gmail.com", "1111", 4000),
                new Vendedor("David", "Esteban", 3333, "david@gmail.com", "1111"),
                new Vendedor("Elsa", "Murai", 4444, "elsa@gmail.com", "1111"),
                new Vendedor("Esteban", "Quito", 4444, "esteban@gmail.com", "2222")

            };

            _usuarios = usuarios;
        }

        private static void CargarCompras()
        {
            
            Dictionary<string, double> productos = new Dictionary<string, double>();
            productos.Add("Bola de Lomo", 5);
            productos.Add("Aguja", 2);
            productos.Add("Vacio", 3);

            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente)
                {
                    ((Cliente)u).RealizarCompra(new Compra(productos, true));
                }
            }
        }
    }
}
