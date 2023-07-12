using BibliotecaEntidades.Excepciones;
using BibliotecaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class FacturaItem : ITrabajarConTxt
    {
        private int _idCorte;
        private string _nombreCorte;
        private double _cantidadKilos;
        private double _precioKiloCorte;

        public FacturaItem(int idCorte, string nombreCorte, double cantidadKilos, double precioKiloCorte)
        {
            _idCorte = idCorte;
            _nombreCorte = nombreCorte;
            _cantidadKilos = cantidadKilos;
            _precioKiloCorte = precioKiloCorte;
        }
        public FacturaItem(Corte corte, double cantidadKilos) : this(corte.Id, corte.Nombre, cantidadKilos, corte.PrecioKilo)
        {

        }

        public int IdCorte => _idCorte;
        public string NombreCorte => _nombreCorte;
        public double CantidadKilos
        {
            get => _cantidadKilos;
            set
            {
                if (value > 0)
                {
                    this._cantidadKilos = value;
                }
            }
        }
        public double PrecioKiloCorte
        {
            get => _precioKiloCorte;
            set
            {
                if (value > 0)
                {
                    this._precioKiloCorte = value;
                }
            }
        }
        public double PrecioProducto => this._precioKiloCorte * this._cantidadKilos;
        public string EscribirTxt()
        {
            return $"{nameof(IdCorte)}:{IdCorte},{nameof(NombreCorte)}:{NombreCorte}," +
                $"{nameof(CantidadKilos)}:{CantidadKilos},{nameof(PrecioKiloCorte)}:{PrecioKiloCorte}," +
                $"{nameof(PrecioProducto)}:{PrecioProducto}";
        }

        public override string ToString()
        {
            return $"{this.NombreCorte} cantidad: {this.CantidadKilos} precio por kilo: ${this.PrecioKiloCorte:0.00} precio: ${this.PrecioProducto:0.00}";
        }

        public static explicit operator FacturaItem(string linea)
        {
            Regex rx = new Regex(@"^IdCorte:(\d+),NombreCorte:([a-zA-Z\s]+),CantidadKilos:([0-9]*\.{0,1}[0-9]*),PrecioKiloCorte:([0-9]*\.{0,1}[0-9]*),PrecioProducto:([0-9]*\.{0,1}[0-9]*)$");
            string[] parametros;
            if (!rx.IsMatch(linea))
            {
                throw new ArchivoIncorrectoExcepcion("ERROR, Formato incorrecto");
            }
            parametros = rx.Split(linea);
            
            return new FacturaItem(
                int.Parse(parametros[1]),
                parametros[2],
                double.Parse(parametros[3]),
                double.Parse(parametros[4])
                );
        }


        public static explicit operator FacturaItem(SqlDataReader r)
        {
            return new FacturaItem(
                int.Parse(r["idCorte"]?.ToString()),
                r["nombre"].ToString() ?? "",
                double.Parse(r["cantidadKilos"]?.ToString()),
                double.Parse(r["precioKiloCorte"]?.ToString()) 
                );
        }
    }
}
