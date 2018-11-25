using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Entidades
{
    public static class GuardaString
    {

        /// <summary>
        /// Guardar una cadena determinada en un archivo de texto
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto,string archivo)
        {
            string patch = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +  @"\" + archivo;

            try
            {
                if (File.Exists(patch))
                {
                    StreamWriter sw = new StreamWriter(patch, true);
                    sw.WriteLine(texto);
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new StreamWriter(patch, false);
                    sw.WriteLine(texto);
                    sw.Close();
                }
                return true;
            }
            catch(Exception e)
            {
                throw e;
                
            }

        }





    }
}
