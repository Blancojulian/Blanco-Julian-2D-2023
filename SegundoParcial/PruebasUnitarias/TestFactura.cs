using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Excepciones;
using BibliotecaEntidades.MetodosDeExtension;
using System.ComponentModel.DataAnnotations;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestFactura
    {
        
        [TestMethod]
        public void Test_Factura_AgregarProducto()
        {
            //Factura factura = new Factura(1, false, EstadoFactura.Pendiente, 1234, "nombre cliente");
            Factura factura = new Factura();
            bool expected = true;
            bool actual = factura.AgregarProducto(new Corte(1, "prueba1", 100d, 400d, Categorias.Primera, ""), 4);
            
            Assert.AreEqual(expected, actual);
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
        [TestMethod]
        public void Test_Factura_AgregarProductoConStockInsuficiente()
        {
            Factura factura = new Factura();
            double stock = 1d;
            double stockSolicitado = 100d;

            Corte corte = new Corte(1, "prueba", stock, 400d, Categorias.Primera, "");

            Assert.ThrowsException<FacturaExcepcion>(() => factura.AgregarProducto(corte, stockSolicitado));
        }
        [TestMethod]
        public void Test_Factura_AgregarProductoConIdInvalido_CeroOMenor()
        {
            Factura factura = new Factura();
            int idInvalido = 0;
            Corte corte = new Corte(idInvalido, "prueba 2", 200d, 400d, Categorias.Primera, "");
           

            Assert.ThrowsException<FacturaExcepcion>(() => factura.AgregarProducto(corte, 4));
        }
        [TestMethod]
        public void Test_Factura_EliminarProductos()
        {
            int expected = 0;
            int actual;
            Factura factura = new Factura();
            factura.AgregarProducto(new Corte(1, "prueba1", 100d, 400d, Categorias.Primera, ""), 4);
            factura.AgregarProducto(new Corte(2, "prueba2", 100d, 650d, Categorias.Primera, ""), 6);

            factura.EliminarProducto();
            actual = factura.Productos.Count;
            Assert.AreEqual(expected, actual);
        }

        
    }
}