using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        /// <summary>
        /// Estado de la cuenta del alumno
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        #region Constructores
        /// <summary>
        /// Se inicializa los atributos del alumno por defecto
        /// </summary>
        public Alumno() : this(0, "defecto", "defecto", "10000000", ENacionalidad.Argentino, Universidad.EClases.Laboratorio, EEstadoCuenta.Deudor)
        { }
        /// <summary>
        /// Inicializa los atributos del alumno que son pasados por parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(Universitario.ETipo.Alumno, id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Inicializa los atributos del alumno que son pasados por parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Se modifica el método virtual MostrarDatos, heredado de la clase Universitario
        /// Método protegido que muestra los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            if (this._estadoCuenta == EEstadoCuenta.AlDia)
            { return string.Format(base.MostrarDatos() + "\r\n" + "Estado de cuenta: " + "Cuota al día" + "\r\n" + this.ParticiparEnClase() + "\r\n"); }
            return string.Format(base.MostrarDatos() + "\r\n" + "Estado de cuenta: " + this._estadoCuenta + "\r\n" + this.ParticiparEnClase() + "\r\n");
        }
        /// <summary>
        /// Se instancia el método abstract, heredado de la clase Universitario
        /// Método protegido que muestra las clase que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("Toma de clases de " + this._claseQueToma);
        }
        /// <summary>
        /// Método publico que llama al método MostrarDatos
        /// Muestra de forma publica todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Sobrecarga del operador "==", un alumno sera igual a una clase, si esta en ella y no es deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador "!=", niega lo que devuelve la sobrecarga del "=="
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a._claseQueToma == clase);
        }
        #endregion 







    }
}
