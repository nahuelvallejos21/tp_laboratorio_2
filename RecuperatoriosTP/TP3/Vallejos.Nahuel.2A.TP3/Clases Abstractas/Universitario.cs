using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;
        private ETipo _tipo;

        /// <summary>
        /// Tipo de universitario
        /// </summary>
        public enum ETipo
        {
            Profesor, Alumno
        }

        #region Constructores
        /// <summary>
        /// Instancia todos los atributos por defecto
        /// </summary>
        public Universitario() : base()
        {
            this._legajo = 0;
            this._tipo = ETipo.Alumno;
        }
        /// <summary>
        /// Instancia todos los atributos que son pasados por parametros
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(ETipo tipo, int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
            this._tipo = tipo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Un universitario sera igual a otro si son del mismo tipo y su legajo o su DNI son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if ((object)pg1 != null && (object)pg2 != null)
            {
                if (pg1._tipo == pg2._tipo && (pg1._legajo == pg2._legajo || pg1.DNI == pg2.DNI))
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Niega lo que devuelve la sobrecarga del "=="
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// Sobreescritura del Equals(), llamando a la sobrecarga del "=="
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                return this == (Universitario)obj;
            }
            return false;
        }
        /// <summary>
        /// Firma del método abstract, no instanciado
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Método virtual que retornara un string con los atributos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            return string.Format(base.ToString() + "Legajo: " + this._legajo);
        }
        #endregion 
    }
}
