using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Excepciones
{
    public class DineroExcepcion : Exception
    {
        public DineroExcepcion()
        {
        }

        public DineroExcepcion(string? message) : base(message)
        {
        }

        public DineroExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
