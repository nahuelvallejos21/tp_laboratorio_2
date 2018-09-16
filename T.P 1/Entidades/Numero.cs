using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        public Numero():this(0){
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            this.MyNumber = strNumero;
        }
        private double ValidarNumero(string strNumero)
        {
            double valor;
            double.TryParse(strNumero, out valor);
            return valor;
        }
        private string MyNumber
        { set {this.numero = ValidarNumero(value);}
        }
        public static string BinarioDecimal(string binario)
        {
            string cadena = "";
            char[] array = binario.ToCharArray();
            int i;
            double numero = 0;
            Array.Reverse(array);
            for (i = 0; i < array.Length; i++)
            {
                if(array[i]=='1'|| array[i]=='0')
                {
                  if (array[i] == '1')
                  {
                    numero = numero + (int)Math.Pow(2, i);
                    cadena = numero.ToString();
                  }
                }
                else
                {
                    cadena = "Valor invalido";
                    break;
                }
            }
            return cadena;
        }
        public static string DecimalBinario(string numero)
        {
            string binario = "";
            string binarioCompleto = "Valor invalido";
            double numD;
            int aux;
            char[] caracter;
            if(double.TryParse(numero,out numD))
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
        public static string DecimalBinario(double numero)
        {
            string numD;
            numD = Numero.DecimalBinario(numero.ToString());
            return numD;
        }
        public static double operator -(Numero num1, Numero num2)
        {
            double resultado = num1.numero - num2.numero;
            return resultado;
        }
        public static double operator +(Numero num1, Numero num2)
        {
            double resultado = num1.numero + num2.numero;
            return resultado;
        }
        public static double operator *(Numero num1, Numero num2)
        {
            double resultado = num1.numero * num2.numero;
            return resultado;
        }
        public static double operator /(Numero num1, Numero num2)
        {
            double resultado = 0;
            if(num2.numero>0)
            {
                resultado = num1.numero / num2.numero;
            }
            return resultado;
        }






    }
}
