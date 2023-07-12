using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Excepciones
{
    public class BaseDeDatosExcepcion : Exception
    {
        public BaseDeDatosExcepcion()
        {
        }

        public BaseDeDatosExcepcion(string? message) : base(message)
        {
        }

        public BaseDeDatosExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
