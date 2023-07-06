using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Excepciones
{
    public class VentaYaRealizada : Exception
    {
        public VentaYaRealizada()
        {
        }

        public VentaYaRealizada(string? message) : base(message)
        {
        }

        public VentaYaRealizada(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
