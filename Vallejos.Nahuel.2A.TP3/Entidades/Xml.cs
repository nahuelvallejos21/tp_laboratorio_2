using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace Entidades
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guardara los datos de un determinado objeto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {

                XmlSerializer xsw = new XmlSerializer(typeof(T));
                StreamWriter sw = new StreamWriter(archivo);
                xsw.Serialize(sw, datos);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
                
            }
        }
        /// <summary>
        /// Leera los datos de un determinado objeto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xsr = new XmlSerializer(typeof(T));
                StreamReader sr = new StreamReader(archivo);
                datos = (T)xsr.Deserialize(sr);
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                
                throw new ArchivoException(e);
            }
        }





    }
}
