using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Interfaces
{
    //esta mal, porque la voy a instanciar en la clase Serializador
    //ver, si cambiar la interfaz para que los metodos sean genericos y no la interfaz IArchivo<T>
    //ver si se puede poner una generico a la clase estatica Serialixador y pasarlo a las
    // que apliquen IArchivo<T>
    internal interface IArchivo<T>
    {
        void Guardar(string ruta, List<T> contenido);
        void GuardarComo(string ruta, List<T> contenido);
        List<T> Leer(string ruta);
    }
}
