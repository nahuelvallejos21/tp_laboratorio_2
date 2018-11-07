using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {

        private double _numero;

        /// <summary>
        /// Inicializa el atributo de Numero en 0
        /// </summary>
        public Numero():this(0)
        {
            
        }
        /// <summary>
        /// Inicializa el atributo de Numero que es pasado por parametro
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this._numero = numero;
        }
        /// <summary>
        /// Inicializa el atributo de Numero que es pasado por parametro
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }
        /// <summary>
        /// Propiedad de solo escritura, que asignara un valor al atributo de Numero
        /// </summary>
        private string SetNumero
        {
            set { this._numero = ValidarNumero(value); }
        }
        /// <summary>
        /// Propiedad de solo lectura, retornara el valor del atributo de Numero
        /// </summary>
        public double Dato
        {
            get { return this._numero;}
        }
        /// <summary>
        /// Valida si se trata de un numero o no
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            if(double.TryParse(strNumero,out retorno))
            {
                return retorno;
            }
            return 0;
        }
        /// <summary>
        /// Sobrecarga del operador "-", capaz de restar 2 objetos de tipo Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1,Numero n2)
        {
            return n1._numero - n2._numero;
        }
        /// <summary>
        /// Sobrecarga del operador "*", capaz de multiplicar 2 objetos de tipo Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1,Numero n2)
        {
            return n1._numero * n2._numero;
        }
        /// <summary>
        /// Sobrecarga del operador "/", capaz de dividir 2 objetos de tipo Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1 ,Numero n2)
        {
            return n1._numero / n2._numero;
        }
        /// <summary>
        /// Sobrecarga del operador "+", capaz de sumar 2 objetos de tipo Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1,Numero n2)
        {
            return n1._numero + n2._numero;
        }
        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            
            char[] array = binario.ToCharArray();
            int i;
            double numero = 0;
            Array.Reverse(array);
            for (i = 0; i < array.Length; i++)
            {
                if (array[i] == '1' || array[i] == '0')
                {
                    if (array[i] == '1')
                    {
                        numero = numero + (int)Math.Pow(2, i);
                    }
                }
                else
                {
                  return "Valor invalido";
                }
            }

            return numero.ToString();
        }
        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            string binario = "";
            string binarioCompleto = "Valor invalido";
            double numD;
            int aux;
            char[] caracter;
            if (double.TryParse(numero, out numD))
            {

                while (numD >= 1)
                {
                    aux = (int)(numD % 2);
                    binario = binario + aux.ToString();
                    numD = numD / 2;
                }

                caracter = binario.ToCharArray();
                Array.Reverse(caracter);
                binarioCompleto = new string(caracter);
            }


            return binarioCompleto;
        }
        /// <summary>
        /// Convierte un dato de tipo double en binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            return Numero.DecimalBinario(numero.ToString());
        }






    }
}
