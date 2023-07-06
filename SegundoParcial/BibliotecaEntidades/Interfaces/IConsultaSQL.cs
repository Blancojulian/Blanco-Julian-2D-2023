using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Interfaces
{
    public interface IConsultaSQL<T, R> where R : struct
    {
        public List<T> BuscarCoincidencias(string cadena, R filtro);
    }
}
