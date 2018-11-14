using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #region Constructores
        /// <summary>
        /// Instancia el atributo estatico random
        /// </summary>
        static Profesor()
        {
            Profesor._random = new Random();
        }
        /// <summary>
        /// Instancia por defecto los atributos de Profesor
        /// </summary>
        public Profesor() : this(0, "Defecto", "Defecto", "10000000", ENacionalidad.Argentino)
        {
            //this._clasesDelDia = new Queue<Universidad.EClases>();
        }
        /// <summary>
        /// Instancia los atributos de Profesor que son pasados por parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionaidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionaidad) : base(ETipo.Profesor, id, nombre, apellido, dni, nacionaidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método protegido sobreescrito, que hereda de la clase Universitario
        /// Muestra todos los datos del Profesor 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Método protegido instanciado, que hereda de la clase Universitario
        /// Muestra todas las clases del Profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clases del día:");
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                sb.AppendFormat(item + "\r\n");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Método público que muestra todos los datos del Profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Se agregan 2 clases al azar a un determinado profesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this._clasesDelDia.Enqueue((Universidad.EClases)(Profesor._random.Next(0, 3)));
            }
        }
        /// <summary>
        /// Sobrecarga del "==",un profesor sera igual a una clase, si esta ultima es dada por el profesor
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            int x;
            for (x = 0; x < i._clasesDelDia.Count; x++)
            {
                if (i._clasesDelDia.ElementAt(x) == clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga del "!=", niega lo que devuelve la sobrecarga del "=="
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion 



    }
}
