using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Excepciones;
using BibliotecaEntidades.Serializacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestJSON
    {
        private List<Corte> listaCortes;
        private string rutaValida;


        [TestInitialize]
        public void Setup()
        {
            rutaValida = @"D:\UTN Terciario\Programacion 2 D2\Documento sp labo 2\lista productos json.json";

            listaCortes = new List<Corte>
            {
                new Corte(1, "Roast Beef", 100d, 1000d, Categorias.Primera, ""),
                new Corte(1, "Aguja", 100d, 700d, Categorias.Segunda, ""),
                new Corte(1, "Tortuguita", 100d, 400d, Categorias.Tercera, ""),
                new Corte(1, "Matambre", 100d, 900d, Categorias.Primera, "")
            };
        }
        [TestMethod]
        public void Test_JSON_Guardar_ValidarSiExisteElArchivo_RutaInvalida()
        {
            JSON<Corte> json = new JSON<Corte>();

            string ruta = "ruta invalida";
            Assert.ThrowsException<ArchivoIncorrectoExcepcion>(() => json.Guardar(ruta, listaCortes));
        }
        
        [TestMethod]
        public void Test_JSON_Guardar_ValidarExtension_ExtensionInvalida()
        {
            JSON<Corte> json = new JSON<Corte>();

            string rutaInvalida = @"D:\UTN Terciario\Programacion 2 D2\Documento sp labo 2\lista productos json.xml";
            Assert.ThrowsException<ArchivoIncorrectoExcepcion>(() => json.Guardar(rutaInvalida, listaCortes));
        }
        [TestMethod]
        public void Test_JSON_Guardar_ArchivoNoExiste()
        {
            JSON<Corte> json = new JSON<Corte>();

            string ruta = @"D:\UTN Terciario\Programacion 2 D2\Documento sp labo 2\lista productos json no existe.json";
            Assert.ThrowsException<ArchivoIncorrectoExcepcion>(() => json.Guardar(ruta, listaCortes));
        }

        public void Test_JSON_Leer_DeserializarConExito_CantidadMayorACero()
        {
            JSON<Corte> json = new JSON<Corte>();
            List<Corte> lista = new List<Corte>();
            int notExpected = 0;
            int actual;
            string ruta = @"D:\UTN Terciario\Programacion 2 D2\Documento sp labo 2\lista productos json no existe.json";
            //Assert.ThrowsException<ArchivoIncorrectoExcepcion>(() => json.GuardarComo(ruta, listaCortes));
            lista = json.Leer(this.rutaValida);
            actual = lista.Count;
            Assert.AreNotEqual(notExpected, actual);
        }
    }
}
