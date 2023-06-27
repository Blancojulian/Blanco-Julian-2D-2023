using BibliotecaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Serializacion
{
    //no funciona pide todas las constraints
    internal class Serializador<T> where T : class, ITrabajarConTxt, new()
    {
        //adento va a tener clases que se instancian para json, xml o txt individualmente
        // o ver si hacer todo por separado

        private static JSON<T> _json;
        private static XML<T> _xml;
        private static TXT<T> _txt;

        static Serializador()
        {
            _json = new JSON<T>();
            _xml = new XML<T>();
            _txt = new TXT<T>();

        }

        public static JSON<T> Json => _json;
        public static XML<T> Xml => _xml;
        public static TXT<T> Txt => _txt;

    }
}
