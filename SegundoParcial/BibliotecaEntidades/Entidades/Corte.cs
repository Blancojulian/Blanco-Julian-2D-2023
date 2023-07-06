using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class Corte
    {
        private int _id;
        private string _nombre;
        private double _stockKilos;
        private double _precioKilo;
        private Categorias _categoria;
        private string _detalle;

        public Corte(string nombre, double stockKilos, double precioKilo, Categorias categoria) : this(nombre, stockKilos, precioKilo, categoria, string.Empty)
        {
        }
        public Corte(string nombre, double stockKilos, double precioKilo, Categorias categoria, string detalle) : this(0, nombre, stockKilos, precioKilo, categoria, detalle)
        {

        }
        public Corte(int id, string nombre, double stockKilos, double precioKilo, Categorias categoria, string detalle)
        {
            this._id = id;
            this._nombre = nombre;
            this._stockKilos = stockKilos;
            this._precioKilo = precioKilo;
            this._categoria = categoria;
            this._detalle = detalle;
        }

        public Corte()
        {

        }
        public int Id => this._id;
        public string Nombre
        {
            get => this._nombre;
            set => this._nombre = value;
        }
        public double StockKilos
        {
            get => this._stockKilos;
            set
            {
                if (value >= 0)
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
        public bool Disponible => this._stockKilos > 0;

        public static bool operator -(Corte c, double cantidadKilos)
        {
            return c is not null && c._stockKilos - cantidadKilos >= 0;
        }/*
        public static bool operator ==(Corte c, string strFiltro)
        {
            strFiltro = strFiltro.Trim().ToLower();
            return c is not null && ( c._nombre.ToLower().Contains(strFiltro) ||
                (c._detalle is not null && c._detalle.ToLower().Contains(strFiltro)) ||
                c._categoria.ToString().ToLower().Contains(strFiltro) ||
                c._id.ToString().ToLower().Contains(strFiltro) );
        }
        public static bool operator !=(Corte c, string strFiltro)
        {
            return !(c == strFiltro);
        }*/

        public static explicit operator Corte(SqlDataReader r)
        {
            Corte c = new Corte(
                Convert.ToInt32(r["id"]),
                r["nombre"].ToString() ?? "",
                Convert.ToDouble(r["stockKilos"]),
                Convert.ToDouble(r["precioKilo"]),
                (Categorias)Convert.ToInt32(r["idCategoria"]),
                r["detalle"].ToString() ?? ""
                );

            return c;
        }


        public double CalcularPrecio(double cantidadKilos)
        {
            return this._precioKilo * cantidadKilos;
        }
    }
}
