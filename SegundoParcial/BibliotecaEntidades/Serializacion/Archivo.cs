using BibliotecaEntidades.Excepciones;
using BibliotecaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Serializacion
{
    public abstract class Archivo
    {
        protected static string defaultPath;
        protected abstract string Extension { get; }

        static Archivo()
        {
            defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        } 
        protected bool ValidarSiExisteElArchivo(string ruta)
        {
            if (!File.Exists(ruta))
            {
                throw new ArchivoIncorrectoExcepcion("El archivo no se encontró.");
            }

            return true;
        }

        protected bool ValidarExtension(string ruta)
        {
            if (Path.GetExtension(ruta) != Extension)
            {
                throw new ArchivoIncorrectoExcepcion($"El archivo no tiene la extensión {Extension}.");
            }

            return true;
        }

    }
}
