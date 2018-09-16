using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            if (Calculadora.ValidarOperador(operador) == "+")
            {
                resultado = num1 + num2;
            }
            else if(Calculadora.ValidarOperador(operador)=="-")
            {
                resultado = num1 - num2;
            }
            else if (Calculadora.ValidarOperador(operador) == "*")
            {
                resultado = num1 * num2;
            }
            else if (Calculadora.ValidarOperador(operador) == "/")
            {
                resultado = num1 / num2;
            }
            return resultado;
        }
       private  static string ValidarOperador(string operador)
       {
            string retorno = "+";
            if(operador=="+" || operador=="-" || operador=="*" || operador=="/")
            {
                retorno = operador;
            }
            return retorno;
       }





    }
}
