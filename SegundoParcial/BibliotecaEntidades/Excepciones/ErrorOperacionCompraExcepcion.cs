using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Excepciones
{
    public class ErrorOperacionCompraExcepcion : Exception
    {
        public ErrorOperacionCompraExcepcion()
        {
        }

        public ErrorOperacionCompraExcepcion(string? message) : base(message)
        {
        }

        public ErrorOperacionCompraExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
