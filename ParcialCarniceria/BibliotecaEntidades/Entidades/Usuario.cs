using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{//haber metodo abstracto que devuelva informacion (dataTable o list) para pasarselo al datagridview
    public abstract class Usuario
    {//ver, si agergar metodo abtracti para getUsuario o getProducto
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

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public int Dni { get => _dni; set => _dni = value; }
        public string Mail { get => _mail; set => _mail = value; }

        public static bool DatosLogin(Usuario usuario, string mail, string contrasenia)
        {
            return usuario is not null && usuario._mail == mail && usuario._contrasenia == contrasenia;
        }

        public static void DatosLogin(Usuario usuario, out string mail, out string contrasenia)
        {
            mail = usuario._mail;
            contrasenia = usuario._contrasenia;
            
        }

        public abstract DataTable GenerarTablaDeInfomacion();
        public abstract string MostrarNombreApellido();

        public static bool operator ==(Usuario u, string mail)
        {
            return u.Mail == mail;
        }
        public static bool operator !=(Usuario u, string mail)
        {
            return !(u.Mail == mail);
        }
    }
}
