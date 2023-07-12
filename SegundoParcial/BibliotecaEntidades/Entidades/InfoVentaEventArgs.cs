using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class InfoVentaEventArgs
    {
        private double _total;
        private string _numeroFactura;
        private string _nombreCliente;

        public InfoVentaEventArgs(double total, string numeroFactura, string nombreCliente)
        {
            _total = total;
            _numeroFactura = numeroFactura;
            _nombreCliente = nombreCliente;
        }

        public double Total => this._total;
        public string NumeroFactura => this._numeroFactura;
        public string NombreCliente => this._nombreCliente;

    }
}
