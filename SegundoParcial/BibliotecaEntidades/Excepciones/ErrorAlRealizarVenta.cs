using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Excepciones
{
    internal class ErrorAlRealizarVenta : Exception
    {
        public ErrorAlRealizarVenta()
        {
        }

        public ErrorAlRealizarVenta(string? message) : base(message)
        {
        }

        public ErrorAlRealizarVenta(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ErrorAlRealizarVenta(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
