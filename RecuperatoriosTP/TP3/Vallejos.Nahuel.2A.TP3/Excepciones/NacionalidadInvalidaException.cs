using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Instancia NacionalidadInvalidException, que hereda de la clase Exception
        /// </summary>
        public NacionalidadInvalidaException() : base()
        { }
        /// <summary>
        /// Instancia NacionalidadInvalidException, que hereda de la clase Exception
        /// </summary>
        /// <param name="mensaje"></param>
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        { }
    }
}
