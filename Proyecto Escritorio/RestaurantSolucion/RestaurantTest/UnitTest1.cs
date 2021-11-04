using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Restaurant.Negocios;

namespace RestaurantTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLeer()
        {
            string esperado = "felipe";
            string resultado = string.Empty;
            Usuario us = new Usuario()
            {
                Rut = "199056492"
            };
            us.Read();
            resultado = us.Nombre;
            Assert.AreEqual(esperado, resultado);
        }
    }
}
