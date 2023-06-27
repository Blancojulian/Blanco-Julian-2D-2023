using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Excepciones
{
    internal class DineroInsufiente : Exception
    {
        public DineroInsufiente()
        {
        }

        public DineroInsufiente(string? message) : base(message)
        {
        }

        public DineroInsufiente(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
