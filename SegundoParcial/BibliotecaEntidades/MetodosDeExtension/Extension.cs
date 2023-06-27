using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaEntidades.DAO;

namespace BibliotecaEntidades.MetodosDeExtension
{
    internal static class Extension
    {
        public static string PasarANumeroFactura(this int num)
        {
            return $"{num:00000000}";
        }


        public static bool EsCadenaVaciaOTieneEspacios(this string str)
        {
            return string.IsNullOrWhiteSpace(str) && string.IsNullOrEmpty(str);
        }
    }
}
