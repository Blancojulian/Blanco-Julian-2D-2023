using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Excepciones
{
    public class ArchivoIncorrectoExcepcion : Exception
    {
        public ArchivoIncorrectoExcepcion()
        {
        }

        public ArchivoIncorrectoExcepcion(string? message) : base(message)
        {
        }

        public ArchivoIncorrectoExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
