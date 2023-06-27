using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Serializacion
{
    public class TXT<T> : Archivo, IArchivo<T> where T : ITrabajarConTxt
    {
        protected override string Extension => ".txt";


        private void Serializar(string ruta, List<T> contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                string txt = EscribirTXT(contenido);
                streamWriter.Write(txt);
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
            throw new NotImplementedException();
        }

        private string EscribirTXT(List<T> contenido)
        {
            StringBuilder sb = new StringBuilder();
            bool flagCampos = false;
            foreach (T t in contenido)
            {/*
                if (!flagCampos)
                {
                    sb.AppendLine(t.EscribirCamposTxt());
                    flagCampos = true;
                }*/
                sb.AppendLine(t.EscribirTxt());
            }

            return sb.ToString();
        }

        public List<Factura> LeerFacturaTXT(string ruta)
        {
            List<Factura> datos = new List<Factura>();

            if (ValidarSiExisteElArchivo(ruta) && ValidarExtension(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);
                foreach (string linea in lineas)
                {
                    datos.Add((Factura)linea);
                }
            }
            

            return datos;
        }

    }
}
