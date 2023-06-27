using BibliotecaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Serializacion
{
    public class JSON<T> : Archivo, IArchivo<T> where T : class
    {
        protected override string Extension => ".json";
        public JSON() : base()
        {

        }
        private void Serializar(string ruta, List<T> contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                string json = JsonSerializer.Serialize(contenido);
                streamWriter.Write(json);
            }
        }
        public void Guardar(string ruta, List<T> contenido)
        {
            if (ValidarSiExisteElArchivo(ruta) && ValidarExtension(ruta))
            {
                Serializar(ruta, contenido);
            }

        }

        public void GuardarComo(string ruta, List<T> contenido)
        {
            if (ValidarExtension(ruta))
            {
                Serializar(ruta, contenido);
            }
        }

        public List<T> Leer(string ruta)
        {
            List<T> datos = new List<T>();

            if (ValidarSiExisteElArchivo(ruta) && ValidarExtension(ruta))
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    string json = streamReader.ReadToEnd();
                    datos = JsonSerializer.Deserialize<List<T>>(json);
                }
            }
            return datos;
        }

    }
}
