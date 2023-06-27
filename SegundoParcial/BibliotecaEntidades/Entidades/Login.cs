using BibliotecaEntidades.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public static class Login
    {
        public static bool GetUsuario(Usuarios tipoDeUsuario, out string mail, out string contrasenia)
        {
            bool retorno = false;
            string strMail = string.Empty;
            string strContrasenia = string.Empty;
            Usuario? usuario = ClaseDAO.UsuarioDAO.Get(tipoDeUsuario);

            if (usuario is not null)
            {
                Usuario.DatosLogin(usuario, out strMail, out strContrasenia);
                retorno = true;
            }
            mail = strMail;
            contrasenia = strContrasenia;

            return retorno;
        }

        /// <summary>
        /// Comprueba que exista un usuario con el mail y contraseña ingresados y lo devuelve
        /// </summary>
        /// <param name="mail">mail del usuario buscado</param>
        /// <param name="contrasenia">contraseña del usuario buscado</param>
        /// <returns>Retorna un Usuario si hay una coincidencia o un nulo si no</returns>
        public static Usuario? GetUsuario(string mail, string contrasenia)
        {
            Usuario? usuario = null;
            Usuario? u = ClaseDAO.UsuarioDAO.Get(mail);

            if (u is not null && Usuario.DatosLogin(u, mail, contrasenia))
            {
                usuario = u;
            }


            return usuario;
        }
    }
}
