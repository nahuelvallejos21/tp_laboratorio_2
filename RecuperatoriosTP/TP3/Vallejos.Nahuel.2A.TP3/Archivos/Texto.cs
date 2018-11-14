using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        #region Métodos
        /// <summary>
        /// Guarda los datos que son pasados por parametros en un archivo txt
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo);
                sw.WriteLine(datos, false);
                sw.Close();
                return true;

            }
            catch (Exception e)
            {
                throw new ArchivosException(e);

            }
        }
        /// <summary>
        /// Lee un archivo txt a paratir del path que se le pasa por parametro, si todo esta correcto, retorna un string con toda la información
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader sb = new StreamReader(archivo);
                datos = sb.ReadToEnd();
                sb.Close();
                return true;

            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        #endregion



    }
}
