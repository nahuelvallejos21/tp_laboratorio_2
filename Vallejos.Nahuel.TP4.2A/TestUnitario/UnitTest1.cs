using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifica que la lista de paquetes este instanciada
        /// </summary>
        [TestMethod]
        public void ObjetoInstanciado()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);

        }
        /// <summary>
        /// Verifica que no se pueda agregar dos paquetes de mismo trackingID en la lista
        /// </summary>
        [TestMethod]
        public void IgualdadObjetos()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Av Corriente 321", "123-456-7891");
            Paquete p2 = new Paquete("Av Corriente 150", "123-456-7891");

            try
            {
                correo += p1;
                correo += p2;
                Assert.Fail("Deberia avisar que no se puede agregar 2 paquetes con misma TrackingID");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
                
            }
        }
    }
}
