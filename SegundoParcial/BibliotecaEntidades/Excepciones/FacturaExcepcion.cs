using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Excepciones
{
    public class FacturaExcepcion : Exception
    {
        public FacturaExcepcion()
        {
        }

        public FacturaExcepcion(string? message) : base(message)
        {
        }

        public FacturaExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
