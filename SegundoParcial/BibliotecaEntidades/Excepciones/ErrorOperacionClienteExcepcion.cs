using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Excepciones
{
    public class ErrorOperacionClienteExcepcion : Exception
    {
        public ErrorOperacionClienteExcepcion()
        {
        }

        public ErrorOperacionClienteExcepcion(string? message) : base(message)
        {
        }

        public ErrorOperacionClienteExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
