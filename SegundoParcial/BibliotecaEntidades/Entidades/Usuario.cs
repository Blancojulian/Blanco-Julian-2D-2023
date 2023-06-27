using BibliotecaEntidades.DAO;
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
    public abstract class Usuario
    {
        protected string _nombre;
        protected string _apellido;
        protected int _dni;
        protected string _mail;
        protected string _contrasenia;

        public Usuario(string nombre, string apellido, int dni, string mail, string contrasenia)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._dni = dni;
            this._mail = mail;
            this._contrasenia = contrasenia;
        }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Nombre { get => _nombre; set => _nombre = value; }
        /// <summary>
        /// Apellido del usuario
        /// </summary>
        public string Apellido { get => _apellido; set => _apellido = value; }
        /// <summary>
        /// DNI del usuario
        /// </summary>
        public int Dni { get => _dni; set => _dni = value; }
        /// <summary>
        /// Mail del usuario
        /// </summary>
        public string Mail { get => _mail; set => _mail = value; }
        /// <summary>
        /// Controla que el mail y contraseña ingresados coincidan con los del usuario
        /// </summary>
        /// <param name="usuario">el usuario con el que se comprueba la contraseña</param>
        /// <param name="mail">el mail del usuario a controlar</param>
        /// <param name="contrasenia">la contrasenia del usuario a controlar</param>
        /// <returns>Retorno true si coinciden y falso si no</returns>
        internal static bool DatosLogin(Usuario usuario, string mail, string contrasenia)
        {
            return usuario is not null && usuario._mail == mail && usuario._contrasenia == contrasenia;
        }
        /// <summary>
        /// Devuelve el mail y contraseña de un usuario
        /// </summary>
        /// <param name="usuario">Usuario del que se recupera el mail y contrasenia</param>
        /// <param name="mail">variable a la que se asigna el mail</param>
        /// <param name="contrasenia">variable a la que se asigna el mail</param>
        internal static void DatosLogin(Usuario usuario, out string mail, out string contrasenia)
        {
            mail = usuario._mail;
            contrasenia = usuario._contrasenia;

        }
        internal static string DatosLogin(Usuario usuario)
        {
            return usuario._contrasenia;

        }
        /// <summary>
        /// funcion abtracta que genera un DataTable con informacion
        /// </summary>
        /// <returns>Retorna un DataTable con la informacion generada</returns>

        //hacer una interfaz generica que diga que devuelve GenerarTablaDeInfomacion
        //public abstract DataTable GenerarTablaDeInfomacion();
        /// <summary>
        /// Genera un string con el nombre y apellido del usuario
        /// </summary>
        /// <returns> retorna un string con el nombre y apellido del usuario</returns>
        public abstract string MostrarNombreApellido();
        public abstract List<Corte> GetProductos();
        /// <summary>
        /// Controlar que coincidan el mail del usuario y el mail ingresado
        /// </summary>
        /// <param name="u">el usuario con el que se compara su mail con el ingresado</param>
        /// <param name="mail">el mail con el que se compara con el del usuario</param>
        /// <returns>Retorna true si coincidan el mail del usuario y el mail ingresado</returns>
        public static bool operator ==(Usuario u, string mail)
        {
            return u.Mail == mail;
        }
        public static bool operator !=(Usuario u, string mail)
        {
            return !(u.Mail == mail);
        }

        public static explicit operator Usuario?(SqlDataReader r)
        {
            Usuarios n = (Usuarios)Convert.ToInt32(r["idTipoUsuario"]);
            Usuario? usuario = null;
            switch (n)
            {
                case Usuarios.Vendedor:
                    usuario = (Vendedor)r;
                    break;
                case Usuarios.Cliente:
                    usuario = (Cliente)r;
                    break;

            }


            return usuario;
        } 
    }
}
