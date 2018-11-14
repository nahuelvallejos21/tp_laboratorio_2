using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Instancia AlumnoRepetidoException, que hereda de Exception
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido")
        { }

    }
}
