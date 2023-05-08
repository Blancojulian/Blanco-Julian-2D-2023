using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class DetalleCorte
    {
        private double _stockKilos;
        private double _precioKilo;
        private Categorias _categoria;
        private string _detalle;

        public DetalleCorte(double stockKilos, double precioKilo, Categorias categoria) : this(stockKilos, precioKilo, categoria, string.Empty)
        {
        }
        public DetalleCorte(double stockKilos, double precioKilo, Categorias categoria, string detalle)
        {
            this._stockKilos = stockKilos;
            this._precioKilo = precioKilo;
            this._categoria = categoria;
            this._detalle = detalle;
        }

        public double StockKilos
        {
            get => this._stockKilos;
            set
            {
                if (/*this._stockKilos - */value >= 0)
                {
                    this._stockKilos = value;
                }
            }
        }

        public double PrecioKilo
        { 
            get => this._precioKilo;
            set => this._precioKilo = value;
        }
        public Categorias Categoria
        {
            get => this._categoria;
            set => this._categoria = value;
        }
        public string Detalle
        {
            get => this._detalle;
            set => this._detalle = value;
        }
        //sacar prop Disponible, ya esta el operator -
        //dejar, se usapara controlar si hay stock
        public bool Disponible => this._stockKilos > 0;

        public static bool operator -(DetalleCorte c, double cantidadKilos)
        {
            return c is not null && c._stockKilos - cantidadKilos >= 0;
        }

     

        public double CalcularPrecio(double cantidadKilos)
        {
            return this._precioKilo * cantidadKilos;
        }
    }
}
