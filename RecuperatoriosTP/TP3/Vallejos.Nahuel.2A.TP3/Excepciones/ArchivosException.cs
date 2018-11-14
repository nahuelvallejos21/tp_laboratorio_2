using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Instancia ArchivoException, que hereda de Exception
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException) : base("Error al cargar o guardar el archivo....", innerException)
        { }


    }
}
