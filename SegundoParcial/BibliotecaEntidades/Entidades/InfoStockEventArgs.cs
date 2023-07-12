using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class InfoStockEventArgs : EventArgs
    {
        private string _nombreCorte;
        private double _stockRepuesto;

        public InfoStockEventArgs(string nombre, double stock) : base()
        {
            this._nombreCorte = nombre;
            this._stockRepuesto = stock;
        }

        public string NombreCorte => this._nombreCorte;
        public double StockRepuesto => this._stockRepuesto;
    }
}
