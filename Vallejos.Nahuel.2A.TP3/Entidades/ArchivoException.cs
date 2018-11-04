using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchivoException : Exception
    {
        /// <summary>
        /// Instancia ArchivoException, que hereda de Exception
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivoException(Exception innerException):base("Error al cargar o guardar el archivo....",innerException)
        { }


    }
}
