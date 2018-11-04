using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Instancia SinProfesorException, que hereda de Exception
        /// </summary>
        public SinProfesorException():base("No hay profesor para la clase")
        {}

    }
}
