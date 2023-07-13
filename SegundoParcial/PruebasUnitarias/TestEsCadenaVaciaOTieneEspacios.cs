using BibliotecaEntidades.MetodosDeExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestEsCadenaVaciaOTieneEspacios
    {
        [TestMethod]
        public void Test_EsCadenaVaciaOTieneEspacios_CadenaConEspacios()
        {
            string cadena = "       ";
            bool expected = true;
            bool actual = cadena.EsCadenaVaciaOTieneEspacios();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_EsCadenaVaciaOTieneEspacios_CadenaVacia()
        {
            string cadena = "";
            bool expected = true;
            bool actual = cadena.EsCadenaVaciaOTieneEspacios();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_EsCadenaVaciaOTieneEspacios_CadenaEsNull()
        {
            string cadena = null;
            bool expected = true;
            bool actual = cadena.EsCadenaVaciaOTieneEspacios();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_EsCadenaVaciaOTieneEspacios_CadenaConCaracteres()
        {
            string cadena = "   cadena   ";
            bool expected = false;
            bool actual = cadena.EsCadenaVaciaOTieneEspacios();

            Assert.AreEqual(expected, actual);
        }
    }
}
