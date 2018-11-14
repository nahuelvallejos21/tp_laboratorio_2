using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;
        /// <summary>
        /// Tipos de clases
        /// </summary>
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        #region Constructor
        /// <summary>
        /// Instancia todas las listas
        /// </summary>
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._profesores = new List<Profesor>();
            this._jornada = new List<Jornada>();

        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura del atributo List<Alumno>
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo List<Jornada>
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this._jornada; }
            set { this._jornada = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo List<Profesor>
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this._profesores; }
            set { this._profesores = value; }
        }
        #endregion

        #region Indexador
        /// <summary>
        /// Indexador de escritura y lectura del atributo List<Jornada>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Jornada this[int index]
        {
            get
            {
                if (index >= 0 && index < this.Jornadas.Count)
                {
                    return this.Jornadas[index];
                }
                return null;
            }
            set
            {
                if (index >= 0 && index < this.Jornadas.Count)
                {
                    this.Jornadas[index] = value;
                }
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Sobrecarga del "==", una Universidad sera igual a un Alumno, si este ultimo pertenece a la Universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in g.Alumnos)
            {
                if (item.Equals(a))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga del "!=", niega lo que devuelve la sobrecarga "=="
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Sobrecarga del "==", una Universidad sera igual a un Profesor, si este ultimo da clases en la Universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor item in g.Instructores)
            {
                if (item.Equals(i))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga del "!=", niega lo que devuelve la sobrecarga "=="
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Una Universidad sera igual una clase, si esta ultima puede ser dada por algun profesor de la Universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor instAux = null;
            int flag = 0;
            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    instAux = item;
                    flag = 1;
                    break;
                }
            }

            if (flag == 0)
            {
                throw new SinProfesorException();
            }
            return instAux;
        }
        /// <summary>
        /// Retorna el primer profesor que no puede dar la determinada clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor instAux = null;
            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    instAux = item;
                    break;
                }
            }
            return instAux;
        }
        /// <summary>
        /// Agrega una clase a la Universidad, creando una nueva Jornada con todas sus ocurrencias
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Profesor instAux = (u == clase);
            if (instAux != null)
            {
                Jornada nuevaJornada = new Jornada(clase, instAux);
                for (int i = 0; i < u.Alumnos.Count; i++)
                {
                    if (u.Alumnos[i] == clase)
                    {
                        nuevaJornada.Alumno.Add(u.Alumnos[i]);
                    }
                }
                u.Jornadas.Add(nuevaJornada);
            }

            return u;

        }
        /// <summary>
        /// Agrega un alumno a la Universidad,siempre y cuando no se repita
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        /// <summary>
        /// Agrega un profesor a la Universidad, siempre y cuando no se repita
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);

            }
            return u;

        }
        /// <summary>
        /// Método estatico que muetra los datos de la Universidad
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad u)
        {
            string datos = "JORNADA:" + "\n";
            for (int i = 0; i < u.Jornadas.Count; i++)
            {
                datos += u[i].ToString() + "\n";

            }

            return datos;
        }
        /// <summary>
        /// Muestra de una manera publica los datos de la Universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Guarda los datos de la Universidad en un archivo XML
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xmlUniversidad = new Xml<Universidad>();
            if (xmlUniversidad.Guardar(string.Format(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml"), uni))
            {
                return true;
            }
            return false;

        }
        #endregion







    }
}
