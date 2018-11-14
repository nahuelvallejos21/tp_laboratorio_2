using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string _mensajeBase;
        /// <summary>
        /// Instancia DniInvalidoException, que hereda de Exception
        /// </summary>
        public DniInvalidoException() : base()
        { }
        /// <summary>
        /// Instancia DniInvalidoException, que hereda de Exception
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message) : this()
        {
            this._mensajeBase = message;
            

        }
        /// <summary>
        /// Instancia DniInvalidoException, que hereda de Exception
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e) : base("DNI inválido", e)
        { }
        /// <summary>
        /// Instancia DniInvalidoException, que hereda de Exception
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string msj, Exception e) : base(msj, e)
        { }



    }
}
