using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Entidades
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        /// <summary>
        /// Tipo de nacionalidad de una Persona
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,Extranjero
        }
        #region Constructores
        /// <summary>
        /// Instancia por defecto el objeto Persona
        /// </summary>
        public Persona():this("Nombre","Apellido","1",ENacionalidad.Argentino)
        { }
        /// <summary>
        /// Instancia los atributos de Persona que son pasados por parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido= apellido;
            this._nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Instancia el atributo DNI + los demas atributos con la llamada de una sobrecarga
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre,string apellido,int dni,ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Instancia el atributo DNI + los demas atributos con la llamada de una sobrecarga
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
            
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura del atributo nombre
        /// </summary>
        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo apellido
        /// </summary>
        public string Apellido
        {
            get { return this._apellido; }
            set
            {
                this._apellido = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo dni, haciendo las respectivas validaciones
        /// </summary>
        public int DNI
        {
            get { return this._dni; }
            set
            {
                if (this.ValidarDni(this.Nacionalidad,value) != -1)
                {
                    this._dni = value;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no coincide con el número de DNI");
                }
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo dni, haciendo las respectivas validaciones
        /// </summary>
        public string StringToDNI
        {
            set
            {
                if(this.ValidarDni(this.Nacionalidad, value)!=-1)
                {
                    this._dni = int.Parse(value);
                   
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no coincide con el número de DNI");

                }

            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que valida el dni(int)
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            int aux = -1;
            if ((nacionalidad == ENacionalidad.Argentino) && (dato >= 1 && dato <= 89999999))
            {
                aux = 0;
            }
            else if ((nacionalidad == ENacionalidad.Extranjero) && (dato>= 90000000 && dato <= 99999999))
            {
                aux = 1;
            }
            return aux;
        }
        /// <summary>
        /// Método que valida el dni(string)
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad,string dato)
        {
            int aux = -1;
            int auxDni;
            if(dato.Length == 8 || nacionalidad == ENacionalidad.Argentino)
            {
                if(int.TryParse(dato,out auxDni))
                {
                    if(this.ValidarDni(nacionalidad,auxDni) == 0)
                    {
                        aux = 0;
                    }
                    else if(this.ValidarDni(nacionalidad, auxDni) == 1)
                    {
                        aux = 1;
                    }
                    
                }
                else
                { throw new DniInvalidoException("DNI invalido...."); }
            }
            else
            {
                throw new DniInvalidoException("DNI invalido....");
            }
            return aux;

        }
        /// <summary>
        /// Método que valida el nombre/apellido de la persona, verificando que la cadena sea alfabetica
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            Regex r = new Regex("[a-z]");
            if (r.IsMatch(dato.ToLower()))
            {
                retorno = dato;
            }
            return retorno;
        }
        /// <summary>
        /// Muestra todos los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre completo: " + this.Nombre + " " + this.Apellido);
            sb.AppendLine("Nacionalidad: " + this.Nacionalidad);
            sb.AppendLine("DNI: " + this.DNI);

            return sb.ToString();
        }
    }
    #endregion
}
