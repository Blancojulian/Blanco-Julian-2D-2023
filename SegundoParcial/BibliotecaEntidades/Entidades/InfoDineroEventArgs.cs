using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class InfoDineroEventArgs : EventArgs
    {
        private double _dineroGastado;
        private double _dineroActual;

        public InfoDineroEventArgs(double dineroGastado, double dineroActual) : base()
        {
            this._dineroGastado = dineroGastado;
            this._dineroActual = dineroActual;
        }

        public double DineroGastado => this._dineroGastado;
        public double DineroActual => this._dineroActual;

    }
}
