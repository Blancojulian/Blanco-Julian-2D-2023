using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Excepciones
{
    public class ErrorOperacionVendedorExcepcion : Exception
    {
        public ErrorOperacionVendedorExcepcion()
        {
        }

        public ErrorOperacionVendedorExcepcion(string? message) : base(message)
        {
        }

        public ErrorOperacionVendedorExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ErrorOperacionVendedorExcepcion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
