using BibliotecaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibliotecaEntidades.Serializacion
{
    public class XML<T> : Archivo, IArchivo<T> where T : class, new()
    {
        protected override string Extension => ".txt";


        private void Serializar(string ruta, List<T> contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                xmlSerializer.Serialize(streamWriter, contenido);
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
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    datos = xmlSerializer.Deserialize(streamReader) as List<T>;
                }
            }
            return datos;
        }
    }
}
