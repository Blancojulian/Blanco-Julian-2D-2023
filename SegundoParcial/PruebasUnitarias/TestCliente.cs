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
    public class TestCliente
    {
        private Cliente cliente;
        [TestInitialize]
        public void Setup()
        {
            cliente = new Cliente("Juan", "Doe", 1234, "juan@gmail.com", "0000", 100);
        }
        [TestMethod]
        public void Test_Cliente_GetProductos_CantidadMayorACero()
        {
            int notExpected = 0;
            int actual;
            List<Corte> lista = cliente.GetProductos();
            actual = lista.Count;

            Assert.AreNotEqual(notExpected, actual);
        }
        [TestMethod]
        public void Test_Cliente_RealizarCompra_DineroInsuficiente()
        {
            this.cliente.Dinero = 100;
            Factura factura = new Factura();
            List<Corte> lista = cliente.GetProductos();
            double cantidad = 1000d;
            Corte corte1 = new Corte(1, "prueba 1", 2000d, 400d, Categorias.Primera, "");
            Corte corte2 = new Corte(2, "prueba 2", 1000d, 400d, Categorias.Primera, "");
            factura.AgregarProducto(corte1, cantidad);
            factura.AgregarProducto(corte2, cantidad);

            Assert.ThrowsException<DineroExcepcion>(() => this.cliente.RealizarCompra(factura));
        }

        [TestMethod]
        public void Test_Cliente_MostrarNombreApellido()
        {
            string expected = $"{this.cliente.Nombre} {this.cliente.Apellido}";
            string actual = this.cliente.MostrarNombreApellido();

            Assert.AreEqual(expected, actual);
        }
    }
}
