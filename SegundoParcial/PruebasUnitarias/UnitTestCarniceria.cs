using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Excepciones;
using BibliotecaEntidades.MetodosDeExtension;
using System.ComponentModel.DataAnnotations;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTestCarniceria
    {
        [TestMethod]
        public void Test_EsCadenaVaciaOTieneEspacios_CadenaConEspacios()
        {
            string cadena = "       ";

            bool retorno = cadena.EsCadenaVaciaOTieneEspacios();

            Assert.IsTrue(retorno);
        }
        [TestMethod]
        public void Test_EsCadenaVaciaOTieneEspacios_CadenaVacia()
        {
            string cadena = "";

            bool retorno = cadena.EsCadenaVaciaOTieneEspacios();

            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Test_EsCadenaVaciaOTieneEspacios_CadenaEsNull()
        {
            string cadena = null;

            bool retorno = cadena.EsCadenaVaciaOTieneEspacios();

            Assert.IsTrue(retorno);
        }
        [TestMethod]
        public void Test_Factura_AgregarProducto()
        {
            //Factura factura = new Factura(1, false, EstadoFactura.Pendiente, 1234, "nombre cliente");
            Factura factura = new Factura();
            
            bool retorno = factura.AgregarProducto(new Corte(1, "prueba1", 100d, 400d, Categorias.Primera, ""), 4);
            
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Test_Factura_AgregarProductoConIdDuplicado()
        {
            //Factura factura = new Factura(1, false, EstadoFactura.Pendiente, 1234, "nombre cliente");
            Factura factura = new Factura();
            int id = 1;
            Corte corte1 = new Corte(id, "prueba 2", 200d, 400d, Categorias.Primera, "");
            Corte corte2 = new Corte(id, "prueba 2", 100d, 400d, Categorias.Primera, "");
            factura.AgregarProducto(corte1, 4);
            
            Assert.ThrowsException<FacturaExcepcion>(() => factura.AgregarProducto(corte2, 4));
        }
        public void Test_Factura_AgregarProductoConStockInsuficiente()
        {
            Factura factura = new Factura();
            double stock = 1d;
            double stockSolicitado = 100d;

            Corte corte = new Corte(1, "prueba", stock, 400d, Categorias.Primera, "");

            Assert.ThrowsException<FacturaExcepcion>(() => factura.AgregarProducto(corte, stockSolicitado));
        }
        [TestMethod]
        public void Test_Factura_EliminarProductos()
        {
            int cantidadEsperada = 0;
            Factura factura = new Factura();
            factura.AgregarProducto(new Corte(1, "prueba1", 100d, 400d, Categorias.Primera, ""), 4);
            factura.AgregarProducto(new Corte(2, "prueba2", 100d, 650d, Categorias.Primera, ""), 6);

            factura.EliminarProducto();
            Console.WriteLine(factura.Productos.Count);
            Assert.AreEqual(factura.Productos.Count, cantidadEsperada);
        }

        
    }
}