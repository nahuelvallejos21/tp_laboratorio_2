using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Archivos;
using Excepciones;
using Archivos;
namespace Test_Unitario
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// EL método verifica que el DNI coincida con la Nacionalidad
        /// Argentino -> 1 a 89999999
        /// Extranjero-> 90000000 a 99999999
        /// </summary>
        [TestMethod]
        public void NoCoincideNacionalidadConDNI()
        {
            try
            {
                Alumno a1 = new Alumno(2, "Nahuel", "Vallejos", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Assert.Fail("Deberia avisar que la nacionalidad no coincide con el DNI");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));

            }
        }
        /// <summary>
        /// Verifica que el DNI sea numerico, en caso de que no, se lanza un DniInvalidException
        /// </summary>
        [TestMethod]
        public void DniInvalido()
        {
            try
            {
                Alumno a1 = new Alumno(2, "Nahuel", "Vallejos", "0", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Assert.Fail("Deberia avisar que el DNI es inválido");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));

            }
        }
        /// <summary>
        /// Valida que el DNI se asignado correctamente al objeto Alumno
        /// </summary>
        [TestMethod]
        public void FueraDeRangoDNI()
        {
            Alumno alumnoCorrecto = new Alumno(21, "Laura", "Gonzales", "80000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.AreEqual(alumnoCorrecto.DNI, 80000000);
        }
        /// <summary>
        /// Verifica que la lista de Alumnos no sea null
        /// </summary>
        [TestMethod]
        public void ListaDeAlumnosCorrecta()
        {
            Profesor instructor = new Profesor();
            Jornada jornada = new Jornada(Universidad.EClases.SPD, instructor);
            Assert.IsNotNull(jornada.Alumno);
        }
        [TestMethod]
        public void NombreCorrecto()
        {


            Alumno alumno = new Alumno(21, "12000", "Gonzales", "80000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.AreNotEqual(alumno.Nombre, "12000");




        }
    }
}
