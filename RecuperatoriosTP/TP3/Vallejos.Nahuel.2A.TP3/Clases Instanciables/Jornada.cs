using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;
        #region Constructores
        /// <summary>
        /// Inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Inicializa los atributos de la Jornada + la lista de alumnos
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura de la lista de alumnos
        /// </summary>
        public List<Alumno> Alumno
        {
            get { return this._alumnos; }
            set
            {
                this._alumnos = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo instructor
        /// </summary>
        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Reemplazo del metodo ToString
        /// Muestra todos los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DE " + this.Clase + " POR NOMBRE COMPLETO:" + this.Instructor.Apellido + "," + this.Instructor.Nombre);
            sb.AppendLine();
            sb.AppendFormat(this.Instructor.ToString());
            sb.AppendLine();
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.Alumno)
            {
                sb.AppendFormat(item.ToString() + "\r\n");
            }
            sb.AppendLine("<---------------------------------------------------------------------------------->\n");
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga del operador "==", una Jornada sera igual a un Alumno, si este ultimo se encuentra en la lista de alumnos de la Jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            for (int i = 0; i < j.Alumno.Count; i++)
            {
                if (j.Alumno[i] == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador "!=", niega la sobrecarga del operador "=="
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega un alumno a la jornada, siempre y cuando el alumno no se encuentre en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumno.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }
        /// <summary>
        /// Guarda todos los datos de la jornada en un archivo txt,siempre y cuando cumpla con la condicion
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada j)
        {
            Texto textoJornada = new Texto();
            try
            {
                if (textoJornada.Guardar(string.Format(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt"), j.ToString()))
                {
                    return true;
                }

            }
            catch (ArchivosException e)
            {
                throw new ArchivosException(e);
            }
            return false;


        }
        /// <summary>
        /// Lee el archivo txt, y devuelve un string con todos los datos de la Jornada, siempre y cuando cumpla con la condicion
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto textoJornada = new Texto();
            string datos;
            if (textoJornada.Leer(string.Format(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt"), out datos))
            {
                return datos;
            }
            return "";
        }
        #endregion




    }
}
