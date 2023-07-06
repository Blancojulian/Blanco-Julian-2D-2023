using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Excepciones
{
    public class ErrorOperacionVentaExcepcion : Exception
    {
        public ErrorOperacionVentaExcepcion()
        {
        }

        public ErrorOperacionVentaExcepcion(string? message) : base(message)
        {
        }

        public ErrorOperacionVentaExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ErrorOperacionVentaExcepcion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
